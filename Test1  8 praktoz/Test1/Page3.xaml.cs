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
using Test1.TesterDataSetTableAdapters;

namespace Test1
{
    public partial class Page3 : Page
    {
        QuestionTableAdapter question = new QuestionTableAdapter();
        public Page3()
        {
            InitializeComponent();

            var morg = question.GetData().Rows;

            Vopros.Text = morg[2][1].ToString();
            Note.Text = morg[2][2].ToString();

            Var1.Content = morg[2][3].ToString();
            Var2.Content = morg[2][4].ToString();
            Var3.Content = morg[2][5].ToString();
        }

        private void Var1_Click(object sender, RoutedEventArgs e)
        {
            var morg = question.GetData().Rows;
            if (morg[2][6].ToString() == Var1.Content)
            {
                Test2 new_Бред_бредовый = new Test2(3, +1, true);
                new_Бред_бредовый.Show();
            }
            else
            {
                Test2 new_Бред_бредовый = new Test2(3, +0, true);
                new_Бред_бредовый.Show();
            }
        }

        private void Var2_Click(object sender, RoutedEventArgs e)
        {
            var morg = question.GetData().Rows;
            if (morg[2][6].ToString() == Var2.Content)
            {
                Test2 new_Бред_бредовый = new Test2(3, +1, true);
                new_Бред_бредовый.Show();
            }
            else
            {
                Test2 new_Бред_бредовый = new Test2(3, +0, true);
                new_Бред_бредовый.Show();
            }
        }

        private void Var3_Click(object sender, RoutedEventArgs e)
        {
            var morg = question.GetData().Rows;
            if (morg[2][6].ToString() == Var3.Content)
            {
                Test2 new_Бред_бредовый = new Test2(3, +1, true);
                new_Бред_бредовый.Show();
            }
            else
            {
                Test2 new_Бред_бредовый = new Test2(3, +0, true);
                new_Бред_бредовый.Show();
            }
        }

        /*private void DA()
        {
            int a = 3;
            Test2 new_Бред_бредовый = new Test2(a);
        }*/
    }
}
