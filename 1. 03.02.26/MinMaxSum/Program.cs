namespace MinMaxSumAvg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List numbrites");

            int[] numbers = new int[10] { 2, 10, 15, 6, 8, 22, 3, 35, 67, 34 };
            Console.WriteLine();

            //Max
            Console.WriteLine("Max:");
            Console.WriteLine(numbers.Max());
            Console.WriteLine();

            //Min
            Console.WriteLine("Min:");
            Console.WriteLine(numbers.Min());
            Console.WriteLine();

            //Sum
            Console.WriteLine("Sum:");
            Console.WriteLine(numbers.Sum());
            Console.WriteLine();

            //Average
            Console.WriteLine("Avg:");
            Console.WriteLine(numbers.Average());
            Console.WriteLine();
            Console.WriteLine("---------------");

            Console.WriteLine("Sorteerib numbrid alates väiksemast suuremani");
            Console.WriteLine();
            //peate kasutama Array ja Sort ning foreachi

            Array.Sort(numbers);
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            

            //sorteerib numbrid alates suuremast väiksemani
            Console.WriteLine("Sorteerib numbrid alates suuremast väiksemani");
            Console.WriteLine();

            Array.Reverse(numbers);
            foreach(int i in numbers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
            Console.WriteLine("---------------");

            //kasutate binarySearch-i
            //kirjuta lühidalt, mis see tähendab

            Console.WriteLine(Array.BinarySearch(numbers, 9));
        }
    }
}
