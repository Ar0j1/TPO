using CalculatorTest;

namespace Lab7
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodadd()
        {
            double x = 3;
            double y = 4;
            double expected = 7;

            double received = Calc.add(x, y);

            Assert.AreEqual(expected, received);

        }

        [TestMethod]
        public void TestMethodsub()
        {
            double x = 7;
            double y = 2;
            double expected = 5;

            double received = Calc.sub(x, y);

            Assert.AreEqual(expected, received);

        }

        [TestMethod]
        public void TestMethodmult()
        {
            double x = 3;
            double y = 4;
            double expected = 12;

            double received = Calc.mult(x, y);

            Assert.AreEqual(expected, received);

        }
        [TestMethod]
        public void TestMethoddiv()
        {
            double x = 12;
            double y = 4;
            double expected = 3;

            double received = Calc.div(x, y);

            Assert.AreEqual(expected, received);

        }
        [TestMethod]
        
        public void TestMethodrow()
        {
            double x = 2;
            int y = 4;
            double expected = 16;

            double received = Calc.pow(x, y);

            Assert.AreEqual(expected, received);

        }
        [TestMethod]
        public void TestMethodzerostep()
        {
            double x = 12;
            int y = 0;
            double expected = 1;

            double received = Calc.pow(x, y);

            Assert.AreEqual(expected, received);

        }
        [TestMethod]
        public void TestMethodsqrt()
        {
            double x = 9;
            double expected = 3.0;
        
            double received = Calc.findSquareRoot(x);

            Assert.AreEqual(expected, received);

        }
      
        [TestMethod]
        public void TestMethoddivZero()
        {
            double x = 12;
            double y = 0;

            Assert.ThrowsException<DivideByZeroException>(()=> Calc.div(x, y));

        }
        [TestMethod]
        public void TestMethodsqrtNegNum()
        {
            double x = -1;
            double y = 0.01;

            Assert.ThrowsException<ArithmeticException>(() => Calc.findSquareRoot(x, y));

        }
    }
}