using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Thread_Lesson09
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter a number: ");
            long number = long.Parse(Console.ReadLine());

            int current = 1;

            while (number != 0 && number > 0)
            {
                var ThreadEven = new Thread(() => EvenNumbers(number,current));
                var ThreadPrime = new Thread(() => PrimeNumbers(number, current));

                ThreadEven.Start();
                ThreadPrime.Start();

                Console.Write("Enter a number: ");
                number = int.Parse(Console.ReadLine());

                current++;
            }

            Console.WriteLine("       Error \n" +
                "You did not enter a natural number!");

            TimerThread();
        }

        static void EvenNumbers(long number,int curnum)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Even Numbers.txt";

            List<string> list = new List<string>();
            list.Add($"________________________List{curnum}______________________________");
            list.Add($"             ( 1 , {number} ) interval ");

            long current = 1;
            long current2 = 1;

            for(long i = 2; i <= number; i += 2)
            {
                Console.WriteLine($" Even number{current++} : {i}");
                list.Add($" Even number{current2++} : {i}");
            }

            using (var sw = new StreamWriter(path, true))
            {
                foreach (var text in list)
                {
                    sw.WriteLine(text);
                }
            }
        }

        static void PrimeNumbers(long n,int curnum)
        {
            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Prime Numbers.txt";

            List<string> list = new List<string>();
            list.Add($"________________________List{curnum}______________________________");
            list.Add($"             ( 1 , {n} ) interval ");

            long current = 1;
            long current2 = 1;

            for (long i = 2; i <= n; i++)
            {
                bool isPrime = true;

                for (long j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    Console.WriteLine($" Prime number{current++} : {i} ");
                    list.Add($" Prime number{current2++} : {i} ");
                }
            }
                using(var sw = new StreamWriter(path, true))
                {
                    foreach (var text in list)
                    {
                       sw.WriteLine(text);
                    }
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