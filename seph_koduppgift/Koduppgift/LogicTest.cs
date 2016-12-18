using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace seph_koduppgift.Koduppgift
{
    public class LogicTest
    {
        [Theory]
        [InlineData("e", true)]
        [InlineData("E", true)]
        [InlineData("g", false)]
        [InlineData(" ", false)]
        [InlineData("1", false)]
        public void IsVehicleEco_Test_Cases(string input, bool expected)
        {
            var logic = new Logic();
            var actual = logic.IsVehicleEco(input);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void IsVehicleHeavy_None_Heavy_Test()
        {
            var logic = new Logic();
            var weight = logic.IsVehicleHeavy(1000);

            Assert.False(weight);
        }

        [Fact]
        public void IsVehicleHeavy_Heavy_Test()
        {
            var logic = new Logic();
            var weight = logic.IsVehicleHeavy(1001);

            Assert.True(weight);
        }

        [Theory]
        [InlineData(1000, false)]
        [InlineData(1001, true)]
        [InlineData(999, false)]
        [InlineData(10000, true)]
        public void IsVehicleHeavy_Test_Cases(double input, bool expected)
        {
            var logic = new Logic();
            var actual = logic.IsVehicleHeavy(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("1", "PB")]
        [InlineData("2", "LB")]
        [InlineData("3", "MC")]
        public void IsVehicleType_Test_Cases(string input, string expected)
        {
            var logic = new Logic();
            var actual = logic.IsVehicleType(input);

            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("2016-12-23 18:05:00", "1", "e")]
        public void IsVehicleType_Test_Price_Eco_Heavy_Weekday_Between_18_06_PB(string dateString, string type, string eco)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1001);
            logic.IsVehicleType(type);
            logic.IsVehicleEco(eco);
            var price = logic.Price;

            Assert.Equal(price, 0);
        }

        [Theory]
        [InlineData("2016-12-23 18:05:00", "1", " ")]
        public void IsVehicleType_Test_Price_None_Eco_Heavy_Weekday_Between_18_06_PB(string dateString, string type, string eco)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1001);
            logic.IsVehicleType(type);
            logic.IsVehicleEco(eco);
            var price = logic.Price;

            Assert.Equal(price, 500);
        }

        [Theory]
        [InlineData("2016-12-23 18:05:00", "1")]
        public void IsVehicleType_Test_Price_Heavy_Weekday_Between_18_06_PB(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1001);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 500);
        }

        [Theory]
        [InlineData("2016-12-23 18:05:00", "1")]
        public void IsVehicleType_Test_Price_None_Heavy_Weekday_Between_18_06_PB(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1000);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 250);
        }

        [Theory]
        [InlineData("2016-12-24 03:05:00", "1")]
        public void IsVehicleType_Test_Price_Heavy_Weekend_Between_18_06_PB(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1001);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 2000);
        }

        [Theory]
        [InlineData("2016-12-24 03:05:00", "1")]
        public void IsVehicleType_Test_Price_None_Heavy_Weekend_Between_18_06_PB(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1000);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 1000);
        }

        [Theory]
        [InlineData("2016-12-20 12:05:00", "2")]
        public void IsVehicleType_Test_Price_Weekday_LB(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 2000);
        }

        [Theory]
        [InlineData("2016-12-23 18:05:00", "2")]
        public void IsVehicleType_Test_Price_Weekday_Between_18_06_LB(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 1000);
        }

        [Theory]
        [InlineData("2016-12-24 18:05:00", "2")]
        public void IsVehicleType_Test_Price_Weekend_Between_18_06_LB_2(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 4000);
        }

        [Theory]
        [InlineData("2016-12-20 00:05:00", "3")]
        public void IsVehicleType_Test_Price_Heavy_Weekday_Between_18_06_MC(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1001);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 350);
        }

        [Theory]
        [InlineData("2016-12-20 00:05:00", "3")]
        public void IsVehicleType_Test_Price_None_Heavy_Weekday_Between_18_06_MC(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1000);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 175);
        }

        [Theory]
        [InlineData("2016-12-24 18:05:00", "3")]
        public void IsVehicleType_Test_Price_Heavy_Weekend_Between_18_06_MC(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1001);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 1400);
        }

        [Theory]
        [InlineData("2016-12-24 18:05:00", "3")]
        public void IsVehicleType_Test_Price_None_Heavy_Weekend_Between_18_06_MC(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1000);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 700);
        }

        [Theory]
        [InlineData("2016-12-25 18:05:00", "1")]
        public void IsVehicleType_Test_Price_Holiday_Christmas_PB(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1001);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 2000);
        }

        [Theory]
        [InlineData("2016-12-25 05:55:00", "2")]
        public void IsVehicleType_Test_Price_Holiday_Christmas_LB(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1001);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 4000);
        }

        [Theory]
        [InlineData("2016-12-25 10:00:00", "3")]
        public void IsVehicleType_Test_Price_Holiday_Christmas_MC(string dateString, string type)
        {
            var logic = new Logic();
            logic.localDate = DateTime.Parse(dateString, CultureInfo.InvariantCulture, DateTimeStyles.None);
            var weight = logic.IsVehicleHeavy(1001);
            logic.IsVehicleType(type);
            var price = logic.Price;

            Assert.Equal(price, 1400);
        }
    }
}

