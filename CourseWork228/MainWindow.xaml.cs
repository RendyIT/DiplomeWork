using CourseWorkProgram.Classes;
using FireSharp;
using System;
using System.ComponentModel;
using System.Windows;
using FireSharp.Response;
using Newtonsoft.Json;
using CourseWork228;
using System.Linq.Expressions;

namespace CourseWorkProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window

    {
        FireBase Base = new FireBase();
        string PATH;
        private BindingList<Worker> dgList;
        private BindingList<Student> bdList;
        private BindingList<Worker> pupaList;

        public MainWindow()
        {
            InitializeComponent();
            Access();
            ListLoad();
        }
        void Access()
        {
            Base.client = new FirebaseClient(Base.config);
        }
        void ListLoad()
        {
            
            FirebaseResponse response = Base.client.Get(@"Workers");
            dgList = JsonConvert.DeserializeObject<BindingList<Worker>>(response.Body);
            response = Base.client.Get(@"Students");
            bdList = JsonConvert.DeserializeObject<BindingList<Student>>(response.Body);
        }

        private void AD_SelectionChanged(object sender, RoutedEventArgs e)
        {
            switch (AD.SelectedIndex)
            {
                case 0:
                    List.ItemsSource = pupaList;
                    List.ItemsSource = dgList;
                    break;
                case 1:
                    List.ItemsSource = pupaList;
                    List.ItemsSource = bdList;
                    break;
            }
        }
        void DeleteList()
        {
            Base.client.Delete($"Students/{List.SelectedIndex}");
            Base.client.Delete($"Workers/{List.SelectedIndex}");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            AddElements addelements = new AddElements();
            addelements.Show();
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            ListLoad();
        }
        private void Info_Click(object sender,RoutedEventArgs e)
        {
            Info info = new Info();
            info.Show();
        }
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            DeleteList();
        }
    }
    }
