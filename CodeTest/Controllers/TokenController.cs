using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeTest.Business.Entities;
using CodeTest.Business.Services;
using CodeTest;
using System.Net.Http.Headers;

namespace CodeTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly TokenFactory _tokenFactory;
        private readonly Service _service;

        public TokenController(TokenFactory tokenFactory, Service service)
        {            
            _tokenFactory = tokenFactory;
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Get(UserRequest user)
        {
            TokenResponse tokenResponse = new TokenResponse();
            if (user == null || user.Name == null || user.Pasword == null || string.IsNullOrWhiteSpace(user.Name) || string.IsNullOrWhiteSpace(user.Pasword))
            {
                tokenResponse.Message = "user and pasword is requerid.";
                return Ok(tokenResponse);
            }
            
            bool userResponse =  _service.UserValidate(user);

            if (!userResponse)
            {
                tokenResponse.Message = "User and Pasword incorrect.";
                return Ok(tokenResponse);
            }

            tokenResponse = _tokenFactory.CreateToken(user);

            return Ok(tokenResponse);

        }
    }
}
