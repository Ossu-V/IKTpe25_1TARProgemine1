using Encapsulation.Service;

namespace Encapsulation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Endcapsulation e kapseldamine");

            //ligipääs classile Student ei ole piiratud kuna
            //asub samas projectis
            Student student = new Student();

            //miks ?
            Student2 student2 = new Student2();
        }
    }
}
