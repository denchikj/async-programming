namespace ThreadPools
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Id thread method Main - {Thread.CurrentThread.ManagedThreadId}");
            Console.WriteLine("Press any key to start\n");
            Console.ReadKey();

            Report();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
            Report();
            ThreadPool.QueueUserWorkItem(new WaitCallback(Task2));
            Report();

            Thread.Sleep(4000);
            Console.WriteLine("Press any key to start\n");
            Console.ReadKey();
            Report();
        }

        private static void Task1(object? state)
        {
            Console.WriteLine($"start task1 {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(2000);
            Console.WriteLine($"end task1 {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void Task2(object? state)
        {
            Console.WriteLine($"start task2 {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(1000);
            Console.WriteLine($"end task2 {Thread.CurrentThread.ManagedThreadId}");
        }

        private static void Report()
        {
            ThreadPool.GetMaxThreads(out int maxWorkerThreads, out int maxPortThreads);
            ThreadPool.GetAvailableThreads(out int workerThreads, out int portThreads);

            Console.WriteLine($"Рабочие потоки {workerThreads} из {maxWorkerThreads}");
            Console.WriteLine($"IO потоки {portThreads} из {maxPortThreads}");
            Console.WriteLine(new string('-', 30));
        }
    }
}