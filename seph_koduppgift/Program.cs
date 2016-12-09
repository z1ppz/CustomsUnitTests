using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using seph_koduppgift.Koduppgift;
using static System.Console;

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

            WriteLine("Welcome to Tullen");
            WriteLine("Please answer with an 'e' and press 'enter' if the Vehicle is ECO");
            WriteLine("Else press any key to continue");
            eco = logic.IsVehicleEco(ReadLine());
            if (eco == false)
            {
                try
                {
                    WriteLine("Please enter the Weight of the Vehicle");
                    weight = logic.IsVehicleHeavy(Convert.ToDouble(ReadLine()));
                }
                catch { }
                WriteLine("What kind of Vehicle is it?");
                WriteLine("1 for PB, 2 for LB, 3 for MC");
                vehicleType = logic.IsVehicleType(ReadLine());
            }

            ReadKey();
        }
    }
}
