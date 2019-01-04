using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;
using Utilidades.API.Business;
using Utilidades.API.Data.VO;

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
        [ProducesResponseType (typeof (List<UsersTypeVO>), 200)]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [Authorize ("Bearer")]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult Get () {
            return new OkObjectResult (_usersTypeBusiness.FindAll ());
        }

        [HttpGet ("find-by-type")]
        [ProducesResponseType (typeof (List<UsersTypeVO>), 200)]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [Authorize ("Bearer")]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult GetByType ([FromQuery] string type) {
            return new OkObjectResult (_usersTypeBusiness.FindByType (type));
        }

        [HttpGet ("{id}")]
        [ProducesResponseType (typeof (UsersTypeVO), 200)]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (404)]
        [Authorize ("Bearer")]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult Get (long id) {
            return new OkObjectResult (_usersTypeBusiness.FindById (id));
        }

        [HttpPost]
        [ProducesResponseType (typeof (List<UsersTypeVO>), 201)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [Authorize ("Bearer")]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult Post ([FromBody] UsersTypeVO usersType) {
            if (usersType == null)
                return BadRequest ();
            return new OkObjectResult (_usersTypeBusiness.Create (usersType));
        }

        [HttpPut]
        [ProducesResponseType (typeof (List<UsersTypeVO>), 202)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (404)]
        [Authorize ("Bearer")]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult Put ([FromBody] UsersTypeVO usersType) {
            if (usersType == null)
                return BadRequest ();
            var updatedUsersType = _usersTypeBusiness.Update (usersType);
            if (updatedUsersType == null)
                return NoContent ();
            return new OkObjectResult (updatedUsersType);
        }

        [HttpDelete ("{id}")]
        [ProducesResponseType (typeof (List<UsersTypeVO>), 200)]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [ProducesResponseType (404)]
        [Authorize ("Bearer")]
        public IActionResult Delete (long id) {
            _usersTypeBusiness.Delete (id);
            return NoContent ();
        }
    }
}