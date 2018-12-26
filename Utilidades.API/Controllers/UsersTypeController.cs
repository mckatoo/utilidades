using Microsoft.AspNetCore.Mvc;
using Utilidades.API.Business;
using Utilidades.API.Model;

namespace Utilidades.API.Controllers {
    [ApiVersion ("1")]
    [Route ("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class UsersTypeController : ControllerBase {
        private IUsersTypeBusiness _usersTypeBusiness;

        public UsersTypeController (IUsersTypeBusiness usersTypeBusiness) {
            _usersTypeBusiness = usersTypeBusiness;
        }

        [HttpGet]
        public IActionResult Get () {
            return Ok (_usersTypeBusiness.FindAll ());
        }

        [HttpGet ("{id}")]
        public IActionResult Get (long id) {
            return Ok (_usersTypeBusiness.FindById (id));
        }

        [HttpPost]
        public IActionResult Post ([FromBody] UsersType usersType) {
            if (usersType == null)
                return BadRequest ();
            return new ObjectResult (_usersTypeBusiness.Create (usersType));
        }

        [HttpPut]
        public IActionResult Put ([FromBody] UsersType usersType) {
            if (usersType == null)
                return BadRequest ();
            var updatedUsersType = _usersTypeBusiness.Update (usersType);
            if (updatedUsersType == null)
                return NoContent ();
            return new ObjectResult (updatedUsersType);
        }

        [HttpDelete]
        public IActionResult Delete (long id) {
            _usersTypeBusiness.Delete (id);
            return NoContent ();
        }
    }
}