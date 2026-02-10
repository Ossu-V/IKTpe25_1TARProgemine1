using System.Threading.Channels;

namespace EnumProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enum");

            //kasutate enumit Weekdays ja tahaks näha Friday
            Console.WriteLine(Weekdays.Friday);

            //tahame näha Friday numbrilist väärtust
            Console.WriteLine((int)Weekdays.Friday);
            Console.WriteLine("------------------");

            //tehke uus enum Colors
            //väärtused on 
            //Red = 3,
            //Green = 10,
            //Blue = 13,
            //Yellow = 5,
            //Black = 1,
            //White = 0
            //ühe värvi nimetuse peab konsoolis ära näitama

            //(int) - castimine ehk teisendab teiseks andmetüübiks
            //juhul kui info võib kaduma minna ja ei näita soovitud tulemust
            Console.WriteLine(Colors.Blue);
            Console.WriteLine((int)Colors.Blue);
        }
        enum Colors
        {
            Red = 3,
            Green = 10,
            Blue = 13,
            Yellow = 5,
            Black = 1,
            White = 0
        }
        enum Weekdays
        {
            Monday,
            Tuesday,
            Wednsday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}
