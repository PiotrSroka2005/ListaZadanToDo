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
        
    }
}