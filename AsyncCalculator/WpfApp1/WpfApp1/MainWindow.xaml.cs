using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void ExpressionCalculate(object sender, RoutedEventArgs e)
        {
            var str = textBlock.Text;
            try
            {
                var sum = MathCalculate.CalculateExpression(str);
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
       

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "";

        }

    }

}
