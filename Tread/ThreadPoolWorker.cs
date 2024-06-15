namespace Tread;

public class ThreadPoolWorker
{
    private int f;
    //private readonly Action<object> _action;
    private readonly Func<object, int> _func;
    
    public ThreadPoolWorker(Func<object, int> funk)
    {
        //_action = action ?? throw new ArgumentNullException();
        _func = funk ?? throw new ArgumentNullException();
    }

    public bool Success { get; private set; } = false;
    public bool IsComplete { get; private set; } = false;

    public void Start(object num)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(Execute), OutPut((int)num));
    }

    public string Wait()
    {
        Console.WriteLine($"Wait start in {Thread.CurrentThread.ManagedThreadId}");
        while (!IsComplete)
        {
            Thread.Sleep(150);
        }
        return $"Wait is finisched {OutPut(f)}";
    }

    private void Execute(object num)
    {
        try
        {
            Console.WriteLine($"Execute start in {Thread.CurrentThread.ManagedThreadId}");
            //_action.Invoke(state);
            f = _func.Invoke(num);
            
            Success = true;
        }
        catch (Exception ex)
        {
            Success = false;
        }
        finally
        {
            IsComplete = true;
        }
        //return (int)num + rand.Next(100, 1000);
    }

    private int OutPut(int num)
    {
        var rand = new Random();
        return num + rand.Next(10, 30);
    }
}