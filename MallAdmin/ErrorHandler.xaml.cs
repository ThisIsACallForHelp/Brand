using MallAdmin.AppData;
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

namespace MallAdmin
{
    /// <summary>
    /// Interaction logic for ErrorHandler.xaml
    /// </summary>
    public partial class ErrorHandler : UserControl
    {
        public ErrorHandler()
        {
            InitializeComponent();
        }

        private void btn_Return(object sender, RoutedEventArgs e)
        {
            //it all works thank god 
            switch (AppErrorHandler.SenderName) 
            {
                case "AddProduct":
                    this.Content = new AddProductForm();
                    break;
                case "AddSale":
                    this.Content = new AddSale();
                    break;
                case "AdminLogIn":
                    Window CurrWindow = Application.Current.MainWindow;
                    Application.Current.MainWindow = new MainWindow();
                    Application.Current.MainWindow.Show();
                    CurrWindow.Close();
                    break;
                case "Delete":
                    this.Content = new Catalog(AppStoreOwnerID.StoreOwnerID);
                    break;
            }
        }
    }
}
