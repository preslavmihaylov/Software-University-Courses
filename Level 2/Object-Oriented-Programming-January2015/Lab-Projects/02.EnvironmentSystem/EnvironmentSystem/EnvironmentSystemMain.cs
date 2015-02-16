namespace EnvironmentSystem
{
    using EnvironmentSystem.Core;

    public class EnvironmentSystemMain
    {
        static void Main()
        {
            var engine = new ModifiedEngine(new KeyboardController());
            engine.Run();
        }
    }
}
