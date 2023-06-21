using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.ViewModel
{
    public partial class StudentListViewModel : ObservableObject
    {
        [ICommand]
        public async void AddStudent()
        {
            await AppShell.Current.GoToAsync(nameof(App01.View.AddStudent));
        }

    }
}
