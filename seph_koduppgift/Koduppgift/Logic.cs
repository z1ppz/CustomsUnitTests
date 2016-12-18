using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace seph_koduppgift.Koduppgift
{
    public class Logic
    {
        public enum VehicleType
        {
            PB,
            LB,
            MC
        }
        private double Weight;
        private bool Eco;
        public DateTime localDate { get; set; }
        public double Price { get; set; }


        public bool IsVehicleHeavy(double weight)
        {
            bool result = false;
            try
            {
                Weight = weight;
                if (weight != 0)
                {
                    var treshold = 1000;
                    if (weight <= treshold)
                        result = false;
                    else
                        result = true;
                }
                if (result == false)
                    Price = 500;
                else
                    Price = 1000;
                return result;
            }
            catch { }
            return result;
        }

        public bool IsVehicleEco(string answer)
        {
            bool result = false;
            try
            {
                if (!string.IsNullOrEmpty(answer))
                {
                    if (answer.ToLower().Trim() == "e")
                        result = true;
                    else
                        result = false;
                }
                if (result == true)
                {
                    Price = 0;
                    Write();
                }
                Eco = result;
                return result;
            }
            catch { }
            return result;
        }

        public string IsVehicleType(string answer)
        {
            try
            {
                if (answer != null)
                {
                    if (answer == "1")
                    {
                        Today();
                        Write();
                    }
                    else if (answer == "2")
                    {
                        Price = 2000;
                        Today();
                        Write();
                    }
                    else if (answer == "3")
                    {
                        Today();
                        Price = Price * 0.7;
                        Write();
                    }
                    switch (answer)
                    {
                        case "1": return Convert.ToString(VehicleType.PB);
                        case "2": return Convert.ToString(VehicleType.LB);
                        case "3": return Convert.ToString(VehicleType.MC);
                        default: WriteLine("Invalid selection. Please select 1, 2, or 3."); break;
                    }
                }
                return answer;
            }
            catch { }
            return null;
        }

        public class Holidays
        {
            public string Day;
            public DateTime Date;
        }

        public void Today()
        {
            try
            {
                if (Convert.ToString(localDate).Equals("0001-01-01 00:00:00"))
                    localDate = DateTime.Now;

                var holidays = new List<Holidays>();

                holidays.Add(new Holidays() { Day = "Nyårsdagen", Date = new DateTime(localDate.Year, 01, 01) });
                holidays.Add(new Holidays() { Day = "Trettondedag jul", Date = new DateTime(localDate.Year, 01, 06) });
                holidays.Add(new Holidays() { Day = "Långfredag", Date = new DateTime(localDate.Year, 03, 25) });
                holidays.Add(new Holidays() { Day = "Påskdagen", Date = new DateTime(localDate.Year, 03, 27) });
                holidays.Add(new Holidays() { Day = "Annandag påsk", Date = new DateTime(localDate.Year, 03, 28) });
                holidays.Add(new Holidays() { Day = "Valborg - Fösta maj", Date = new DateTime(localDate.Year, 05, 01) });
                holidays.Add(new Holidays() { Day = "Kristi himmelsfärdsdag", Date = new DateTime(localDate.Year, 05, 05) });
                holidays.Add(new Holidays() { Day = "Pingstdagen", Date = new DateTime(localDate.Year, 05, 15) });
                holidays.Add(new Holidays() { Day = "Sveriges nationaldag", Date = new DateTime(localDate.Year, 06, 06) });
                holidays.Add(new Holidays() { Day = "Midsommardagen", Date = new DateTime(localDate.Year, 06, 25) });
                holidays.Add(new Holidays() { Day = "Alla helgons dag", Date = new DateTime(localDate.Year, 11, 05) });
                holidays.Add(new Holidays() { Day = "Juldagen", Date = new DateTime(localDate.Year, 12, 25) });
                holidays.Add(new Holidays() { Day = "Annandag jul", Date = new DateTime(localDate.Year, 12, 26) });

                var redDay = holidays.Where(x => x.Date.DayOfYear.Equals(localDate.DayOfYear))?.FirstOrDefault();

                if (localDate.Hour >= 18 || localDate.Hour <= 06)
                {
                    if (localDate.DayOfWeek == DayOfWeek.Saturday || localDate.DayOfWeek == DayOfWeek.Sunday || localDate.DayOfYear.Equals(redDay?.Date.DayOfYear))
                        Price = Price * 2;
                    else
                        Price = Price / 2;
                }
                else if (localDate.DayOfWeek == DayOfWeek.Saturday || localDate.DayOfWeek == DayOfWeek.Sunday || localDate.DayOfYear.Equals(redDay?.Date.DayOfYear))
                    Price = Price * 2;
                else
                    Price = Price;
            }
            catch { }
        }


        public void Write()
        {
            WriteLine("The price will be: {0}", Price);
            WriteLine("Welcome to Håkan Hällström landet!");
        }
    }
}
