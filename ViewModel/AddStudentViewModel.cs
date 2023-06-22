using App01.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.ViewModel
{
    public partial class AddStudentViewModel : ObservableObject
    {
        private readonly IStudentService _studentservice;
        public AddStudentViewModel(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }

        [ObservableProperty]
        private string _firstName;

        [ObservableProperty]
        private string _lastName;

        [ObservableProperty]
        private string _email;

        [ICommand]
        public async void AddStudentDb()
        {
            var response = await _studentservice.AddStudent(new Model.Student
            { 
                Firstname = _firstName,
                Lastname = _lastName,
                email = _email
            });

            if(response > 0)
            {
                await Shell.Current.DisplayAlert("Record Added", "Record Added to the students list", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not Added", "Something went wrong while adding the record", "Bad Request");
            }
        }
    }
}
