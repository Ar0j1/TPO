namespace CalculatorTest
{
    public class Calc
    {
        public static double add(double number1, double number2)
        {
            return number1 + number2;
        }

        public static double sub(double number1, double number2)
        {
            return number1 - number2;
        }

        public static double mult(double number1, double number2)
        {
            return number1 * number2;
        }

        public static double div(double number1, double number2)
        {
            if (number2 == 0)
            {
                throw new DivideByZeroException("Деление на ноль.");
            }
            return number1 / number2;
        }

        public static double pow(double number1, int degree)
        {
            if (degree == 0)
                return 1;
            double result = number1;
            for (int i = 1; i < degree; i++)
            {
                result *= number1;
            }
            return result;
        }

        public static double findSquareRoot(double number, double epsilon = 0.00001)
        {
            if (number < 0) throw new ArithmeticException("Число должно быть больше чем 0");

            if (number == 0) return 0;

            double approximation = number;
            double result = 0.5 * (approximation + number) / approximation;

            while (Math.Abs(result - approximation) > epsilon)
            {
                approximation = result;
                result = 0.5 * (approximation + number / approximation);
            }
            return result;
        }

    }
}