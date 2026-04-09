using CommunityToolkit.Maui.Views;
using DemoProj.MVVM.ViewModels.StudentList;

namespace DemoProj.MVVM.Views.StudentList;

public partial class StudentPopup : Popup
{
	public StudentPopup(StudentPopupViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;

		viewModel.CloseRequested += async () => await CloseAsync();
    }
}