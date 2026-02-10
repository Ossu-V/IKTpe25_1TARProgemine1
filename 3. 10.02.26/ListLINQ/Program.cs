using System.Runtime.InteropServices;

namespace ListLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List and LINQ");

            //teeme "andmebaasi"
            //ja selleks on vaja luua class nimega person
            //mis on muutjua all nimega person
            IList<Person> person = new List<Person>()
            {
                new Person() {Id = 1, Name = "Juku", Age = 10},
                new Person() {Id = 2, Name = "Juhan", Age = 11},
                new Person() {Id = 3, Name = "Maali", Age = 9},
                new Person() {Id = 4, Name = "Aksel", Age = 10},
            };

            //nüüd kasutame person muutujat uue muutuja all
            //mille nimeks on persons
            var persons = from p in person
                          select new
                          {
                              Id = p.Id,
                              Name = p.Name,
                              Age = p.Age,
                          };

            //kasutame muutujat persons, et näidata konsoolis tulemust
            foreach (var item in person)
            {
                Console.WriteLine("Id on " + item.Id + ", nimi on " + item.Name + " ja vanus on " + item.Age);
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("Kasutame LINQ Selecti ehk teine variant");
            var result = person
                .Select(x => new
                {
                    Id = x.Id,
                    Name = x.Name,
                    Age = x.Age,
                });

            foreach (var item in result)
            {
                Console.WriteLine("Id on " + item.Id + ", nimi on " + item.Name + " ja vanus on " + item.Age);
            }
        }
    }
}
