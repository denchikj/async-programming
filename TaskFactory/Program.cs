namespace TaskFactorys
{
    public class Program
    {
        static void Main(string[] args)
        {
            TaskFactory taskFactory = new TaskFactory();
            Task<double> t1 = taskFactory.StartNew(() => { return Calculate(1); });
            Task<double> t2 = taskFactory.StartNew(() => { return Calculate(2); });
            Task<double> t3 = taskFactory.StartNew(() => { return Calculate(3); });
            Task<double> t4 = taskFactory.StartNew(() => { return Calculate(4); });
            Task<double> t5 = taskFactory.StartNew(() => { return Calculate(5); });

            taskFactory.ContinueWhenAll(new Task[] { t1, t2, t3, t4, t5 },
                completedTask =>
                {
                    double sum = 0;

                    foreach (Task<double> item in completedTask)
                    {
                        sum += item.Result;
                    }
                    Console.WriteLine($"result - {sum:N}");
                });
            Console.ReadLine();
        }

        private static double Calculate(int v)
        {
            double res = 0.0;

            for (int i = 0; i < 10; i++)
            {
                res += i * Math.Sqrt(2 * Math.PI) * Math.Exp(-(v * v / 2));
            }

            return res;
        }
    }
}