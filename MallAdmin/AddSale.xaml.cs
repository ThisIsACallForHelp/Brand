using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MallAdmin.AppData;
using Models;
using WebApiClient;
namespace MallAdmin
{
    /// <summary>
    /// Interaction logic for AddSale.xaml
    /// </summary>
    public partial class AddSale : UserControl
    {
        
        public AddSale()
        {
            InitializeComponent();
        }
        private async void btn_AddSale(object sender, RoutedEventArgs e)
        {
            //works
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
                    SaleID = Convert.ToInt32(Percentage.Text)
                };
                product.SaleID = (product.SaleID - product.SaleID % 5) / 5;
                bool Added = await webClient.PostAsync(product);
                if (Added)
                {
                    Catalog catalog = new Catalog(AppStoreOwnerID.StoreOwnerID);
                    catalog.Show();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                AppErrorHandler.SenderName = "AddSale";
                this.Content = new ErrorHandler();
            }
        }
    }
}
