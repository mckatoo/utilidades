using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tapioca.HATEOAS;
using Utilidades.ApplicationCore.Data.VO;
using Utilidades.Infrastructure.Business;

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

        [HttpGet ("find")]
        [ProducesResponseType (typeof (List<UsersTypeVO>), 200)]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [Authorize ("Bearer")]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult FindByType ([FromQuery] string type) {
            return new OkObjectResult (_usersTypeBusiness.FindByType (type));
        }

        [HttpGet ("find/{sortDirection}/{pageSize}/{activePage}")]
        [ProducesResponseType (typeof (List<UsersTypeVO>), 200)]
        [ProducesResponseType (204)]
        [ProducesResponseType (400)]
        [ProducesResponseType (401)]
        [Authorize ("Bearer")]
        [TypeFilter (typeof (HyperMediaFilter))]
        public IActionResult FindPagedSearch ([FromQuery] string type, string sortDirection, int pageSize, int activePage) {
            return new OkObjectResult (_usersTypeBusiness.FindWithPagedSearch (type, sortDirection, pageSize, activePage));
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