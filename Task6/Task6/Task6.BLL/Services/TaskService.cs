using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Task6.BLL.Interfaces.Services;

namespace Task6.BLL.Services
{
    public class TaskService : ITaskService
    {
        private ILogService _log;

        private string[] _uris = { "https://docs.microsoft.com/en-us/dotnet/", "https://docs.microsoft.com/en-us/aspnet/", "https://docs.microsoft.com/en-us/azure/", "https://www.google.com/" };

        public TaskService(ILogService logService)
        {
            _log = logService;
        }

        public string DoSync()
        {
            var stopWatch = new Stopwatch();
            var pageNos = new List<int>();
            var str = new StringBuilder();

            stopWatch.Start();
            for (int i = 0, count = _uris.Length; i < count; ++i)
            {
                pageNos.Add(DownloadStringReturnNo(_uris[i], i + 1));
            }

            foreach (var pageNo in pageNos)
            {
                str.Append($" {pageNo} ");
            }

            stopWatch.Stop();
            str.Append($" time: {stopWatch.Elapsed}");

            var res = str.ToString();

            _log.Info("sync " + res);

            return res;
        }

        public async Task<string> DoAsync()
        {
            var stopWatch = new Stopwatch();
            var tasks = new List<Task<int>>();
            var str = new StringBuilder();

            stopWatch.Start();
            for (int i = 0, count = _uris.Length; i < count; ++i)
            {
                tasks.Add(DownloadStringReturnNoAsync(_uris[i], i + 1));
            }

            while (tasks.Any())
            {
                var task = await Task.WhenAny(tasks);
                str.Append($" {task.Result} ");
                tasks.Remove(task);
            }

            stopWatch.Stop();
            str.Append($" time: {stopWatch.Elapsed}");

            var res = str.ToString();

            _log.Info("async " + res);

            return res;
        }

        public async Task<string> DoParallel()
        {
            var stopWatch = new Stopwatch();
            var tasks = new List<Task<int>>();
            var str = new StringBuilder();

            stopWatch.Start();

            Parallel.For(0, _uris.Length, (int i) =>
            {
                tasks.Add(DownloadStringReturnNoAsync(_uris[i], i + 1));
            });

            while (tasks.Any())
            {
                var task = await Task.WhenAny(tasks);
                str.Append($" {task.Result} ");
                tasks.Remove(task);
            }

            stopWatch.Stop();
            str.Append($" time: {stopWatch.Elapsed}");

            var res = str.ToString();

            _log.Info("parallel " + res);

            return res;
        }

        private int DownloadStringReturnNo(string uri, int no)
        {
            using var webClient = new WebClient();
            var page = webClient.DownloadString(uri);
            return no;
        }

        private Task<int> DownloadStringReturnNoAsync(string uri, int no)
        {
            return Task.Run(() => DownloadStringReturnNo(uri, no));
        }
    }
}