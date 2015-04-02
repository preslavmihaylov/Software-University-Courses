namespace _01.Logger.Appenders
{
    using Interfaces;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        protected ILayout Layout
        {
            get
            {
                return this.layout;
            }
            private set
            {
                this.layout = value;
            }
        }

        public abstract void AppendEventInfo(IEvent logEvent);
    }
}
