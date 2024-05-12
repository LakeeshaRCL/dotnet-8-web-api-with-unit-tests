using DotnetWebApiUnitTesting.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    public class ArithmeticHelperTest
    {
        private ArithmeticHelper arithmeticHelper;

        public ArithmeticHelperTest()
        {
            this.arithmeticHelper = new ArithmeticHelper();
        }


        [Fact(DisplayName = "Add numbers should return double type output")]
        public void TestAddShouldReturnDouble() {

            // 1. Arrange
            List<double> numbers = new List<double> { 5.6, 10.3, -6.2};
            
            // 2. Act
            var result = arithmeticHelper.Add(numbers);

            // 3. Assert
            // test return type
            Assert.IsType<double>(result);

            // test result
            Assert.Equal(9.7, result);

        }



        [Theory(DisplayName = "Subtract should return double type output")]
        [InlineData(8.45, 10.96)]
        public void TestSubtractShouldReturnDouble(double number1, double number2)
        {
            // 1. Arrange

            // 2. Act
            var result = arithmeticHelper.Subtract(number1, number2);

            // 3. Assert
            // test return type
            Assert.IsType<double>(result);

            // test result
            double expected = number1 - number2;
            Assert.Equal(expected, result);
        } 
    }
}
