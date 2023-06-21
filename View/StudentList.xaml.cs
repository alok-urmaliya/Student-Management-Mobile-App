using App01.ViewModel;

namespace App01.View;

public partial class StudentList : ContentPage
{
	public StudentList(StudentListViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}