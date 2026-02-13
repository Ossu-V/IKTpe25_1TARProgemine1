using System.Drawing;

namespace StructProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Struct");

            Coordinate point = new Coordinate(3, 5);
            Console.WriteLine(point.X);
            Console.WriteLine(point.Y);
            Console.WriteLine("---------------------");
            IntAndString IntAndString= new IntAndString("Oscar", 16);
            Console.WriteLine(IntAndString.Name);
            Console.WriteLine(IntAndString.Age);
            Console.WriteLine("---------------------");
            InsertedIntAndString insertedIntAndString = new InsertedIntAndString();
            Console.WriteLine(insertedIntAndString.PostalCode);
            Console.WriteLine(insertedIntAndString.City);
        }
    }

    //Mis on struct?
    //See on väärtustüüp (value type), mis sarnaneb klassile
    struct Coordinate
    {
        public int X;
        public int Y;

        //teha konstruktor
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    //teha struct nimega IntAndString
    //string Name ja int on Age
    //kutsuda see struct Main-s välja

    struct IntAndString
    {
        public string Name;
        public int Age;

        public IntAndString(string name, int age)
        {
            Name = name;
            Age = age; 
        }
    }

    //teha struct nimega InsertedIntAndString
    //string City ja int on PostalCode
    //kutsuda see struct Main-s välja
    //structi sees tuleb sellele anda juba väärtus
    //andmeid ei saa structis edasi anda

    struct InsertedIntAndString
    {
        public string City;
        public int PostalCode;

        public InsertedIntAndString(string city, int postalCode)
        {
            City = city;
            PostalCode = postalCode;

            city = "Tallinn";
            postalCode = 1234;
        }
    }
}
