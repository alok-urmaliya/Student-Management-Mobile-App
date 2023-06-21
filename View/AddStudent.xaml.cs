using App01.ViewModel;

namespace App01.View;

public partial class AddStudent : ContentPage
{
	public AddStudent(AddStudentViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}