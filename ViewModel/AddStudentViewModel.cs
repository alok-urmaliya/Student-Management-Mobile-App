using App01.Model;
using App01.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace App01.ViewModel
{
    [QueryProperty(nameof(StudentDetail),"StudentDetail")]
    public partial class AddStudentViewModel : ObservableObject
    {
        [ObservableProperty]
        public Student _studentDetail = new Student();
        private readonly IStudentService _studentservice;
        public AddStudentViewModel(IStudentService studentservice)
        {
            _studentservice = studentservice;
        }

        [ICommand]
        public async void AddStudentDb()
        {
            int response = -1;
            if(StudentDetail.studentid > 0)
            {
                response = await _studentservice.UpdateStudent(StudentDetail);
            }
            else
            {
                List<string> check_email = await _studentservice.GetEmails();
                if(check_email.Contains(StudentDetail.email))
                {
                    await Shell.Current.DisplayAlert("Email Already Exists", "can not save the student", "Ok");
                }
                else
                {
                response = await _studentservice.AddStudent(new Model.Student
                {
                    Firstname = StudentDetail.Firstname,
                    Lastname = StudentDetail.Lastname,
                    email = StudentDetail.email
                });
            }

            if (response > 0)
            {
                await Shell.Current.DisplayAlert("Student Details Saved", "Record Saved", "Ok");
            }
            else
            {
                await Shell.Current.DisplayAlert("Not saved", "Something went wrong while saving the record","Check student Details");
            }
        }
    }
}
