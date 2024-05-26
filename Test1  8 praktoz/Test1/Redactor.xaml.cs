using System.Security.Policy;
using System;
using System.Security.Principal;
using System.Windows;
using Test1.TesterDataSetTableAdapters;
using System.Data;
using System.Windows.Controls;

namespace Test1
{
    public partial class Redactor : Window
    {
        QuestionTableAdapter question = new QuestionTableAdapter();
        OtvetTableAdapter otvet = new OtvetTableAdapter();
        public Redactor()
        {
            InitializeComponent();
            Redactor12.ItemsSource = question.GetMain();

            Otv.ItemsSource = otvet.GetData();
            Otv.DisplayMemberPath = "OtvetName";
        }

        private void WindDead(object sender, RoutedEventArgs e)
        {
            DA();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (Redactor12.SelectedItem as DataRowView != null)
            {
                object id = (Redactor12.SelectedItem as DataRowView).Row[0];

                question.DeleteQuery(Convert.ToInt32(id));
                Redactor12.ItemsSource = question.GetData();
                DA();
            }
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            /*if (Redactor12.SelectedItem as DataRowView != null)
            {
                object id = (Redactor12.SelectedItem as DataRowView).Row[0];
                GG.UpdateQuery(id);
                Redactor12.ItemsSource = GG.GetMain();
                Redactor12.Columns[0].Visibility = Visibility.Collapsed;
                Redactor12.Columns[1].Visibility = Visibility.Collapsed;
                Redactor12.Columns[2].Visibility = Visibility.Collapsed;
            }*/
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            object otv = (Otv.SelectedItem as DataRowView).Row[0];

            question.InsertQuery(Vopros.Text, Note.Text, Var1.Text, Var2.Text, Var3.Text, Convert.ToInt32(otv));
            Redactor12.ItemsSource = question.GetMain();
            DA();
        }

        private void DA()
        {
            Redactor12.Columns[0].Visibility = Visibility.Collapsed;
            Redactor12.Columns[1].Visibility = Visibility.Collapsed;
            Redactor12.Columns[2].Visibility = Visibility.Collapsed;
            Redactor12.Columns[3].Visibility = Visibility.Collapsed;
            Redactor12.Columns[4].Visibility = Visibility.Collapsed;
            Redactor12.Columns[5].Visibility = Visibility.Collapsed;
            Redactor12.Columns[6].Visibility = Visibility.Collapsed;
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            var authWindow = new Test2(null, 0, false);
            authWindow.Show();
        }
    }
}
