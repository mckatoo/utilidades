using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Utilidades.API.Model;
using Utilidades.API.Business;

namespace Utilidades.API.Controllers {
    [ApiVersion("1")]
    [Route ("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class UsersController : ControllerBase {
        private IUserBusiness _userBusiness;

        public UsersController (IUserBusiness userBusiness) {
            _userBusiness = userBusiness;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get () {
            return Ok (_userBusiness.FindAll ());
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public IActionResult Get (int id) {
            var user = _userBusiness.FindById (id);
            if (user == null)
                return NotFound ();
            return Ok (user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post ([FromBody] User user) {
            if (user == null)
                return BadRequest ();
            return new ObjectResult (_userBusiness.Create (user));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put ([FromBody] User user) {
            if (user == null)
                return BadRequest ();
            return new ObjectResult (_userBusiness.Update (user));
        }

        // DELETE api/values/5
        [HttpDelete]
        public IActionResult Delete ([FromBody] User user) {
            _userBusiness.Delete (user);
            return NoContent ();
        }
    }
}