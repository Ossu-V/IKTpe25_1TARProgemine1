using InheritanceAndServiceClass.AppServices.Services;
using InheritanceAndServiceClass.Core.ServiceInterface;
using Microsoft.AspNetCore.Mvc;


namespace InheritanceAndServiceClass
{
    internal class Program
    {
        private readonly ICarServices _carServices;

        public Program
            (
                ICarServices carServices
            )
        {
            _carServices = carServices;
        }

        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped<ICarServices, CarServices>();

            Console.WriteLine("Hello, World Switch!");
            Console.WriteLine("1. GetAsync");
            Console.WriteLine("2. SaveAsync");
            Console.WriteLine("3. UpdateData");
            Console.WriteLine("4. EraseData");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    var app = builder.Build();
                    using (var scope = app.Services.CreateScope())
                    {
                        var carServices = scope.ServiceProvider.GetRequiredService<ICarServices>();
                        var program = new Program(carServices);
                        program.GetAsync();
                    }
                    break;

                case 2:
                    app = builder.Build();
                    using (var scope = app.Services.CreateScope())
                    {
                        var carServices = scope.ServiceProvider.GetRequiredService<ICarServices>();
                        var program = new Program(carServices);
                        program.SaveAsync();
                    }
                        break;

                case 3:
                    app = builder.Build();
                    using (var scope = app.Services.CreateScope())
                    {
                        var carServices = scope.ServiceProvider.GetRequiredService<ICarServices>();
                        var program = new Program(carServices);
                        program.UpdateData();
                    }
                    break;

                case 4:
                    app = builder.Build();
                    using (var scope = app.Services.CreateScope())
                    {
                        var carServices = scope.ServiceProvider.GetRequiredService<ICarServices>();
                        var program = new Program(carServices);
                        program.EraseData();
                    }
                    break;

                default:
                    Console.WriteLine("Error");
                    break;
            }
            Console.Clear();
        }

        public IActionResult GetAsync()
        {
            _carServices.GetData();

            return View();
        }

        private IActionResult View()
        {
            throw new NotImplementedException();
        }

        public IActionResult SaveAsync()
        {
            _carServices.PostData();

            return View();
        }

        public IActionResult UpdateData()
        {
            _carServices.PutData();

            return View();
        }

        public IActionResult EraseData()
        {
            _carServices.PutData();

            return View();
        }
    }
}