using EcoApi.Interfaces;
using EcoApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace EcoApi.Controllers {

        [Route("api/doacao")]
        [ApiController]
        public class ContribuinteController : Controller {

            private readonly IContribuinteInterface _contribuinteInterface;

            public ContribuinteController(IContribuinteInterface contribuinteInterface) {

                _contribuinteInterface = contribuinteInterface;
            }

            [HttpGet("listarContribuinte")]
            public async Task<ActionResult<ServiceResponse<List<ContribuinteModel>>>> GetContribuinte() {

                var result = await _contribuinteInterface.GetContribuinte();

                return Ok(result);
            }
            [HttpGet("contribuinte/{id}")]
            public async Task<ActionResult<ServiceResponse<ContribuinteModel>>> GetContribuinteById(int id) {

                var result = await _contribuinteInterface.GetContribuinteById(id);

                return Ok(result);
            }
            [HttpPost("cadastrarContribuinte")]
            public async Task<ActionResult<ServiceResponse<ContribuinteModel>>> CreateMensageiro(ContribuinteModel contribuinte) {

                var result = await _contribuinteInterface.CreateContribuinte(contribuinte);

                return Ok(result);
            }
        }
    
}
