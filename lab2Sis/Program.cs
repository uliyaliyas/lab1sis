using System;
using System.Threading;

class Program
{
    private static Mutex mutex = new Mutex();
    static void Main(string[] args)
    {
        Thread thread1 = new Thread(PrintAscending);
        Thread thread2 = new Thread(PrintDescending);
        thread1.Start();
        thread2.Start();
        thread1.Join();
        thread2.Join();
        Console.WriteLine("Работа потоков завершена.");
    }
    static void PrintAscending()
    {
        mutex.WaitOne();
        Console.WriteLine("Первый поток: числа от 0 до 20 в порядке возрастания:");
        for (int i = 0; i <= 20; i++)
        {
            Console.WriteLine(i);
            Thread.Sleep(100);
        }
        mutex.ReleaseMutex();
    }

    static void PrintDescending()
    {
        mutex.WaitOne();
        Console.WriteLine("Второй поток: числа от 10 до 0 в обратном порядке:");
        for (int i = 10; i >= 0; i--)
        {
            Console.WriteLine(i);
            Thread.Sleep(100);// Освобождаем мьютекс
        }
    }
}