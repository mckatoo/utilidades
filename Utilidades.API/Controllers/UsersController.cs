using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Get () {
            return Ok (_userBusiness.FindAll ());
        }

        [HttpGet ("{id}")]
        public IActionResult Get (long id) {
            var user = _userBusiness.FindById (id);
            if (user == null)
                return NotFound ();
            return Ok (user);
        }

        [HttpPost]
        public IActionResult Post ([FromBody] UserVO user) {
            if (user == null)
                return BadRequest ();
            return new ObjectResult (_userBusiness.Create (user));
        }

        [HttpPut]
        public IActionResult Put ([FromBody] UserVO user) {
            if (user == null)
                return BadRequest ();
            var updatedUser = _userBusiness.Update (user);
            if (updatedUser == null)
                return NoContent ();
            return new ObjectResult (updatedUser);
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete (long id) {
            _userBusiness.Delete (id);
            return NoContent ();
        }
    }
}