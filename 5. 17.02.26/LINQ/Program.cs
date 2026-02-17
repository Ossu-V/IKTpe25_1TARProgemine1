using LINQ.Models;
using System;

namespace LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Kutsume esile LINQ läbi switchi");
            Console.WriteLine("Vali vastav link numbriga");
            Console.WriteLine("1. Where");
            Console.WriteLine("2. Where ja otsib nime järgi");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    WhereLINQ();
                    break;

                case 2:
                    WhereByNameLINQ();
                    break;

                default:
                    break;
            }
        }
        //teeme uue meetoid
        public static void WhereLINQ()
        {
            var peopleAge = PeopleData.peoples
                .Where(x => x.Age > 20 && x.Age < 23);

            //kasuta muutujat peaopleAge ja kuvanda andmed esile
            //kasuta foreachi

          foreach (var person in peopleAge)
            {
                Console.WriteLine(person.Name);
            }
        }

        public static void WhereByNameLINQ()
        {
            Console.WriteLine("Kirjuta inimese nimi: ");
            string name = Console.ReadLine();

            //kasutada where inimese otsimiseks
            //otsimine toimub nime alusel

            var peopleName = PeopleData.peoples
                .Where(x => x.Name == name);

            foreach (var people in peopleName)
            {
                Console.WriteLine(people.Name + " " + people.Age);
            }
        }
    }
}
