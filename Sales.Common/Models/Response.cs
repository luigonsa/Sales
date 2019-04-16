namespace Sales.Common.Models
{

    public class Response
    {

        //3 atributos o propiedad uno de IsSuccess el otro mensaje y el resultado
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public object Result { get; set; }
    }

    
}

namespace Sales.Common
{
    public class Response
    {
    }
}