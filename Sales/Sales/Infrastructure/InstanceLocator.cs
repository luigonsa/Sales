

//Toda esta clase lo que hace es instanciar la MainViewModels una sola instancia
namespace Sales.Infrastructure
{
    using ViewModels;

    public class InstanceLocator
    {
        public MainViewModels Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModels();
        }

    }
}
