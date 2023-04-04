using System.Reactive.Subjects;

namespace Rx.Demo;

class EvenNumberSubject : IDisposable
{
    // for cash event we should use ReplySubject
    // for print the last one we can use BehaviorSubject
    // for using SyncSubject we sould call complete method exac after subject.OnNext then console will print the last one item
    private readonly Subject<int> subject = new ();
    private readonly List<IDisposable> disposables = new();

    public void Dispose()
    {
        subject?.Dispose();
        foreach (var disposable in disposables)
        {
            disposable.Dispose();
        }
    }

    public void Run()
    {
        Enumerable.Range(1, 100).Where(x => x % 2 == 0).ToList().ForEach(x =>
        {
            subject.OnNext(x);
        });
    }

    public void Subscribe(Action<int> action)
    {
        disposables.Add(subject.Subscribe(action));
    }
}