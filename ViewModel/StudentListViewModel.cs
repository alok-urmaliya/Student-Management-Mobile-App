using App01.Model;
using App01.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App01.ViewModel
{
    public partial class StudentListViewModel : ObservableObject
    {
        private readonly IStudentService _studentService;

        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public StudentListViewModel(IStudentService studentService) 
        {
            _studentService = studentService;
        }

        [ICommand]
        public void GetStudentList()
        {
            var studentList = _studentService.GetStudents();
            if(studentList?.Count > 0)
            {
                Students.Clear();
                foreach (var student in studentList) 
                {
                    Students.Add(student);
                }
            }
        }

        [ICommand]
        public async void AddStudentButton()
        {
            await AppShell.Current.GoToAsync(nameof(App01.View.AddStudent));
        }

    }
}
