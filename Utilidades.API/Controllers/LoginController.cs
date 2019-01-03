using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilidades.API.Business;
using Utilidades.API.Model;

namespace Utilidades.API.Controllers {
    [ApiVersion ("1")]
    [Route ("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class LoginController : ControllerBase {
        private ILoginBusiness _loginBusiness;

        public LoginController (ILoginBusiness loginBusiness) {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [AllowAnonymous]
        public object Post ([FromBody] LoginVO login) {
            if (login == null)
                return BadRequest ();
            return _loginBusiness.FindByLogin(login);
        }
    }
}