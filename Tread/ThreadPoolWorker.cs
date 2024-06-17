namespace Tread;

public class ThreadPoolWorker<T>
{
    private readonly Func<object, T> _func;
    
    public ThreadPoolWorker(Func<object, T> funk)
    {
        _func = funk ?? throw new ArgumentNullException();
    }

    public bool Success { get; private set; } = false;
    public bool IsComplete { get; private set; } = false;
    public Exception Exception { get; private set; } = null;
    public T FuncOut { get; private set; }

    public void Start(object state)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(Execute), state);
    }

    public T Wait()
    {
        Console.WriteLine($"Wait start in {Thread.CurrentThread.ManagedThreadId}");
        
        while (!IsComplete)
        {
            Thread.Sleep(150);
        }

        if (Exception != null)
        {
            throw Exception;
        }
        
        return FuncOut;
    }

    private void Execute(object state)
    {
        try
        {
            Console.WriteLine($"Execute start in {Thread.CurrentThread.ManagedThreadId}");

            FuncOut = _func.Invoke(state);
            
            Success = true;
        }
        catch (Exception ex)
        {
            Exception = ex;
            Success = false;
        }
        finally
        {
            IsComplete = true;
        }
    }
}