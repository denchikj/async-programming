namespace ChildTasks
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var parent = new Task(() =>
            {
                new Task(() =>
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("nested task 1 completed");
                }, TaskCreationOptions.AttachedToParent).Start();

                new Task(() =>
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("nested task 2 completed");
                }, TaskCreationOptions.AttachedToParent).Start();

                Thread.Sleep(200);
                Console.WriteLine("parent task completed");
            }, TaskCreationOptions.DenyChildAttach);

            parent.Start();
            parent.Wait();
            Console.WriteLine("completed");
            Console.ReadLine();
        }
    }
}