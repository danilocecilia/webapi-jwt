using BasicAuthentication.Filters;
using BasicAuthentication.Models;
using BasicAuthentication.Module;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace BasicAuthentication.Controllers
{
    [EnableCors(origins: "http://localhost:8100", headers: "*", methods: "*")]
    [RoutePrefix("api/authentication")]
    public class AutorizedApiController : ApiController
    {
        [BasicAuthenticationFilter]
        [HttpGet]
        [Route("basicauth")]
        public User Authenticate()
        {
            return ((ApiIdentity)HttpContext.Current.User.Identity).User;
        }

        [HttpPost]
        [Route("demoauth")]
        public HttpResponseMessage LoginDemo([FromBody] User user)
        {
            if (user == null)
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid User", Configuration.Formatters.JsonFormatter);
            }
            else
            {
                AuthenticationModule authentication = new AuthenticationModule();
                string token = authentication.GenerateTokenForUser(user.Username, user.UserId);
                return Request.CreateResponse(HttpStatusCode.OK, new { token = token, username = user.Username }, Configuration.Formatters.JsonFormatter);
            }

        }
    }
}
