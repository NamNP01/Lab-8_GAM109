using System;
using System.Threading;

public class Program
{

    private static int randomNumber;
    private static Object _lock = new Object();
    static void thread1()
    {

        for (int i = 0; i < 100; i++)
        {
            lock (_lock)
            {
                Random rnd = new Random();
                randomNumber = rnd.Next(1, 10);
                Console.WriteLine("Thread 1 random number: " + randomNumber);
                Thread.Sleep(2000);
            }
        }
    }

    static void thread2()
    {
        for (int i = 0; i < 100; i++)
        {
            lock (_lock)
            {
                Console.WriteLine("Thread 2 square of random number: " + randomNumber * randomNumber);
                Thread.Sleep(1000);
            }

        }

    }
    static void Main(string[] args)
    {
        Thread thread1Start = new Thread(thread1);
        Thread thread2Start = new Thread(thread2);

        thread1Start.Start();
        thread2Start.Start();
        thread1Start.Join();
        thread2Start.Join();

    }


}