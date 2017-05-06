using ConnectAPI.Domain.App;
using ConnectAPI.Domain.Base.Filter;
using ConnectAPI.Domain.Dto;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Connect.API.Controllers
{
    [RoutePrefix("api/funcionario")]
    public class FuncionarioController : ApiController
    {
        private readonly IFuncionarioApp _app;

        public FuncionarioController(IFuncionarioApp app)
        {
            _app = app;
        }

        [HttpGet]
        [Route("")]
        public Task<HttpResponseMessage> GetAll() => Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _app.GetAll()));

        [HttpGet]
        [Route("{id}")]
        public Task<HttpResponseMessage> Get(int id) => Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _app.GetById(id)));

        [HttpPost]
        [Route("search")]
        public Task<HttpResponseMessage> Search([FromBody]IList<BaseFilter> filters) => Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _app.Search(filters)));

        [HttpPost]
        [Route("")]
        public Task<HttpResponseMessage> Post([FromBody]FuncionarioDto entityDto) => Task.FromResult(Request.CreateResponse(HttpStatusCode.Created, _app.Save(entityDto)));

        [HttpPut]
        [Route("")]
        public Task<HttpResponseMessage> Put([FromBody]FuncionarioDto entityDto) => Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _app.Update(entityDto)));

        [HttpDelete]
        [Route("{id}")]
        public Task<HttpResponseMessage> Delete(int id) => Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _app.Delete(id)));
    }
}
