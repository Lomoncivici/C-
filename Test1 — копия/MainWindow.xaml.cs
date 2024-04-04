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

namespace Test1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PassTest_Click(object sender, RoutedEventArgs e)
        {
            var authWindow = new Test2(null,0,false);
            authWindow.Show();
            Close();
        }

        private void EditTest_Click(object sender, RoutedEventArgs e)
        {
            switch (TextPassword.Visibility)
            {
                case Visibility.Visible:
                    if (TextPassword.Text == "12345")
                    {
                        TextPassword.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFABADB3"));
                        var authWindow = new Redactor();
                        authWindow.Show();
                        Close();
                    }
                    else
                    {
                        TextPassword.BorderBrush = new SolidColorBrush(Colors.Red);
                    }
                    break;

                case Visibility.Hidden:
                    TextPassword.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
