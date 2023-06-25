namespace ThreadPoolV2
{
    public static class Program
    {
        static void Main(string[] args)
        {
            ThreadPoolWorker threadPoolWorker = new ThreadPoolWorker(new Action<object>(StartWriter));
            threadPoolWorker.Start('*');

            for (int i = 0; i < 40; i++)
            {
                Console.Write('-');
                Thread.Sleep(50);
            }

            threadPoolWorker.Wait();
        }

        private static void StartWriter(object obj)
        {
            char item = (char)obj;
            for (int i = 0; i < 50; i++)
            {
                Console.Write(item);
                Thread.Sleep(50);
            }
        }
    }
}