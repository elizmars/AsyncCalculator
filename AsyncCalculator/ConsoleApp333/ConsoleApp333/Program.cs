using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp333
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "sin(2)+6";
           

            var sum = Calculate(str);
            Console.WriteLine(sum);
            Console.ReadLine();

        }

        private static double Calculate(string str)
        {
            var substr = str.Split('+');
            if (substr.Count() > 1)
            {
                return Addition(substr);
            }
            substr = str.Split('-');
            if (substr.Count() > 1)
            {
                return Subtraction(substr);
            }

            substr = str.Split('*');
            if (substr.Count() > 1)
            {
                return Multiplication(substr);
            }

            substr = str.Split('/');
            if (substr.Count() > 1)
            {
                return Segmentation(substr);
            }

           

            substr = str.Split('^');
            if (substr.Count() > 1)
            {
                return Extent(substr);
            }

            
            if (str.IndexOf("sin(") >= 0)
            {
                var tmp = str.Substring(4, str.Length - 4);
                tmp = tmp.Substring(0, tmp.Length -1);
                return Math.Sin(Calculate(tmp));
                
            }

            if (str.IndexOf("cos(") >= 0)
            {
                var tmp = str.Substring(4, str.Length - 4);
                tmp = tmp.Substring(0, tmp.Length - 1);
                return Math.Cos(Calculate(tmp));

            }

            if (str.IndexOf("atan(") >= 0)
            {
                var tmp = str.Substring(5, str.Length - 5);
                tmp = tmp.Substring(0, tmp.Length - 1);
                return Math.Atan(Calculate(tmp));

            }

            if (str.IndexOf("tan(") >= 0)
            {
                var tmp = str.Substring(4, str.Length - 4);
                tmp = tmp.Substring(0, tmp.Length - 1);
                return Math.Tan(Calculate(tmp));

            }





            return Double.Parse(str);

        }

        private static double Addition(string[] substr)
        {
            double addition = 0;
            foreach (var parstr in substr)
            {
                addition += Calculate(parstr);
            }

            return addition;
        }
        private static double Multiplication(string[] substr)
        {
            double multi = 1;
            foreach (var parstr in substr)
            {
                multi *= Calculate(parstr);
            }

            return multi;
        }
        private static double Segmentation(string[] substr)
        {
            double segmen = Calculate(substr[0]);
            for (int i = 1; i < substr.Length; i++)
            {
                segmen /= Calculate(substr[i]);
            }

            return segmen;
        }
        private static double Subtraction(string[] substr)
        {
            double min = Calculate(substr[0]);
            for (int i = 1; i < substr.Length; i++)
            {
                min -= Calculate(substr[i]);
            }

            return min;
        }
       private static double Extent(string[] substr)
        {
            double extent = Calculate(substr[0]);
            for (int i = 1; i < substr.Length; i++)
            {
                extent = Math.Pow(extent, Calculate(substr[i]));
            }

            return extent;
        }
    }
}
