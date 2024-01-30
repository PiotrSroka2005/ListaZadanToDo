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

    }
}