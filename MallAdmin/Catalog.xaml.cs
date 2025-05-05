using Models;
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
using System.Windows.Shapes;
using WebApiClient;
namespace MallAdmin
{
    /// <summary>
    /// Interaction logic for Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        int OwnerID;
        public Catalog(int StoreOwnerID)
        {
            InitializeComponent();
            this.OwnerID = StoreOwnerID;
        }

        

        private void btn_AddAProduct(object sender, RoutedEventArgs e)
        {

        }

        private void btn_AddASale(object sender, RoutedEventArgs e)
        {

        }

        private async void btn_StoreOwnerView(object sender, RoutedEventArgs e)
        {
            //it gets 0, even though the OwnerID is actually valid idk why debug this bitch
            Button button = (Button)sender;
            bool OnSale = false;
            if(button.Tag == "True")
            {
                OnSale = true;
            }
            else
            {
                OnSale = false;
            }
            WebClient<StoreOwnerViewModel> Client = new WebClient<StoreOwnerViewModel>()
            {
                Schema = "http",
                Port = 5134,
                Host = "localhost",
                Path = "api/StoreOwner/StoreOwnerView"
            };
            Client.AddParams("StoreOwnerID", this.OwnerID.ToString());
            Client.AddParams("OnSale", OnSale.ToString());
            StoreOwnerViewModel products = new StoreOwnerViewModel()
            {
                StoreOwnerID = this.OwnerID,
                OnSale = OnSale
            };
            products = await Client.GetAsync();
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
