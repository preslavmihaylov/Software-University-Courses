namespace _01.Logger.Events
{
    using System;
    using Enumerations;
    using Interfaces;

    public class Event : IEvent
    {
        private string message;
        private DateTime date;
        private LogLevel loggingLevel;

        public Event(string message, DateTime date, LogLevel loggingLevel)
        {
            this.Message = message;
            this.EventDate = date;
            this.LoggingLevel = loggingLevel;
        }
    
        public string Message
        {
	        get
	        {
	            return this.message;
	        }
            private set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("The event message cannot be null or empty.");
                }

                this.message = value;
            }
        }

        public DateTime EventDate
        {
	        get
	        {
	            return this.date;
	        }
            private set
            {
                this.date = value;
            }
        }

        public LogLevel LoggingLevel
        {
	        get
	        {
	            return this.loggingLevel;
	        }
            set
            {
                this.loggingLevel = value;
            }
        }
    }
}