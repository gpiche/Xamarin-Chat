using System;
using System.Collections.Generic;
using System.Linq;
using Api.DTO;

using IdentityServer;
using IdentityServer.Models;
using IdentityServer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controller
{
    [Route("chat/register")]
    [Authorize]
    public class RegistrationController : ControllerBase
    {
        private readonly IAuthRepository _repository;
        private readonly ICryptoService _cryptoService;

        public RegistrationController(IAuthRepository repository, ICryptoService cryptoService)
        {
            _repository = repository;
            _cryptoService = cryptoService;
        }


        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register([FromBody] RegisterInformation registrationInformation)
        {
            try
            {
                var salt = _cryptoService.GenerateSalt();
                User user = new User
                {
                    Salt = salt,
                    Email = registrationInformation.Email,
                    Password = _cryptoService.HashSha512(registrationInformation.Password, salt),
                    Active = true

                };
               _repository.Add(user);
            }
            catch (Exception e)
            {
                return new NoContentResult();
            }

            return new ContentResult();
        }
    }
}
