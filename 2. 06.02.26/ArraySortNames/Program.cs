


namespace ArraySortNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kasutame Array ja Sort-i");

            string[] animals = { "cat", "alligator", "fox", "donkey", "bear", "elephant", "goat" };

            //paneb kõik tähestikulisse järjekorda
            //Array.Sort(animals);

            //tuleb kasutada foreachi ja näidata kõiki loomi
            foreach (string animal in animals)
            {
                Console.WriteLine(animal);
            }

            Console.WriteLine("------------------------");

            //järjesta kolm esimest sõna tähestikulises järjestuses
            //vaadake Sort meetodit ja mitu overload sel on

            //Array.Sort(animals, 0, 3);

            foreach (string animal in animals)
            {
                Console.WriteLine(animal);
            }

            Console.WriteLine("------------------------");

            int[] numbers = { 1, 2, 3, 4, 3, 55, 23, 2 };
            //tuleb välistada kordused
            //mida teha, et numbrid ei korduks?

            int[] numbers2 = numbers.Distinct().ToArray();
            
            foreach (int x in numbers2)
            {
                Console.WriteLine(x);
            }
        }
    }
}
