using CommunityToolkit.Maui.Extensions;
using CommunityToolkit.Maui.Views;
using DemoProj.MVVM.ViewModels.StudentList;

namespace DemoProj.MVVM.Views.StudentList;

public partial class StudentListView : ContentPage
{
	private readonly StudentListViewModel _viewModel;
    public StudentListView(StudentListViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
	}

	protected override void OnAppearing()
	{ 
		base.OnAppearing();


        _viewModel.ShowPopup -= vm_ShowPopup;
        _viewModel.ShowPopup += vm_ShowPopup;
    }

	private async void vm_ShowPopup(object sender, Popup popup)
	{
		await this.ShowPopupAsync(popup);
    }
}