using System.Net.Http;
using System.Web.Http;

namespace Connect.API.Controllers
{
    public class BaseController : ApiController
    {
        public HttpResponseMessage _responseMessage;
    }
}
