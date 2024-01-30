using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ListaZadanToDo
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddOrEditPage : ContentPage
    {
        List<TaskModel> list;
        TaskModel taskModel;
        public AddOrEditPage(List<TaskModel> _list)
        {
            InitializeComponent();
            list = _list;
        }

        public AddOrEditPage(List<TaskModel> list, TaskModel model)
        {
            InitializeComponent();
            this.list = list;
            taskModel = model;
            TitleEntry.Text = taskModel.Title;
            IsImportant.IsChecked = taskModel.Importance == "" ? false : true;

            Add.Clicked -= Add_Clicked;
            Add.Clicked += Edit_Clicked;
            Add.Text = "Edytuj";
            Add.BackgroundColor = Color.Aqua;
            Title = "Edit Page";
        }


        private async void Add_Clicked(object sender, EventArgs e)
        {
            TaskModel task = new TaskModel();
            task.ID = Guid.NewGuid();
            task.Title = TitleEntry.Text;
            if (IsImportant.IsChecked)
                task.Importance = "Ważne";
            else
                task.Importance = "";
            list.Add(task);

            JsonConnection.WriteToFile(list);
            await Navigation.PopToRootAsync();
        }

        private async void Edit_Clicked(object sender, EventArgs e)
        {
            taskModel.Title = TitleEntry.Text;
            if (IsImportant.IsChecked)
                taskModel.Importance = "Ważne";
            else
                taskModel.Importance = "";

            JsonConnection.WriteToFile(list);
            await Navigation.PopToRootAsync();

        }

    }
}