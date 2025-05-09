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
        AddProductForm addProductForm;
        AddSale addSale;
        bool OnSale = false;
        StoreOwnerViewModel viewModel = new StoreOwnerViewModel();
        public Catalog(int StoreOwnerID)
        {
            InitializeComponent();
            AppStoreOwnerID.StoreOwnerID = StoreOwnerID;
        }
        private void btn_AddAProduct(object sender, RoutedEventArgs e)
        {
            this.Content.Child = this.addProductForm;
        }

        private void btn_AddASale(object sender, RoutedEventArgs e)
        {
            this.Content.Child = this.addSale;
        }
        private async void btn_StoreOwnerView(object sender, RoutedEventArgs e)
        {
            //it says that it works, i debugged it but the Images are null 
            Button button = (Button)sender;
            if(button.Tag == "True")
            {
                OnSale = true;
            }
            else
            {
                OnSale = false;
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
                Client.AddParams("OnSale", OnSale.ToString());
                viewModel = await Client.GetAsync();
                this.DataContext = viewModel;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());   
            }            
        }

        private async void btn_DeleteProduct(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Product product = new Product(){
                ID = Convert.ToInt32(btn.Tag)
            };
            MessageBoxResult result = MessageBox.Show("Are you sure you want to proceed?", 
                                                      "Confirmation", MessageBoxButton.YesNo, 
                                                       MessageBoxImage.Question);
            if(result == MessageBoxResult.Yes)
            {
                WebClient<Product> Client = new WebClient<Product>()
                {
                    Schema = "http",
                    Port = 5134,
                    Host = "localhost",
                };
                bool Deleted = await Client.PostAsync(product);
                if (Deleted)
                {
                    Catalog catalog = new Catalog(AppStoreOwnerID.StoreOwnerID);
                    catalog.Show();
                }
            }           
        }
    }
}
