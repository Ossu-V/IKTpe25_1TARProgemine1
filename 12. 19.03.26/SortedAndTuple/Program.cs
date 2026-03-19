using System.Collections;

namespace SortedAndTuple
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sorted And Tuple");
            Console.WriteLine("1. SortedList");
            Console.WriteLine("2. Tuple");
            Console.WriteLine("---------------------");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SortedList();
                    break;

                case 2:
                    Tuple();
                    break;

                default:
                    Console.WriteLine("ERROR");
                    break;
            }
            Console.WriteLine();
        }

        static void SortedList()
        {
            SortedList<int, string> sl = new SortedList<int, string>();

            sl.Add(3, "Three");
            sl.Add(1, "One");
            sl.Add(2, "Two");

            foreach (var item in sl)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }
        }

        static void Tuple()
        {
            {
                var tuple = (123, "Hello", true);

                Console.WriteLine(tuple.Item1);
                Console.WriteLine(tuple.Item2);
                Console.WriteLine(tuple.Item3);
            }
        }
    }
}
