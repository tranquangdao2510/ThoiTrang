using API.Models.DataModel;

namespace API.Controllers.API
{
    internal class Reponse<T>
    {
        public int StatusCode { get; set; }
        public User Data { get; set; }
        public string Message { get; set; }
    }
}