using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for AddProductForm.xaml
    /// </summary>
    public partial class AddProductForm : UserControl
    {
        int StoreOwnerID = AppStoreOwnerID.StoreOwnerID;
        public AddProductForm()
        {
            InitializeComponent();
        }

        private async void btn_AddProduct(object sender, RoutedEventArgs e)
        {
            //i forgot to add the image, so no imagew i guess whatsoever 
            WebClient<Product> webClient = new WebClient<Product>();
            Product product = new Product()
            {
                ProductName = ProductName.Text,
                ProductPrice = Convert.ToInt32(ProductPrice.Text),
                ID = Convert.ToInt32(ProductID.Text),
                ProductBrand = Convert.ToInt32(BrandID.Text),
                StoreID = Convert.ToInt32(StoreID.Text),
                SaleID = Convert.ToInt32(Percentage)
                
            };
            product.SaleID = (product.SaleID - product.SaleID % 5) / 5;
            bool Added = await webClient.PostAsync(product);
            if (Added)
            {
                Catalog catalog = new Catalog(StoreOwnerID);
                catalog.Show();
            }
        }
    }
}
