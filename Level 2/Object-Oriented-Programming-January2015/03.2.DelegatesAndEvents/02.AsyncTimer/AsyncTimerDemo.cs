using System;

class AsyncTimerDemo
{
    static void Main()
    {
        Action action = FirstMethod;
        AsyncTimer timer = new AsyncTimer(action, 20, 1000);
        timer.Start();
        for (int index = 0; index < 50; index++)
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("random stuff");
        }

        action = SecondMethod;
        timer = new AsyncTimer(action, 20, 500);
        timer.Start();
        for (int index = 0; index < 50; index++)
        {
            System.Threading.Thread.Sleep(500);
            Console.WriteLine("random stuff");
        }
    }

    private static void FirstMethod()
    {
        Console.WriteLine("This is the first method.");
    }

    private static void SecondMethod()
    {
        Console.WriteLine("This is the second method.");
    }
}
