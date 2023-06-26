namespace ChildTasks
{
    public static class Program
    {
        static void Main(string[] args)
        {
            #region parent
            
            //var parent = new Task(() =>
            //{
            //    new Task(() =>
            //    {
            //        Thread.Sleep(1000);
            //        Console.WriteLine("nested task 1 completed");
            //    }, TaskCreationOptions.AttachedToParent).Start();

            //    new Task(() =>
            //    {
            //        Thread.Sleep(2000);
            //        Console.WriteLine("nested task 2 completed");
            //    }, TaskCreationOptions.AttachedToParent).Start();

            //    Thread.Sleep(200);
            //    Console.WriteLine("parent task completed");
            //}, TaskCreationOptions.DenyChildAttach);

            //parent.Start();
            //parent.Wait();
            //Console.WriteLine("completed");
            //Console.ReadLine();

            #endregion

            #region parent2

            var parent2 = new Task<string>(() =>
            {
                var task1 = new Task<int>(() => Addition(5000), TaskCreationOptions.AttachedToParent);
                var task2 = new Task<int>(() => Addition(10000), TaskCreationOptions.AttachedToParent);
                var task3 = new Task<int>(() => Addition(50000), TaskCreationOptions.AttachedToParent);
                task1.Start();
                task2.Start();
                task3.Start();
                task1.ContinueWith(t => Console.WriteLine($"Task 1 result = {t.Result} "), TaskContinuationOptions.AttachedToParent);
                task2.ContinueWith(t => Console.WriteLine($"Task 2 result = {t.Result} "), TaskContinuationOptions.AttachedToParent);
                task3.ContinueWith(t => Console.WriteLine($"Task 3 result = {t.Result} "), TaskContinuationOptions.AttachedToParent);
                return "completed";
                //return (task1.Result + task2.Result + task3.Result).ToString();
            });

            parent2.Start();
            Console.WriteLine($"Parent task result = {parent2.Result}");
            Console.ReadKey();

            int Addition(int length)
            {
                var sum = 0;
                Thread.Sleep(1000);
                for (int i = 0; i < length; i++)
                {
                    sum++;
                }
                return sum;
            }

            #endregion

        }
    }
}