using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace Ch24Ex05
{
    internal class Program
    {
        private static void Main()
        {
            WriteLine("Основной поток выполнения запущен.");

            // Далее лямбда выражение используется для определения задачи.
            var task = Task.Factory.StartNew(() =>
            {
                WriteLine("Задача запущена.");

                for (var count = 0; count < 10; count++)
                {
                    Thread.Sleep(500);
                    WriteLine($"Подсчёт в задаче равен {count}");
                }

                WriteLine("Задача завершена.");
            });

            // Главному потоку дождаться завершения задачи task.
            task.Wait();

            // Освободить задачу task.
            task.Dispose();

            WriteLine("Основной поток завершён.");
        }
    }
}
