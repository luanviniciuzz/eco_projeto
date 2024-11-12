using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoApi.Controllers {

    [Route("api/doacao")]
    [ApiController]
    public class MensageiroControllers : Controller {

        private readonly IMensageiroInterface _mesageiroInterface;

        public MensageiroControllers(IMensageiroInterface mensageiroInterface) {

            _mesageiroInterface = mensageiroInterface;
        }

        [HttpGet("listarMensageiro")]
        public async Task<ActionResult<ServiceResponse<List<MensageiroModel>>>> GetMensageiro() {

            var result = await _mesageiroInterface.GetMensageiro();

            return Ok(result);
        }
        [HttpGet("mensageiro/{id}")]
        public async Task<ActionResult<ServiceResponse<MensageiroModel>>> GetMensageiroById(int id) {

            var result = await _mesageiroInterface.GetMensageiroById(id);

            return Ok(result);
        }
        [HttpPost("cadastrarMensageiro")]
        public async Task<ActionResult<ServiceResponse<MensageiroModel>>> CreateMensageiro(MensageiroModel mensageiro) {

            var result = await _mesageiroInterface.CreateMensageiro(mensageiro);

            return Ok(result);
        }
    }
}
