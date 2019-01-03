using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;
using Utilidades.API.Business;
using Utilidades.API.Data.VO;

namespace Utilidades.API.Controllers {
    [ApiVersion ("1")]
    [Route ("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class UsersController : ControllerBase {
        private IUserBusiness _userBusiness;

        public UsersController (IUserBusiness userBusiness) {
            _userBusiness = userBusiness;
        }

        [HttpGet]
        [ProducesResponseType (typeof (List<UsersTypeVO>), 200)]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult Get () {
            return Ok (_userBusiness.FindAll ());
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (typeof (UsersTypeVO), 200)]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (404)]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult Get (long id) {
            var user = _userBusiness.FindById (id);
            if (user == null)
                return NotFound ();
            return Ok (user);
        }

        [HttpPost]
        [ProducesResponseType (typeof (List<UserVO>), 201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult Post ([FromBody] UserVO user) {
            if (user == null)
                return BadRequest ();
            return new ObjectResult (_userBusiness.Create (user));
        }

        [HttpPut]
        [ProducesResponseType (typeof (List<UserVO>), 202)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (404)]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult Put ([FromBody] UserVO user) {
            if (user == null)
                return BadRequest ();
            var updatedUser = _userBusiness.Update (user);
            if (updatedUser == null)
                return NoContent ();
            return new ObjectResult (updatedUser);
        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (typeof (List<UserVO>), 200)]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (404)]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult Delete (long id) {
            _userBusiness.Delete (id);
            return NoContent ();
        }
    }
}