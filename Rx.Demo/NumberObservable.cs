using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace Rx.Demo
{
    public class EvenNumberObservable : IObservable<int>
    {
        public IDisposable Subscribe(IObserver<int> observer)
        {
            Enumerable.Range(1, 100).Where(x => x % 2 == 0).ToList().ForEach(x =>
            {
                observer.OnNext(x);
            });

            return Disposable.Empty;
        }
    }

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
}
 