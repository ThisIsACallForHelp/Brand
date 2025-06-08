namespace MallPhoneApp;

public partial class ErrorHandler : ContentPage
{
	public ErrorHandler()
	{
		InitializeComponent();
	}

	private async void GoBack(object sender, EventArgs e)
	{
		await Navigation.PopAsync();
	}
}