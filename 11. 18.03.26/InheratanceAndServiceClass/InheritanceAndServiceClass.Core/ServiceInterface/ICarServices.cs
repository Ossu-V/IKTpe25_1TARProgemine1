namespace InheritanceAndServiceClass.Core.ServiceInterface
{
    public interface ICarServices
    {
        void GetData();

        void PostData()
        {
            Console.WriteLine("Andmed on edukalt salvestatud");
        }

        void PutData()
        {
            Console.WriteLine("Andmed on edukalt uuendatud");
        }

        void DeleteData()
        {
            Console.WriteLine("Andmed on edukalt kustutatud");
        }
    }
}
