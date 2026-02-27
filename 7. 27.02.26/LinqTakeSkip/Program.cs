namespace LinqTakeSkip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kutsume esile LINQ meetodid");
            Console.WriteLine("1. Skip");
            Console.WriteLine("2. SkipWhile");
            Console.WriteLine("3. TakeWhile");

            //siin kasutada switchi ja peab saama Skip meetodit esile kutsuda

            int choice = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (choice)
            {
                case 1:
                    Skip();
                    break;

                case 2:
                    SkipWhile();
                    break;

                case 3:
                    TakeWhile();
                    break;

                default:
                    Console.WriteLine("Vale valik");
                    break;
            }
        }
        public static void Skip()
        {
            Console.WriteLine("---------Skip---------");
            //kasuta skip ja jäta kolm tükki vahele

            var skip = PeopleList.people.Skip(3);

            foreach (var item in skip)
            {
                Console.WriteLine(item.Name);
            }
            Console.WriteLine();
        }

        //teete uue meetodi, aga kasutate SkipWhile ja vanemad, kui 18 aastat peab olema tingimus
        public static void SkipWhile()
        {
            Console.WriteLine("---------SkipWhile---------");
            //mis tähendab: => . See tähendab lambda märki ja selle
            //abil saab kasutada pikema classi nimetuse asemel lühendit
            //koos sees oleva muutujaga, mis antud juhul on x.

            var skipWhile = PeopleList.people.SkipWhile(x => x.Age > 18);

            foreach (var item in skipWhile)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
            Console.WriteLine();
            //skipWhile jätab loendis nii kaua vahele ridu kuni vastab tingimusele
            //ehk antud juhul jätab read vahele kuni leiab 18 a isiku ja
            //peale seda hakkab infot jälle kuvama olemata vanuse tingimusest
        }

        //kasutada TakeWhile ja kutsuda see esile switchis
        //tingimus on Age > 18

        public static void TakeWhile()
        {
            Console.WriteLine("---------TakeWhile---------");

            var takeWhile = PeopleList.people.TakeWhile(x => x.Age > 18);

            foreach (var item in takeWhile)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
            Console.WriteLine();
        }
    }
}
