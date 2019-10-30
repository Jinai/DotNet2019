using System;

namespace Calculator
{
    public class Calculator
    {
        public static double Compute(double leftOperand, double rightOperand, Operator opt)
        {
            // Pattern "Switch expressions" en C# 8.0
            return opt switch
            {
                Operator.Add => Addition(leftOperand, rightOperand),
                Operator.Sub => Subtraction(leftOperand, rightOperand),
                Operator.Mul => Multiplication(leftOperand, rightOperand),
                Operator.Div => Division(leftOperand, rightOperand),
                _ => throw new ArgumentException($"Unknown operator '{opt}'."),
            };


            // Équivalent avec switch classique :
            //
            // switch (opt)
            // {
            //     case Operator.Add:
            //         return Addition(leftOperand, rightOperand);
            //     case Operator.Sub:
            //         return Subtraction(leftOperand, rightOperand);
            //     case Operator.Mul:
            //         return Multiplication(leftOperand, rightOperand);
            //     case Operator.Div:
            //         return Division(leftOperand, rightOperand);
            //     default:
            //         throw new ArgumentException($"Unknown operator '{opt}'.");
            // }

        }

        public static double Addition(double leftOperand, double rightOperand)
        {
            var result = leftOperand + rightOperand;
            if (Double.IsInfinity(result))
                throw new ArithmeticException();

            return result;
        }

        public static double Subtraction(double leftOperand, double rightOperand)
        {
            var result = leftOperand - rightOperand;
            if (Double.IsInfinity(result))
                throw new ArithmeticException();

            return result;
        }

        public static double Multiplication(double leftOperand, double rightOperand)
        {
            var result = leftOperand * rightOperand;
            if (Double.IsInfinity(result))
                throw new ArithmeticException();

            return result;
        }

        public static double Division(double leftOperand, double rightOperand)
        {
            if (rightOperand == 0.0)
                throw new DivideByZeroException();

            var result = leftOperand / rightOperand;
            if (Double.IsInfinity(result))
                throw new ArithmeticException();

            return result;
        }
    }
}
