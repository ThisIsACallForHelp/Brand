using WebApiClient;
using Models;
using MallPhoneApp.AppInfo;
namespace MallPhoneApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OwnerLogIn(object sender, EventArgs e)
        {
            try 
            {
                WebClient<int> Client = new WebClient<int>()
                {
                    Schema = "http",
                    Port = 5134,
                    Host = "localhost",
                    Path = "api/StoreOwner/OwnerSignIn"
                };
                Client.AddParams("StoreOwnerName", this.FirstName.Text);
                Client.AddParams("StoreOwnerLastName", this.LastName.Text);
                Client.AddParams("StoreOwnerID", this.ID.Text);
                OwnerInfo.StoreOwnerID = await Client.GetAsync();
                if (OwnerInfo.StoreOwnerID != 0)
                {
                    await Navigation.PushAsync(new Catalog());
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
}
