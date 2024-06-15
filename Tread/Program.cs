namespace Tread;

public class Program
{
       static ThreadPoolWorker threadPoolWorker = new ThreadPoolWorker(Exampel);
    private static void Main(string[] args)
    {
        Console.WriteLine($"Method Main Thread ID - {Thread.CurrentThread.ManagedThreadId}");
        /*
        Console.WriteLine("Please press any key...");
        Console.ReadKey();
        */

        var rand = new Random();
        //threadPoolWorker.Start(rand.Next(1, 10));
        threadPoolWorker.Start('*');


        for (int i = 0; i < 40; i++)
        {
            Console.Write('-');
            
            Thread.Sleep(100);
        }

        Console.WriteLine(threadPoolWorker.Wait());

        /*
        Report();
        ThreadPool.QueueUserWorkItem(new WaitCallback(Example1));
        Report();
        ThreadPool.QueueUserWorkItem(new WaitCallback(Example2));
        Report();

        Console.ReadKey();
        Report();
    */
    }

    public static void Print()
    {
        
    }

    public static int Exampel(object num)
    {
        var rand = new Random();
        for (int i = 0; i < 40; i++)
        {
            //Console.Write(workThreads + " ");
            Thread.Sleep(100);
            Console.WriteLine(num);
            
        }
        //Console.WriteLine(threadPoolWorker.Wait());

        return (int)num;
    }

    private static void WriteChar(object obj)
    {
        char item = (char)obj;

        for (int i = 0; i < 220; i++)
        {
            Console.Write(item);
            Thread.Sleep(500);
        }
    }

    private static void Example1(object state)
    {
        Console.WriteLine($"Method Example1 begean work in Thread ID - {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(2000);
        Console.WriteLine($"Method Example1 end work in Thread ID - {Thread.CurrentThread.ManagedThreadId}");
    }

    private static void Example2(object state)
    {
        Console.WriteLine($"Method Example2 begean work in Thread ID - {Thread.CurrentThread.ManagedThreadId}");
        Thread.Sleep(1000);
        Console.WriteLine($"Method Example2 end work in Thread ID - {Thread.CurrentThread.ManagedThreadId}");
    }

    private static void Report()
    {
        ThreadPool.GetMaxThreads(out int maxWorkThreads, out int maxPortThreads);
        ThreadPool.GetAvailableThreads(out int workThreads, out int portThreads);

        Console.WriteLine($"work thread {workThreads} from {maxWorkThreads}");
        Console.WriteLine(new string('-', 80));
    }

    private static void PrintChar(object arg)
    {
        Console.WriteLine($"Current thread Id: ${Thread.CurrentThread.ManagedThreadId}");
        char item = (char)arg;
        for (int i = 0; i < 800; i++)
        {
            Console.Write(item);
            Thread.Sleep(1000);
        }
    }
}