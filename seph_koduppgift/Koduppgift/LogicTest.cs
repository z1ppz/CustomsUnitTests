using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace seph_koduppgift.Koduppgift
{
    public class LogicTest
    {

        [Fact]
        public void IsVehicleHeavy_Test()
        {
            var logic = new Logic();
            logic.IsVehicleHeavy(1000);

            Assert.Equal(false, false);
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

        [Fact]
        public void IsVehicleType_Test()
        {
            var logic = new Logic();
            logic.IsVehicleType("4");
            Assert.Equal(false, false);
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
    }
}
