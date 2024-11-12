using EcoApi.Dto;
using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoApi.Controllers {
    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller {
        // Injeção da nossa interface para geração de Token
        private readonly ITokenInteface _tokenService;
        public LoginController(ITokenInteface tokenService) {
            _tokenService = tokenService;
        }

        [HttpPost]
        public async Task<ActionResult> Login(MensageiroLoginDto mensageiroLogin) {

            var token = await _tokenService.Login(mensageiroLogin);
          
            return Ok(token);


        }
    }
}
