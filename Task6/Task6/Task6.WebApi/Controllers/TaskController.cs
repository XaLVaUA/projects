using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task6.BLL.Interfaces.Services;

namespace Task6.WebApi.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("sync")]
        public string Sync()
        {
            return _taskService.DoSync();
        }

        [HttpGet("async")]
        public Task<string> Async()
        {
            return _taskService.DoAsync();
        }

        [HttpGet("parallel")]
        public Task<string> Parallel()
        {
            return _taskService.DoParallel();
        }
    }
}