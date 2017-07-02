using System;

namespace Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            var hq = new Hq();

            for(var i=0;i< 10; i++)
            {
                hq.CheckAgents();
            }

            Console.WriteLine(hq.GetTotalIntel());
        }
    }
}