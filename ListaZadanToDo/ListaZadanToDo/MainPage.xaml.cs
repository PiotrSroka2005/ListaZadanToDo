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
        
        private void Delete_Clicked(object sender, EventArgs e)
        {
            if (TasksList.SelectedItem is TaskModel model)
            {
                tasks.Remove(model);
                JsonConnection.WriteToFile(tasks);
                tasks = JsonConnection.GetFromFile();
                TasksList.ItemsSource = tasks;
            }
        }

        //private void Add_Clicked(object sender, EventArgs e)
        //{
        //    Navigation.PushAsync(new AddEditPage(tasks));
        //}


        //private void Edit_Clicked(object sender, EventArgs e)
        //{
        //    if (TasksList.SelectedItem is TaskModel model)
        //        Navigation.PushAsync(new AddEditPage(tasks, model));
        //}

    }
}
