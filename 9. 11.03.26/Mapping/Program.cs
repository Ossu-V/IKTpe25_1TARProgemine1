using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Mapping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mapper");

            Employee emp = new Employee();

            emp.Id = 11;
            emp.Name = "Name1";
            emp.Title = "Title1";
            emp.Description = "Description1";

            //mappimine algab pihta 
            EmployeeDto dto = new EmployeeDto();

            //mappimine on see, kus mõlema classi muutujad viiakse omavahel kokku 
            //protsess, kus muudetakse andmed ühest formaadist, struktuurist või
            //süsteemist teiseks

            //kasutatakse väärtustes ja muutmiste abil, et ühenduda andmebaasis
            //olevate tabelistega 
            dto.Id = emp.Id;
            dto.Name = emp.Name;
            emp.Title = emp.Title;
            dto.Description = emp.Description;

            Console.WriteLine(dto.Id + " " + dto.Name + " " + dto.Title + " " + dto.Description);

            Console.WriteLine("---------------------");
            Console.WriteLine("AutoMapper");

            var loggerFactory = LoggerFactory.Create(builder => { });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>();
            },loggerFactory);

            IMapper mapper = config.CreateMapper();

            var emp2 = new Employee
            {
                Id = 12,
                Name = "Name2",
                Title = "Title2",
                Description = "Description2"
            };

            var dto2 = mapper.Map<EmployeeDto>(emp2);

            Console.WriteLine(dto2.Id + " " + dto2.Name + " " + dto2.Title + " " + dto2.Description);

            Console.WriteLine("-------------------");
            Console.WriteLine("CarMapper");

            Car car = new Car();

            car.Id = 1;
            car.Name = "BMW";

            //mappimine algab pihta 
            CarsDto carsDto = new CarsDto();

            //mappimine on see, kus mõlema classi muutujad viiakse omavahel kokku 
            //protsess, kus muudetakse andmed ühest formaadist, struktuurist või
            //süsteemist teiseks

            //kasutatakse väärtustes ja muutmiste abil, et ühenduda andmebaasis
            //olevate tabelistega 
            carsDto.Id = car.Id;
            carsDto.Name = car.Name;

            Console.WriteLine(carsDto.Id + " " + carsDto.Name);
        }

        //tehke üks mappimine juurde ja teemaks on autod
        //peate kaks classi tegema nimega Car ja CarsDto

    }

    //Program.cs tegemist failiga, kus on Program class ja 
    //nüüd oleme lisanud juurde Employee classi
    //kindlasti tuleb järgida, et class ei oleks classi sees
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    //miks pannakse classi nimetuse taha dto?
    //dto tähendab data transfer object
    //neid classe kasutatakse andmete edastamiseks
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }

    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class CarsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
