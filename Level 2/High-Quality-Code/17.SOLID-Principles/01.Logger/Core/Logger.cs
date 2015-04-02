namespace _01.Logger.Core
{
    using System;
    using Factories;
    using Interfaces;

    public class Logger
    {
        private IAppender appender;

        private IAppender Appender
        {
            get
            {
                return this.appender;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("The appender cannot be null.");
                }

                this.appender = value;
            }
        }

        public Logger(IAppender appender)
        {
            this.Appender = appender;
        }

        public void Info(string message)
        {
            this.Appender.AppendEventInfo(EventFactory.InfoEvent(message));
        }

        public void Warn(string message)
        {
            this.Appender.AppendEventInfo(EventFactory.WarningEvent(message));
        }

        public void Error(string message)
        {
            this.Appender.AppendEventInfo(EventFactory.ErrorEvent(message));
        }

        public void Critical(string message)
        {
            this.Appender.AppendEventInfo(EventFactory.CriticalErrorEvent(message));
        }

        public void Fatal(string message)
        {
            this.Appender.AppendEventInfo(EventFactory.FatalErrorEvent(message));
        } 
    }
}
