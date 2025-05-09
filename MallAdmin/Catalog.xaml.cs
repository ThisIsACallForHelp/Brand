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
        AddProductForm addProductForm = new AddProductForm();
        AddSale addSale = new AddSale();
        StoreOwnerViewModel viewModel = new StoreOwnerViewModel();
        public Catalog(int StoreOwnerID)
        {
            //its good 
            InitializeComponent();
            AppStoreOwnerID.StoreOwnerID = StoreOwnerID;
        }
        private void btn_AddAProduct(object sender, RoutedEventArgs e)
        {
            //works
            this.Content.Child = this.addProductForm;
        }

        private void btn_AddASale(object sender, RoutedEventArgs e)
        {
            //works
            this.Content.Child = this.addSale;
        }
        //private async void btn_StoreOwnerView(object sender, RoutedEventArgs e)
        //{
        //    OnSale = false;
        //    try
        //    {
        //        WebClient<StoreOwnerViewModel> Client = new WebClient<StoreOwnerViewModel>()
        //        {
        //            Schema = "http",
        //            Port = 5134,
        //            Host = "localhost",
        //            Path = "api/StoreOwner/StoreOwnerView"
        //        };
        //        Client.AddParams("StoreOwnerID", AppStoreOwnerID.StoreOwnerID.ToString());
        //        Client.AddParams("OnSale", OnSale.ToString());
        //        viewModel = await Client.GetAsync();
        //        this.DataContext = viewModel;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());   
        //    }            
        //}

        private async void btn_Delete(object sender, RoutedEventArgs e)
        {
            //Deletes the Product: yes 
            //Sets the SaleID to be 0: idk i didnt check yet 
            Button btn = (Button)sender;
            Product product = new Product(){
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
                this.DataContext = new Catalog(AppStoreOwnerID.StoreOwnerID); 
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
