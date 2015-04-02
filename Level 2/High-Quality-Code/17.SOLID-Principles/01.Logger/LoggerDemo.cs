namespace _01.Logger
{
    using Core;
    using Appenders;
    using Layouts;

    class LoggerDemo
    {
        static void Main()
        {
            Logger logger = new Logger(new FileAppender(new SimpleLayout(), "log.txt"));
            logger.Critical("asdasd");
            logger.Warn("asdasd");
            logger.Info("asdasd");
        }
    }
}
