﻿using System;
using System.Collections.Generic;
using System.IO;
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
using Microsoft.Win32;
using Models;
using WebApiClient;
namespace MallAdmin
{
    /// <summary>
    /// Interaction logic for AddProductForm.xaml
    /// </summary>
    public partial class AddProductForm : UserControl
    {
        string relativePath;
        public AddProductForm()
        {
            InitializeComponent();
        }

        private void UploadImage_Click(object sender, RoutedEventArgs e)
        {
            //works 

            //another code documentation🗣️🗣️🗣️💯💯
            OpenFileDialog dialog = new OpenFileDialog();
            //OpenFileDialog opens the panel from which the user can select the file
            dialog.Title = "Select an Image";
            //a nice little decoration, just makes the top of the dialog say "Select an Images"
            dialog.Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg";
            //filter the files, just in case the user will try to put
            //something else and not a real image
            if (dialog.ShowDialog() == true)
                //if there was a success in opening the FileDialog do this:
            {
                string sourceFilePath = dialog.FileName;
                //sourceFilePath Stores the name of the chosen file
                string uniqueFileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(sourceFilePath);
                //of course, prevent overwriting images by giving them a unique ID
                //and then slap the file extension in there (.jpg, .png and .jpeg)
                string targetFolder = @"C:\MyMall\Brand\WebService\wwwroot\Products";
                //the target storing path on my hard disk and my solutin
                string destinationPath = System.IO.Path.Combine(targetFolder, uniqueFileName);
                //combine the string to get the full path AND the file name into one string 
                File.Copy(sourceFilePath, destinationPath, overwrite: false);
                //copy the file into the destination, and prevent overwriting of the files

                //save the path 
                relativePath = uniqueFileName;
            }
        }


        private async void btn_AddProduct(object sender, RoutedEventArgs e)
        {
            //works
            try
            {
                WebClient<Product> webClient = new WebClient<Product>()
                {
                    Schema = "http",
                    Port = 5134,
                    Host = "localhost",
                    Path = "api/StoreOwner/AddNewProductToStore"
                };
                Product product = new Product()
                {
                    ProductName = ProductName.Text,
                    ProductPrice = Convert.ToInt32(ProductPrice.Text),
                    ID = Convert.ToInt32(ProductID.Text),
                    ProductBrand = Convert.ToInt32(BrandID.Text),
                    StoreID = Convert.ToInt32(StoreID.Text),
                    SaleID = Convert.ToInt32(Percentage.Text),
                    ProductIMG = relativePath
                };
                product.SaleID = (product.SaleID - product.SaleID % 5) / 5;
                bool Added = await webClient.PostAsync(product);
                if (Added)
                {
                    Catalog catalog = new Catalog(AppStoreOwnerID.StoreOwnerID);
                    catalog.Show();
                }
            }
            catch (Exception ex)
            {
                AppErrorHandler.SenderName = "AddProduct";
                this.Content = new ErrorHandler();
            }
        }
    }
}
