namespace _01.Logger.Appenders
{
    using System;
    using Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {
        }

        public override void AppendEventInfo(IEvent logEvent)
        {
            Console.WriteLine(this.FormatMessage(logEvent));
        }

        private string FormatMessage(IEvent logEvent)
        {
            return string.Format(this.Layout.Format,
                logEvent.EventDate,
                logEvent.LoggingLevel.ToString(),
                logEvent.Message);
        }
    }
}
