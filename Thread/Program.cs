namespace Threads
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new(new ParameterizedThreadStart(WriteChar));

            thread.Start('*');

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine('-');
                Thread.Sleep(50);
            }            
        }

        private static void WriteChar(object? obj)
        {
            var item = (char?)obj;
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(item);
                Thread.Sleep(50);
            }

            Console.ReadLine();
        }
    }
}