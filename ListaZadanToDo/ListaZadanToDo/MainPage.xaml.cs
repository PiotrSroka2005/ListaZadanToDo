using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListaZadanToDo
{
    public partial class MainPage : ContentPage
    {
        List<TaskModel> tasks = new List<TaskModel>();
        public MainPage()
        {
            InitializeComponent();
            tasks = JsonConnection.GetFromFile();
            TasksList.ItemsSource = tasks;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            tasks = JsonConnection.GetFromFile();
            TasksList.ItemsSource = tasks;
        }
        
    }
}
