using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Api.DTO;
using Api.Repository;
using Api.Repository.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Api.Controllers
{
    [Route("api/identity")]
    [Authorize]
    public class IdentityController : ControllerBase
    {
        private readonly InMemoryRepository _repository;

        //This controller will be used later to test the authorization requirement, 
        //as well as visualize the claims identity through the eyes of the API.

        public IdentityController(InMemoryRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetMessages(string userName)
        {
            var message = _repository.GetMessageForUser(userName);

            return new JsonResult(message);
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody]MessageDTO message)
        {

            _repository.AddMessage(message);
            return new NoContentResult();

        }
    }
}