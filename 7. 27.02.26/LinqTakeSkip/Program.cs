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
            Console.WriteLine("4. FirstOrDefault");
            Console.WriteLine("5. Average");
            Console.WriteLine("6. Count");
            Console.WriteLine("7. SumLINQ");
            Console.WriteLine("8. MaxLINQ");
            Console.WriteLine("8. MinLINQ");

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

                case 4:
                    FirstOrDefault();
                    break;

                case 5:
                    AverageLINQ();
                    break;

                case 6:
                    CountLINQ();
                    break;

                case 7:
                    SumLINQ();
                    break;

                case 8:
                    MaxLINQ();
                    break;

                case 9:
                    MinLINQ();
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

        //vooskeem teha TakeWhile meetodist
        public static void TakeWhile()
        {
            Console.WriteLine("---------TakeWhile---------");

            var takeWhile = PeopleList.people.TakeWhile(x => x.Age > 18);

            foreach (var item in takeWhile)
            {
                Console.WriteLine(item.Id + " " + item.Name + " " + item.Age);
            }
            Console.WriteLine();
            //TakeWhile näitab isikuid kuni vastab tingimusele
            //ehk antud juhul näitab andmeid kuni leiab 18 a isiku ja
            //peale seda enam ei näita andmeid
        }

        public static void FirstOrDefault()
        {
            Console.WriteLine("---------FirstOrDefault---------");
            //peate kasutama Name ja Length-i. Nimi peab olema vähemalt 5
            //tähemärki pikk

            //kuvab esimese elemendi, mis järjestuses
            //vastab tingimustele

            string firstLongName = PeopleList.people
                .FirstOrDefault(x => x.Name.Length > 5).Name;

            Console.WriteLine("Esimene pikk nimi on '{0}'.", firstLongName);
        }

        //kasutame Avarage Linq
        //muutujaks on Age
        public static void AverageLINQ()
        {
            Console.WriteLine("---------Avarage---------");

            var average = PeopleList.people
                .Average(x => x.Age);

            Console.WriteLine("Kõikide keskmine vanus on " + average);
        }

        public static void CountLINQ()
        {
            var totalPersons = PeopleList.people.Count();

            Console.WriteLine("Inimesi on kokku: " + totalPersons);
            Console.WriteLine("---------------------------------");

            var adultPersons = PeopleList.people.Count(x => x.Age >= 18);
            Console.WriteLine("Täiskasvanuid on kokku: " + adultPersons);
        }

        //kasutame summat ehk Sum
        public static void SumLINQ()
        {
            var ageSum = PeopleList.people.Sum(x => x.Age);

            Console.WriteLine("Inimeste koondvanus on " + ageSum);
            Console.WriteLine("--------------------------------");

            var sumAdults = 0;
            var numAdults = PeopleList.people.Sum(x =>
            {
                if (x.Age >= 18)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });
            Console.WriteLine("Täiskasvanud isikute koondarv on " + numAdults);
        }

        //kasutada Max
        public static void MaxLINQ()
        {
            var oldestPerson = PeopleList.people.Max(x => x.Age);

            Console.WriteLine("Kõige vanem isik on " + oldestPerson);
        }

        public static void MinLINQ()
        {
            var youngestPerson = PeopleList.people.Min(x => x.Age);

            Console.WriteLine("Kõige noorem isik on " + youngestPerson);
        }
    }
}