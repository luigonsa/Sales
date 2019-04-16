

namespace Sales.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Common.Models;
    using GalaSoft.MvvmLight.Command;
    using Sales.Helpers;
    using Services;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel


    {
        //Api Services
        private ApiService ApiService;

        //para refrescar en la vista
        private bool isRefreshing;

        //products es propiedad privada
        private ObservableCollection<Product> products;

        //Products en letra mayuscula es Publica
        public ObservableCollection<Product> Products
        {

            get { return this.products; }
            set { this.SetValue(ref this.products, value); }


        }

        public bool IsRefreshing
        {
            get { return this.isRefreshing; }
            set { this.SetValue(ref this.isRefreshing, value); }
        }

        public ProductsViewModel()
        {
            this.ApiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
           
            //refrescamos la pantalla
            this.IsRefreshing = true;

            //verificamos si tiene internet 
            var connection = await this.ApiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                //si no hay internet mandamos el mensaje
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, connection.Message, Languages.Accept);
                return;
            }

            //url viene de los Recursos de Sales.App.Xaml
            var url = Application.Current.Resources["UrlAPI"].ToString();
            var prefix = Application.Current.Resources["UrlPrefix"].ToString();
            var controller = Application.Current.Resources["UrlProductsController"].ToString();
            var response = await this.ApiService.GetList<Product>(url, prefix, controller);
            
            if (!response.IsSuccess)
            {
                //si falla entonces ponemos el refrescar en false
                this.IsRefreshing = false;
                await Application.Current.MainPage.DisplayAlert(Languages.Error, response.Message, Languages.Accept);
                return;
            }

            var list = (List<Product>) response.Result;
            this.Products = new ObservableCollection<Product>(list);
            //Si todo va bien tambien refrescamos el IsRefreshing a false
            this.IsRefreshing = false;
        }

        //propiedad solo de lectura en la vista por eso se le quita el set y su objetivo es refrescar automaticamente
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadProducts);
            }
        }

    }
}
