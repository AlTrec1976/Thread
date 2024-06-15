namespace Tread;

public class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Method Main Thread ID - {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine("Please press any key...");
        Console.ReadKey();

        ThreadPoolWorker<int> threadPoolWorker = new ThreadPoolWorker<int>(Exampel<int>);
        threadPoolWorker.Start(50);


        for (int i = 0; i < 40; i++)
        {
            Console.Write('-');

            Thread.Sleep(100);
        }

        Console.WriteLine(threadPoolWorker.Wait());
    }

    private static T Exampel<T>(object state)
    {
        for (int i = 0; i < 40; i++)
        {
            Thread.Sleep(100);
            Console.WriteLine(state);
        }

        return (T)state;
    }
}