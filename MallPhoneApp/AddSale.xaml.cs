
using Models;
using WebApiClient;

namespace MallPhoneApp;

public partial class AddSale : ContentPage
{
	public AddSale()
	{
		InitializeComponent();
	}

    public async void BackToPrevPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void CreateSale(object sender, EventArgs e)
    {
        try
        {
            WebClient<Product> webClient = new WebClient<Product>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/AddNewSale"
            };
            Product product = new Product()
            {
                ID = Convert.ToInt32(ProductID.Text),
                SaleID = Convert.ToInt32(SaleID.Text)
            };
            product.SaleID = (product.SaleID - product.SaleID % 5) / 5;
            bool Added = await webClient.PostAsync(product);
            if (Added)
            {
                await Navigation.PopAsync();
            }
            else
            {
                throw new Exception();
            }
        }
        catch (Exception ex)
        {
            await Navigation.PushAsync(new ErrorHandler());
        }
    }
}