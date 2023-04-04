using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;

namespace Rx.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // 1:
            //var evenNumber = new EvenNumberObservable();
            //var consoleObserver = new ConsoleLogObserver();
            //evenNumber.Subscribe(consoleObserver);

            // 2:
            //var evenNumber = new EvenNumberSubject();
            //evenNumber.Subscribe(Console.WriteLine);
            //evenNumber.Run();

            Observable.Range(1,100)
                .Where(c=>c%2==0)
                //.Take(10)
                //.Count()
                //.Max()
                // ...
                //.Merge(Another Observable!)
                .Subscribe(Console.WriteLine);



            Console.WriteLine("Completed");
            Console.ReadKey();
        }
    }
}