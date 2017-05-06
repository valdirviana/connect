using ConnectAPI.Domain.App;
using ConnectAPI.Domain.Dto;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Connect.API.Controllers
{
    [RoutePrefix("api/ferias")]
    public class FeriasController : ApiController
    {
        private readonly IFeriasApp _app;

        public FeriasController(IFeriasApp app)
        {
            _app = app;
        }

        [HttpGet]
        [Route("{id}")]
        public Task<HttpResponseMessage> Get(int id) => Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _app.GetByFuncionario(id)));

        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Post([FromBody]FeriasDto entityDto) => Task.FromResult(Request.CreateResponse(HttpStatusCode.Created, _app.Save(entityDto)));

        [HttpPut]
        [Route("")]
        public Task<HttpResponseMessage> Put([FromBody]FeriasDto entityDto) => Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _app.Update(entityDto)));

        [HttpDelete]
        [Route("{id}")]
        public Task<HttpResponseMessage> Delete(int id) => Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _app.Delete(id)));
    }
}
