namespace _01.Logger.Interfaces
{
    public interface IAppender
    {
        void AppendEventInfo(IEvent logEvent);
    }
}
