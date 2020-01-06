using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task6.BLL.Interfaces.Services
{
    public interface ITaskService
    {
        string DoSync();

        Task<string> DoAsync();

        Task<string> DoParallel();
    }
}