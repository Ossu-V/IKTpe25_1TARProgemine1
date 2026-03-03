namespace LINQAllAny
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello LINQ");
            Console.WriteLine("1. All");
            Console.WriteLine("2. Any");
            Console.WriteLine("3. Join");

            int choice = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (choice)
            {
                case 1:
                    AllLINQ();
                    break;

                case 2:
                    AnyLINQ();
                    break;

                case 3:
                        JoinLINQ();
                    break;

                default:
                    Console.WriteLine("ERROR");
                    break;
            }
        }

        public static void AllLINQ()
        {
            //kasutate All
            //kontrollite, kas on vanemaid, kui 12 ja nooremaid, kui 20
            
            bool results = StudentData.students.All(x => x.Age > 12 && x.Age < 20);

            Console.WriteLine(results);

        }

        //teeme uue meetodi nimega AnyLINQ
        //kasutada Any-t
        //vastus on true
        //kasutada muutujat Age

        public static void AnyLINQ()
        {
            bool results = StudentData.students.Any(x => x.Age > 12 && x.Age < 20);

            Console.WriteLine(results);
        }

        //teha meetod nimega JoinLINQ
        //kasutada Join-i 

        public static void JoinLINQ()
        {
            var innerJoin = StudentData.students
                .Join
                (
                    StandardData.standards,
                    students => students.StandardId,
                    standardId => standardId.StandardId,
                    (students, standardId) => new
                    {
                        Name = students.Name,
                        StandardId = standardId.StandardId,
                    }
                );

            foreach (var item in innerJoin)
            {
                Console.WriteLine("{0} - {1}", item.Name, item.StandardId);
            }
        }
    }
}
