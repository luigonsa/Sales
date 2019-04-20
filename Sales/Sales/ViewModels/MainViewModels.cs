

namespace Sales.ViewModels
{

    using GalaSoft.MvvmLight.Command;
    using Sales.Views;
    using System;
    using System.Windows.Input;
    using Xamarin.Forms;


    public class MainViewModels
    {

        public ProductsViewModel Products { get; set; }

        public MainViewModels()
        {
            this.Products = new ProductsViewModel();
        }

        public ICommand AddProductCommand

        {
            get
            {
                return new RelayCommand(GoToAddProduct);   
            }

        }

        private async void GoToAddProduct()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new AddProductPage());
        }
    }
}
