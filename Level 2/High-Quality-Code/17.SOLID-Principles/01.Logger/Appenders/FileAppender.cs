namespace _01.Logger.Appenders
{
    using System;
    using System.IO;
    using Interfaces;

    public class FileAppender : Appender
    {
        private readonly string filename;
        private StreamWriter writer;

        public FileAppender(ILayout layout, string filename) 
            : base(layout)
        {
            this.filename = filename;
        }

        public override void AppendEventInfo(IEvent logEvent)
        {
            this.writer = new StreamWriter(filename, true);
            this.writer.WriteLine(this.FormatMessage(logEvent));
            this.writer.Close();
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
