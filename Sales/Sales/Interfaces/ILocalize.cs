namespace Sales.Interfaces
{
    using System.Globalization;

    public interface ILocalize
    {
        //saber el indioma del telefono
        CultureInfo GetCurrentCultureInfo();


        //poder cambiar el idioma
        void SetLocale(CultureInfo ci);

    }
}
