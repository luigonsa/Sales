
namespace Sales.Services
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Sales.Common.Models;



    public class ApiService
    {

      public async Task<Response> GetList<T>(string urlBase, string prefix, string controller)
        {

            try
            {
                //Para consumir un servicio Result
                //1er paso cramos el objeto HttpClient
                var client = new HttpClient();
                //paso 2 cargar direccion
                client.BaseAddress = new Uri(urlBase);
                //3er paso es para concatenar el prefijo y controlador para obtener la peticion
                var url = $"{prefix}{controller}";
                //4 hacer el request o requerimiento con todos los metodos que se usan en postman
                var response = await client.GetAsync(url);
                //ahora leemos el objeto como un string
                var answer = await response.Content.ReadAsStringAsync();
                //ahoira lo covertimos como json pero antes revisamos si hay errores o se cancelo o todo esta bien
                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = answer,
                    };
                }

                //si todo esta bien o no se cumple la negacion
                //serializamos o convertimos en json
                //samos la libreria que agregamos en el nuget del proyecto
                var list = JsonConvert.DeserializeObject<List<T>>(answer)



            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,

                };
            }

        }

       
    }

}
