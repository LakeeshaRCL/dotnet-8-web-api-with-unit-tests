namespace DotnetWebApiUnitTesting.Helpers
{
    public class ArithmeticHelper
    {
        public int Add(List<double> numbers)
        {
            double result = 0;
            foreach (var number in numbers)
            {
                result += number;
            }

            return (int)result;
        }


        public double Subtract(double number1, double number2)
        {
            return number1 - number2;
        }
    }
}
