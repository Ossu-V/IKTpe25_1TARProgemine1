using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace InheratanceAndServiceClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = Microsoft.AspNetCore.Builder
                .WebApplication.CreateBuilder(args);

            Console.WriteLine("Hello, World!");
        }
    }
}