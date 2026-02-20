
using System.Threading.Channels;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //Tuleb teha class nimega PeopleList
            //Seal on kuus rida andmeid
            //kindlasti peab olema kaks Mari nimega isikut,
            //aga erinevate vanustega

            Console.WriteLine("Tee valik numbriga");
            Console.WriteLine("Valikus on: ");
            Console.WriteLine("Nr 1. ThenBy");
            Console.WriteLine("Nr 2. ThenByDescending");
            Console.WriteLine("Nr 3. SelectBy");
            
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:
                    ThenByLINQ();
                    break;

                case 2:
                    ThenByDescendingLINQ();
                    break;

                case 3:
                    SelectByLINQ();
                    break;

                default:
                    Console.WriteLine("Vale valik");
                    break;

            }
        }

        //kutsuda meetod switchis esile
        public static void ThenByLINQ()
        {
            //thenBy sorteerib numbrilises järjestuses
            var thenByResult = PeopleList.peoples
                .OrderBy(x => x.Name)
                .ThenBy(x => x.Age);

            Console.WriteLine("ThenBy järgi sorteerimine");

            foreach (var person in thenByResult)
            {
                Console.WriteLine(person.Name + " " + person.Age);
            }
            Console.WriteLine();
        }

        public static void ThenByDescendingLINQ()
        {
            var thenByResult = PeopleList.peoples
                .OrderBy(x => x.Name)
                .ThenByDescending(x => x.Age);

            Console.WriteLine("ThenBy järgi sorteerimine");

            foreach (var person in thenByResult)
            {
                Console.WriteLine(person.Name + " " + person.Age);
            }
        }
        public static void SelectByLINQ()
        {
            //select lihtsalt tagastab andmed nii nagu need on andmebaasis
            //sama hea, mis SQL select
            var result = PeopleList.peoples
                .Select(x => new
                {
                  Name = x.Name, 
                  Age = x.Age,
                });

            foreach (var person in result)
            {
                Console.WriteLine(person.Name + " " + person.Age);
            }
        }
    }
}
