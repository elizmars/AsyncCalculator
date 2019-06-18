using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfApp1
{
    static class MathCalculate
    {
        private delegate double PairAction(double first, double second);
        
        public static double CalculateExpression(string expression)
        {
            var expressionParts = expression.Split('+');
            if (expressionParts.Count() > 1)
            {
                return Addition(expressionParts);
            }

            expressionParts = expression.Split('-');
            if (expressionParts.Count() > 1)
            {
                return Addition(expressionParts);
            }

            expressionParts = expression.Split('*');
            if (expressionParts.Count() > 1)
            {
                return Multiplication(expressionParts);
            }

            expressionParts = expression.Split('/');
            if (expressionParts.Count() > 1)
            {
                return Segmentation(expressionParts);
            }

            expressionParts = expression.Split('^');
            if (expressionParts.Count() > 1)
            {
                return Extent(expressionParts);
            }

            if (expression.IndexOf("sin(") >= 0)
            {
                var tmp = expression.Substring(4, expression.Length - 4);
                tmp = tmp.Substring(0, tmp.Length - 1);
                return Math.Sin(CalculateExpression(tmp));
            }

            if (expression.IndexOf("cos(") >= 0)
            {
                var tmp = expression.Substring(4, expression.Length - 4);
                tmp = tmp.Substring(0, tmp.Length - 1);
                return Math.Cos(CalculateExpression(tmp));
            }

            if (expression.IndexOf("atan(") >= 0)
            {
                var tmp = expression.Substring(5, expression.Length - 5);
                tmp = tmp.Substring(0, tmp.Length - 1);
                return Math.Atan(CalculateExpression(tmp));
            }

            if (expression.IndexOf("tan(") >= 0)
            {
                var tmp = expression.Substring(4, expression.Length - 4);
                tmp = tmp.Substring(0, tmp.Length - 1);
                return Math.Tan(CalculateExpression(tmp));

            }
            return Double.Parse(expression);
        }

        private static double CalculatesExpressionForPairsOperations(string expression, char operatorSimbol, PairAction action)
        {
            return null;
        }

        private static double Addition(string[] substr)
        {
            double addition = 0;
            foreach (var parstr in substr)
            {
                addition += CalculateExpression(parstr);
            }

            return addition;
        }

        private static double Multiplication(string[] substr)
        {
            double multi = 1;
            foreach (var parstr in substr)
            {
                multi *= CalculateExpression(parstr);
            }

            return multi;
        }

        private static double Segmentation(string[] substr)
        {
            double segmen = CalculateExpression(substr[0]);
            for (int i = 1; i < substr.Length; i++)
            {
                segmen /= CalculateExpression(substr[i]);
            }

            return segmen;
        }

        private static double Subtraction(string[] substr)
        {
            double min = CalculateExpression(substr[0]);
            for (int i = 1; i < substr.Length; i++)
            {
                min -= CalculateExpression(substr[i]);
            }

            return min;
        }

        private static double Extent(string[] substr)
        {
            double extent = CalculateExpression(substr[0]);
            for (int i = 1; i < substr.Length; i++)
            {
                extent = Math.Pow(extent, CalculateExpression(substr[i]));
            }

            return extent;
        }


    }
}
