using InheritanceAndServiceClass.Core.ServiceInterface;

namespace InheritanceAndServiceClass.AppServices.Services
{
    public class CarServices : ICarServices
    {
        public void GetData()
        {
            Console.WriteLine("Car Services");
        }
    }
}
