using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void ButtonClickAddText(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            textBlock.Text += button.Content;
        }

        /* private void Button_Click(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "1";
         }

         private void Button_Click_1(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "2";
         }

         private void Button_Click_2(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "3";
         }

         private void Button_Click_3(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "4";
         }

         private void Button_Click_4(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "5";
         }

         private void Button_Click_5(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "6";
         }

         private void Button_Click_6(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "7";
         }

         private void Button_Click_7(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "8";
         }

         private void Button_Click_8(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "9";
         }

         private void Button_Click_9(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "0";
         }

         private void Button_Click_10(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "+";
         }

         private void Button_Click_11(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "-";
         }

         private void Button_Click_12(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "*";
         }

         private void Button_Click_13(object sender, RoutedEventArgs e)
         {
             textBlock.Text += "/";
         }*/


     


        private void ExpressionCalculate(object sender, RoutedEventArgs e)
        {
            

            var str = textBlock.Text;
            try
            {
                var sum = Calculate(str);
                textBlock1.Text = sum.ToString();
            }
            catch
            {
                if (textBlock1 != null)
                {
                    textBlock1.Text = "Parse error";
                }
            }
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
                tmp = tmp.Substring(0, tmp.Length - 1);
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


        private void Button_Click_15(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "";

        }


        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            textBlock.Text += "sin";
        }

        private void Button_Click_17(object sender, RoutedEventArgs e)
        {
            textBlock.Text += "cos";
        }

        private void Button_Click_18(object sender, RoutedEventArgs e)
        {
            textBlock.Text += "tan";
        }

        private void Button_Click_19(object sender, RoutedEventArgs e)
        {
            textBlock.Text += "atan";
        }
    }

}
