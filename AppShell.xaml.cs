using App01.View;
using App01.ViewModel;

namespace App01;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(AddStudent), typeof(AddStudent));
	}
}
