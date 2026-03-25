namespace Inheritance2
{
    class Lake : Water
    {
        //tehke sama asi, mis River-ga ja kutsuge see Program classi Main meetodis esile

        public override void DoSomething()
        {
            Console.WriteLine("Lake method, and it has " + Flow + " and " + Length + " is in meters");
        }
    }
}
