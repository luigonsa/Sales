

namespace Sales.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Common.Models;
    using Services;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel


    {
        //Api Services
        private ApiService ApiService;

        //products es propiedad privada
        private ObservableCollection<Product> products;

        //Products en letra mayuscula es Publica
        public ObservableCollection<Product> Products
        {

            get { return this.products; }
            set { this.SetValue(ref this.products, value); }


        }

        public ProductsViewModel()
        {
            this.ApiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            var response = await this.ApiService.GetList<Product>("https://salesapiservices.azurewebsites.net", "/api", "/products");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }

            var list = (List<Product>) response.Result;
            this.Products = new ObservableCollection<Product>(list);
        }
    }
}
