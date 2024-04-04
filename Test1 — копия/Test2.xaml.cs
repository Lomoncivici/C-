using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace Test1
{
    public partial class Test2 : Window
    {
        public Test2(object a, int ball, bool gg)
        {
            InitializeComponent();

            if (gg == true)
            {
                Ball.Text = ball.ToString();
                Ball.Visibility = Visibility.Visible;
            }

            switch (a)
            {
                default:
                    PageFrame.Content = new Page1();
                    break;
                case 2:
                    PageFrame.Content = new Page2();
                    break;
                case 3:
                    PageFrame.Content = new Page3();
                    break;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var authWindow = new MainWindow();
            authWindow.Show();
            Close();
        }
    }
}
