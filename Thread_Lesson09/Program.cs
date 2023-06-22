namespace Thread_Lesson09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            long number = long.Parse(Console.ReadLine());

            long current = 1;

            while (number != 0 && number > 0)
            {
                var thread = new Thread(() => GetNumbers(number));
                thread.Name = "Thread";

                Console.WriteLine($"----------------{thread.Name}{current++}-------------------------------");

                thread.Start();
                thread.Join();

                Console.Write("Enter a number: ");
                number = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("       Error \n" +
                "You did not enter a natural number!");

            TimerThread();

        }

        static void GetNumbers(long number)
        {
            for (long i = 1; i <= number; i++)
            {
                Console.WriteLine($" Thread{i} : {i} ");
            }
        }

        static void TimerThread()
        {
            for (int i = 5; i >= 0; i--)
            {
                Console.WriteLine($" {i} second ...");
                Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}