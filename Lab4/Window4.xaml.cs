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
using System.Windows.Shapes;

namespace Lab4
{
    /// <summary>
    /// Логика взаимодействия для Window4.xaml
    /// </summary>
    public partial class Window4 : Window
    {
        public Window4()
        {
            InitializeComponent();
        }

        private void Convert(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Input.Text, out double pounds))
            {
                double kilograms = pounds * 0.453592;
                KG.Content = $"{kilograms} кг";
            }
            else
            {
                MessageBox.Show("Введіть коректне число.");
            }
        }
    }
}
