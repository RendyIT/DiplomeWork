using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using CourseWorkProgram.Classes;
using FireSharp;

namespace CourseWorkProgram
{
    /// <summary>
    /// Логика взаимодействия для AddElements.xaml
    /// </summary>
    public partial class AddElements : Window
    {
        string PATH;
        FireBase Base = new FireBase();
        public AddElements()
        {
            InitializeComponent();
            Base.client = new FirebaseClient(Base.config);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            switch (pressed.Name)
            {
                case "Workers":
                    PATH = "Workers";
                    break;
                case "Students":
                    PATH = "Students";
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(PATH == "Workers" )
            {
                Worker m = new Worker { Id1 = tb1.Text, Name1 = tb2.Text, Surnname1 = tb3.Text, PayDay = tb4.Text };
                var setter = Base.client.Set($"{PATH}/"+Convert.ToInt32(tb5.Text),m);
                MessageBox.Show("Успешно добавлен рабочий!");

            }
            else if(PATH == "Students")
            {
                Student m = new Student { Id1 = tb1.Text, Name1 = tb2.Text, Surnname = tb3.Text, PayDay = tb4.Text };
                var setter = Base.client.Set($"{PATH}/" + Convert.ToInt32(tb5.Text),m);
                MessageBox.Show("Успешно добавлен студент!");

            }
        }
    }
 }
