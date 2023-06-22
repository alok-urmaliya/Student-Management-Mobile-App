using App01.ViewModel;

namespace App01.View;

public partial class StudentList : ContentPage
{
	private StudentListViewModel _viewModel;
	public StudentList(StudentListViewModel viewModel)
	{
		InitializeComponent();
		_viewModel = viewModel;
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_viewModel.GetStudentListCommand.Execute(null);
    }
}