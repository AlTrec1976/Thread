﻿namespace Tread;

public class ThreadPoolWorker<T>
{
    private readonly Func<object, T> _func;
    private T result;
    
    public ThreadPoolWorker(Func<object, T> funk)
    {
        _func = funk ?? throw new ArgumentNullException();
    }

    public bool Success { get; private set; } = false;
    public bool IsComplete { get; private set; } = false;
    public Exception Exception { get; private set; } = null;

    public T ThreadOut
    {
        get
        {
            Console.WriteLine($"\nThread is started in {Thread.CurrentThread.ManagedThreadId}");
            
            while (!IsComplete)
            {
                Thread.Sleep(100);
            }
            
            Console.WriteLine($"\nThread is finished in {Thread.CurrentThread.ManagedThreadId}");

            return Success && Exception == null ? result : throw Exception;
        }
    }

    public void Start(object state)
    {
        ThreadPool.QueueUserWorkItem(new WaitCallback(Execute), state);
    }

    private void Execute(object state)
    {
        try
        {
            Console.WriteLine($"Execute start in {Thread.CurrentThread.ManagedThreadId}");

            result = _func.Invoke(state);
            
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