namespace ConsoleForum
{
    using ConsoleForum.Contracts;

    public class ConsoleForumMain
    {
        public static void Main()
        {
            IForum forum = new ModifiedForum();
            forum.Run();
        }
    }
}
