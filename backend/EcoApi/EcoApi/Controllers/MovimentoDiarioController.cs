using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoApi.Controllers {
    [Route("api/doacao")]
    [ApiController]
    public class MovimentoDiarioController : Controller {

        private readonly IMovimentoDiarioInterface _movimentoDiarioInterface;

        public MovimentoDiarioController(IMovimentoDiarioInterface movimentoDiarioInterface) {

            _movimentoDiarioInterface = movimentoDiarioInterface;
        }

        [HttpGet("listarMovimentoDiario")]
        public async Task<ActionResult<ServiceResponse<List<MovimentoDiarioModel>>>> GetMovimentoDiario() {

            var result = await _movimentoDiarioInterface.GetMovimentoDiario();

            return Ok(result);
        }
        [HttpGet("movimentoDiario/{id}")]
        public async Task<ActionResult<ServiceResponse<MovimentoDiarioModel>>> GetMovimentoDiarioById(int id) {

            var result = await _movimentoDiarioInterface.GetMovimentoDiarioById(id);

            return Ok(result);
        }
        [HttpPost("cadastrarMovimentoDiario")]
        public async Task<ActionResult<ServiceResponse<MovimentoDiarioModel>>> CreateMensageiro(MovimentoDiarioModel movimentoDiario) {

            var result = await _movimentoDiarioInterface.CreateMovimentoDiario(movimentoDiario);

            return Ok(result);
        }
    }
}
