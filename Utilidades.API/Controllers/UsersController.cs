using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Utilidades.API.Model;
using Utilidades.API.Services;

namespace Utilidades.API.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase {
        private IUserService _userService;

        public UsersController (IUserService userService) {
            _userService = userService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get () {
            return Ok (_userService.FindAll ());
        }

        // GET api/values/5
        [HttpGet ("{id}")]
        public IActionResult Get (int id) {
            var user = _userService.FindById (id);
            if (user == null)
                return NotFound ();
            return Ok (user);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post ([FromBody] User user) {
            if (user == null)
                return BadRequest ();
            return new ObjectResult (_userService.Create (user));
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put ([FromBody] User user) {
            if (user == null)
                return BadRequest ();
            return new ObjectResult (_userService.Update (user));
        }

        // DELETE api/values/5
        [HttpDelete]
        public IActionResult Delete ([FromBody] User user) {
            _userService.Delete (user);
            return NoContent ();
        }
    }
}