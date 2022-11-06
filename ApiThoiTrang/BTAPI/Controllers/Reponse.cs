using BTAPI.Models.DataModel;

namespace BTAPI.Controllers.API
{
    internal class Reponse<T>
    {
        public int StatusCode { get; set; }
        public User Data { get; set; }
        public string Message { get; set; }
    }
}