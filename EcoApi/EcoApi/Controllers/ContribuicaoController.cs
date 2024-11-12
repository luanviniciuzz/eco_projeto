using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EcoApi.Controllers {
    [Route("api/doacao")]
    [ApiController]
    [Authorize]
    public class ContribuicaoController : Controller {
        private readonly IContribuicaoInterface _contribuinteInterface;

        public ContribuicaoController(IContribuicaoInterface contribuicaoInterface) {

            _contribuinteInterface = contribuicaoInterface;
        }

        [HttpGet("listarContribuicao")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<List<ContribuicaoModel>>>> GetContribuicao() {

            var result = await _contribuinteInterface.GetContribuicao();

            return Ok(result);
        }
        [HttpGet("contribuicao/{id}")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<ContribuicaoModel>>> GetContribuicaoById(int id) {

            var result = await _contribuinteInterface.GetContribuicaoById(id);

            return Ok(result);
        }
        [HttpPost("cadastrarContribuicao")]
        [Authorize]
        public async Task<ActionResult<ServiceResponse<ContribuicaoModel>>> CreateMensageiro(ContribuicaoModel contribuicao) {

            var result = await _contribuinteInterface.CreateContribuicao(contribuicao);

            return Ok(result);
        }
    }
}
