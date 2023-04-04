namespace Rx.Demo;

public class ConsoleLogObserver : IObserver<int>
{
    public void OnCompleted()
    {
        Console.WriteLine("Completed");
    }

    public void OnError(Exception error)
    {
        Console.WriteLine($"Error: {error}");
    }

    public void OnNext(int value)
    {
        Console.WriteLine($"Even Number is:{value}");
    }
}