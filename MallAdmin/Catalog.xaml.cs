using MallAdmin.AppData;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WebApiClient;
namespace MallAdmin
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {                
        StoreOwnerViewModel viewModel = new StoreOwnerViewModel();
        
        public Catalog(int StoreOwnerID)
        {
            //its good 
            InitializeComponent();
            AppStoreOwnerID.StoreOwnerID = StoreOwnerID;
            CatalogInitializer();
        }

        private async void CatalogInitializer()
        {
            //works
            WebClient<StoreOwnerViewModel> Client = new WebClient<StoreOwnerViewModel>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/StoreOwnerView"
            };
            Client.AddParams("StoreOwnerID", AppStoreOwnerID.StoreOwnerID.ToString());
            Client.AddParams("OnSale", AppOnSale.OnSale.ToString());
            viewModel =  await Client.GetAsync();
            this.DataContext = viewModel;
        }
        private void btn_AddAProduct(object sender, RoutedEventArgs e)
        {
            //works
            this.Content.Child = new AddProductForm();
        }

        private void btn_AddASale(object sender, RoutedEventArgs e)
        {
            //works
            this.Content.Child = new AddSale();
        }

        private async void btn_Delete(object sender, RoutedEventArgs e)
        {
            //works
            MessageBoxResult result = MessageBox.Show("Are you sure you want to proceed?",
                                                      "Confirmation",
                                                      MessageBoxButton.YesNo,
                                                      MessageBoxImage.Question);
            try
            {
                if (result == MessageBoxResult.Yes)
                {
                    Button btn = (Button)sender;
                    Product product = new Product()
                    {
                        ID = Convert.ToInt32(btn.Tag)
                    };
                    WebClient<Product> client = new WebClient<Product>()
                    {
                        Schema = "http",
                        Host = "localhost",
                        Port = 5134
                    };
                    if (AppOnSale.OnSale)
                    {
                        client.Path = "api/StoreOwner/DeleteSale";
                    }
                    else
                    {
                        client.Path = "api/StoreOwner/DeleteProduct";
                    }
                    client.AddParams("ProductID", btn.Tag.ToString());
                    bool Deleted = await client.PostAsync(product);
                    if (Deleted)
                    {
                        Catalog catalog = new Catalog(AppStoreOwnerID.StoreOwnerID);
                        this.DataContext = catalog;
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
            catch (Exception)
            {
                AppErrorHandler.SenderName = "Delete";
                this.Content.Child = new ErrorHandler();
            }         
        }

        private async void btn_StoreOwnerView(object sender, RoutedEventArgs e)
        {
            //works
            Button button = (Button)sender;
            if(button.Tag.Equals("True"))
            {
                AppOnSale.OnSale = true;
            }
            else
            {
                AppOnSale.OnSale = false;
            }
            try
            {
                WebClient<StoreOwnerViewModel> Client = new WebClient<StoreOwnerViewModel>()
                {
                    Schema = "http",
                    Port = 5134,
                    Host = "localhost",
                    Path = "api/StoreOwner/StoreOwnerView"
                };
                Client.AddParams("StoreOwnerID", AppStoreOwnerID.StoreOwnerID.ToString());
                Client.AddParams("OnSale", AppOnSale.OnSale.ToString());
                viewModel = await Client.GetAsync();
                this.DataContext = viewModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
