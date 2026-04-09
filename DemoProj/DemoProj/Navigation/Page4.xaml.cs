namespace DemoProj.Navigation;

public partial class Page4 : ContentPage
{
	public Page4()
	{
		InitializeComponent();
	}

    private void Button_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new NavigationPage1());
    }
}