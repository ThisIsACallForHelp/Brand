using MallPhoneApp.AppInfo;
using Models;
using WebApiClient;
namespace MallPhoneApp;

public partial class Catalog : ContentPage
{
    CatalogViewModel catalog = new CatalogViewModel();
    public Catalog()
    {
        InitializeComponent();
        GetCatalog();
    }

    private async void GetCatalog()
    {
        try
        {
            WebClient<CatalogViewModel> Client = new WebClient<CatalogViewModel>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/StoreOwnerView"
            };
            Client.AddParams("StoreOwnerID", OwnerInfo.StoreOwnerID.ToString());
            OwnerInfo.OnSale = "False";
            Client.AddParams("OnSale", false.ToString());
            catalog = await Client.GetAsync();
            if(catalog == null)
            {
                throw new Exception();
            }
            this.BindingContext = catalog;
        }
        catch (Exception ex)
        {
            await Navigation.PushAsync(new ErrorHandler());
        }
    }

    private async void StoreOwnerCatalog(object sender, EventArgs e)
    {
        try
        {
            Button btn = (Button)sender;
            WebClient<CatalogViewModel> Client = new WebClient<CatalogViewModel>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/StoreOwnerView"
            };
            Client.AddParams("StoreOwnerID", OwnerInfo.StoreOwnerID.ToString());
            Client.AddParams("OnSale", btn.ClassId);
            OwnerInfo.OnSale = btn.ClassId;
            catalog = await Client.GetAsync();
            this.BindingContext = catalog;
        }
        catch (Exception ex)
        {
            await Navigation.PushAsync(new ErrorHandler());
        }
        
    }
    private async void AddProductForm(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddProduct());
    }
    private async void AddSaleForm(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddSale());
    }

    private async void Delete(object sender, EventArgs e)
    {
        try
        {
            bool answer = await DisplayAlert("Confirmation", "Are you sure you want to proceed?", "Yes", "No");
            if (answer)
            {
                Button btn = (Button)sender;
                Product product = new Product()
                {
                    ID = Convert.ToInt32(btn.ClassId)
                };
                WebClient<Product> client = new WebClient<Product>()
                {
                    Schema = "http",
                    Host = "localhost",
                    Port = 5134
                };
                if (OwnerInfo.OnSale.Equals("true"))
                {
                    client.Path = "api/StoreOwner/DeleteSale";
                }
                else
                {
                    client.Path = "api/StoreOwner/DeleteProduct";
                }
                client.AddParams("ProductID", product.ID.ToString());
                bool Deleted = await client.PostAsync(product);
                if (Deleted)
                {
                    await Navigation.PushAsync(new Catalog());
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        catch (Exception ex)
        {
            await Navigation.PushAsync(new ErrorHandler());
        }
    }
        
}
