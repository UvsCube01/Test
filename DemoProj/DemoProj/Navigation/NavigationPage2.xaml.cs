namespace DemoProj.Navigation;

public partial class NavigationPage2 : ContentPage
{
	public NavigationPage2()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PopAsync();
    }

    private void PopToRoot(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }
}