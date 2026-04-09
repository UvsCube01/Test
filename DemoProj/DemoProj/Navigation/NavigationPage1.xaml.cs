namespace DemoProj.Navigation;

public partial class NavigationPage1 : ContentPage
{
	public NavigationPage1()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new NavigationPage2());
    }

    private void PopToPage4(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}