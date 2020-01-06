namespace Task6.BLL.Interfaces.Services
{
    public interface ILogService
    {
        void Info(string message);

        void Debug(string message);

        void Warn(string message);

        void Error(string message);

        void Fatal(string message);
    }
}