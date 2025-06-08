using Microsoft.Maui.Controls;
using Models;
using System;
using WebApiClient;
namespace MallPhoneApp;

public partial class AddProduct : ContentPage
{
    string PhotoName;
    public AddProduct()
    {
        InitializeComponent();
    }

    public async void BackToPrevPage(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnPickImageClicked(object sender, EventArgs e)
    {
        try
        {
            var photo = await MediaPicker.PickPhotoAsync();
            if (photo != null)
            {
                string guid = Guid.NewGuid().ToString() + "_" + photo.FileName;
                string fullPath = Path.Combine(@"C:\MyMall\Brand\WebService\wwwroot\Products", guid);
                using var sourceStream = await photo.OpenReadAsync();
                using (var destinationStream = File.Create(fullPath))
                {
                    await sourceStream.CopyToAsync(destinationStream);
                }
                PhotoName = guid;
            }
        }
        catch (Exception ex)
        {
            await Navigation.PushAsync(new ErrorHandler());
        }

    }

    private async void CreateProduct(object sender, EventArgs e)
    {
        try
        {
            int Percentage = Convert.ToInt32(SalePercentage.Text);
            Product p = new Product()
            {
                ProductName = ProductName.Text,
                ProductPrice = Convert.ToInt32(ProductPrice.Text),
                ProductBrand = Convert.ToInt32(BrandID.Text),
                StoreID = Convert.ToInt32(StoreID.Text),
                SaleID = (Percentage - Percentage % 5) / 5,
                ProductIMG = PhotoName,
                ID = Convert.ToInt32(ProductID.Text)
            };
            WebClient<Product> webClient = new WebClient<Product>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/AddNewProductToStore"
            };
            bool Added = await webClient.PostAsync(p);
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