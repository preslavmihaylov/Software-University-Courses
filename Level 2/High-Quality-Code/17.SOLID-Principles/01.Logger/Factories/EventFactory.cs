namespace _01.Logger.Factories
{
    using System;
    using Enumerations;
    using Events;
    using Interfaces;

    public static class EventFactory
    {
        public static IEvent InfoEvent(string message)
        {
            return new Event(message, DateTime.Now, LogLevel.Information);
        }

        public static IEvent WarningEvent(string message)
        {
            return new Event(message, DateTime.Now, LogLevel.Warning);
        }

        public static IEvent ErrorEvent(string message)
        {
            return new Event(message, DateTime.Now, LogLevel.Error);
        }

        public static IEvent FatalErrorEvent(string message)
        {
            return new Event(message, DateTime.Now, LogLevel.FatalError);
        }

        public static IEvent CriticalErrorEvent(string message)
        {
            return new Event(message, DateTime.Now, LogLevel.CriticalError);
        }
    }
}
