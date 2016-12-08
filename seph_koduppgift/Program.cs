using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using seph_koduppgift.Koduppgift;

namespace seph_koduppgift
{
    class Program
    {
        static void Main(string[] args)
        {
            bool weight;
            bool eco;
            string vehicleType;

            Logic logic = new Logic();

            Console.WriteLine("Welcome to Tullen");
            Console.WriteLine("Please answer with an 'e' and press 'enter' if the Vehicle is ECO");
            Console.WriteLine("Else press any key to continue");
            eco = logic.IsVehicleEco(Console.ReadLine());
            if (eco == false)
            {
                Console.WriteLine("Please enter the Weight of the Vehicle");
                weight = logic.IsVehicleHeavy(Convert.ToDouble(Console.ReadLine()));

                Console.WriteLine("What kind of Vehicle is it?");
                Console.WriteLine("1 for PB, 2 for LB, 3 for MC");
                vehicleType = logic.IsVehicleType(Console.ReadLine());
            }

            Console.ReadKey();
        }
    }
}
