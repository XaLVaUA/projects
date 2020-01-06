using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task6.LastTask
{
    public class TaskService
    {
        private string[] _uris = { "https://docs.microsoft.com/en-us/dotnet/", "https://docs.microsoft.com/en-us/aspnet/", "https://docs.microsoft.com/en-us/azure/", "https://www.google.com/" };

        public void DoSync()
        {
            var stopWatch = new Stopwatch();
            var pageNos = new List<int>();

            stopWatch.Start();
            for (int i = 0, count = _uris.Length; i < count; ++i)
            {
                pageNos.Add(DownloadStringReturnNo(_uris[i], i + 1));
            }

            foreach (var pageNo in pageNos)
            {
                Console.WriteLine(pageNo);
            }
            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
        }

        public async void DoAsync()
        {
            var stopWatch = new Stopwatch();
            var tasks = new List<Task<int>>();

            stopWatch.Start();
            for (int i = 0, count = _uris.Length; i < count; ++i)
            {
                tasks.Add(DownloadStringReturnNoAsync(_uris[i], i + 1));
            }

            while (tasks.Any())
            {
                var task = await Task.WhenAny(tasks);
                Console.WriteLine(task.Result);
                tasks.Remove(task);
            }

            stopWatch.Stop();
            Console.WriteLine(stopWatch.Elapsed);
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