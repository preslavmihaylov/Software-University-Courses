namespace _01.Logger.Interfaces
{
    using System;
    using Enumerations;

    public interface IEvent
    {
        string Message
        {
            get;
        }

        DateTime EventDate
        {
            get;
        }

        LogLevel LoggingLevel
        {
            get;
        }
    }
}
