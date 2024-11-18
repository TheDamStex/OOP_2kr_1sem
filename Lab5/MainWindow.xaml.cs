using System;
using System.Collections.Generic;
using System.Data;
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

namespace Lab5
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
        private void Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            string content = button.Content.ToString();

            switch (content)
            {
                case "CE":
                    Input.Clear();
                    Result.Clear();
                    break;
                case "C":
                    if (Input.Text.Length > 0)
                        Input.Text = Input.Text.Substring(0, Input.Text.Length - 1);
                    break;
                case "=":
                    try
                    {
                        string expression = Input.Text;
                        var result = new DataTable().Compute(expression, null);
                        Result.Text = result.ToString();
                    }
                    catch
                    {
                        Result.Text = "Error";
                    }
                    break;
                default:
                    Input.Text += content;
                    break;
            }
        }
    }
}




