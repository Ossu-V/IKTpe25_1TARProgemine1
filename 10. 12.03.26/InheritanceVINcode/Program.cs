namespace InheritanceVINcode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Sisesta VIN kood: ");
            //Teha pärilus
            //on olemas class nimega Machine
            //see pärib Cars classi
            //Saab sisestada masina numbri
            //konsool annab vastuse: Edukalt sisestatud
            // VIN kood: VIN koodi nr

            int vinCode = Convert.ToInt32(Console.ReadLine());

            Machine machine = new Machine();
            machine.SetVinCode(vinCode);

            Console.WriteLine("Edukalt sisestatud");
            Console.WriteLine("VIN kood on: {0}", machine.GetVinCode());
        }
    }
    class Car
    {
        public void SetVinCode(int vinCode)
        {
            vin = vinCode;
        }
        protected int vin;
    }

    class Machine : Car
    {
        public int GetVinCode()
        {
            return vin;
        }
    }
}
