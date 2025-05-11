using MallAdmin.AppData;
using Models;
using System.Net;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WebApiClient;
namespace MallAdmin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Catalog catalog;
        public MainWindow()
        {
            InitializeComponent();
            //if(this.catalog == null)
            //{
            //    this.catalog = new Catalog(StoreOwnerID);
            //}            
        }


        private async void btn_AdminLogIn(object sender, RoutedEventArgs e)        
        {
            //works 
            if (this.FirstName.Text == null || this.LastName.Text == null || this.ID.Text == null)
            {
                throw new Exception();
            }
            try
            {
                WebClient<int> Client = new WebClient<int>()
                {
                    Schema = "http",
                    Port = 5134,
                    Host = "localhost",
                    Path = "api/StoreOwner/OwnerSignIn"
                };
                StoreOwner Owner = new StoreOwner()
                {
                    StoreOwnerName = this.FirstName.Text,
                    StoreOwnerLastName = this.LastName.Text,
                    ID = Convert.ToInt32(this.ID.Text)
                };
                Client.AddParams("StoreOwnerName", Owner.StoreOwnerName);
                Client.AddParams("StoreOwnerLastName", Owner.StoreOwnerLastName);
                Client.AddParams("StoreOwnerID", Owner.ID.ToString());

                AppStoreOwnerID.StoreOwnerID = await Client.GetAsync();
                Console.WriteLine("Owner Id = " + AppStoreOwnerID.StoreOwnerID);
                if (AppStoreOwnerID.StoreOwnerID != 0)
                {
                    Catalog catalog = new Catalog(AppStoreOwnerID.StoreOwnerID);
                    catalog.Show();
                    this.Close();
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                AppErrorHandler.SenderName = "AdminLogIn";                
                this.Content.Child = new ErrorHandler();
            }
        }
    }
}