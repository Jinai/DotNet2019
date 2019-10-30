using Microsoft.VisualStudio.TestTools.UnitTesting;
using Calculator;
using System;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        [DataTestMethod]
        [DataRow(1, 1, Operator.Add, 2)]
        [DataRow(1.5, 1.5, Operator.Add, 3)]
        [DataRow(2.6, 3.5, Operator.Add, 6.1)]
        [DataRow(1, 1, Operator.Sub, 0)]
        [DataRow(1.5, 0.5, Operator.Add, 2)]
        [DataRow(2, 2, Operator.Mul, 4)]
        [DataRow(100, 100, Operator.Mul, 10000)]
        [DataRow(0, 10, Operator.Div, 0)]
        [DataRow(1, 3, Operator.Div, 1.0 / 3)]
        public void TestCompute(double LeftOperand, double RightOperand, Operator Operator, double Result)
        {
            var sut = Calculator.Calculator.Compute(LeftOperand, RightOperand, Operator);
            Assert.AreEqual(Result, sut);
        }

        [TestMethod]
        public void TestDivisionByZero()
        {
            try
            {
                Calculator.Calculator.Compute(1, 0, Operator.Div);
                Assert.Fail();
            }
            catch (DivideByZeroException)
            {
                // Expected exception
            }
        }

        [TestMethod]
        public void TestOverflowAndUnderflow()
        {
            try
            {
                Calculator.Calculator.Compute(Double.MaxValue, Double.MaxValue, Operator.Add);
                Assert.Fail();
            }
            catch (ArithmeticException)
            {
                // Expected exception
            }

            try
            {
                Calculator.Calculator.Compute(Double.MinValue, Double.MaxValue, Operator.Sub);
                Assert.Fail();
            }
            catch (ArithmeticException)
            {
                // Expected exception
            }

            try
            {
                Calculator.Calculator.Compute(Double.MaxValue, Double.MaxValue, Operator.Mul);
                Assert.Fail();
            }
            catch (ArithmeticException)
            {
                // Expected exception
            }

            try
            {
                Calculator.Calculator.Compute(Double.MaxValue, 0, Operator.Div);
                Assert.Fail();
            }
            catch (ArithmeticException)
            {
                // Expected exception
            }
        }
    }
}
