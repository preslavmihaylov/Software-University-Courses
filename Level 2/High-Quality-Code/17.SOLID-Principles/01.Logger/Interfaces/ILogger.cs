namespace _01.Logger.Interfaces
{
    interface ILogger
    {
        void Info(string message);
        void Warn(string message);
        void Error(string message);
        void Fatal(string message);
        void Critical(string message);
    }
}
