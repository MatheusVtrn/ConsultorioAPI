using ConsultorioAPI.Dto.Consulta;
using ConsultorioAPI.Enum;
using ConsultorioAPI.Models;
using ConsultorioAPI.Service.Consulta;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
        private readonly IConsultaService _consultainterface;
        public ConsultaController(IConsultaService consultainterface)
        {
            _consultainterface = consultainterface;
        }

        [HttpGet("ObterTodasConsultas")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> ListarConsultas()
        {
            var consulta = await _consultainterface.BuscarTodasConsultas();
            return Ok(consulta);
        }

        [HttpGet("ObterConsultasporProcedimento")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> ListarConsultaPorProcedimento( EnumProcedimento procedimento)
        {
            var consulta = await _consultainterface.BuscarConsultaPorProcedimento(procedimento);
            return Ok(consulta);
        }

        [HttpPut("AlterarConsulta")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> AlterarConsulta(EditarConsultaDto editarconsultacto)
        {
            var consulta = await _consultainterface.AlterarConsulta(editarconsultacto);
            return Ok(consulta);
        }

        [HttpDelete("DeletarConsulta")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> DeletarConsultas(int id)
        {
            var consulta = await _consultainterface.DeletarConsulta(id);
            return Ok(consulta);
        }

        [HttpPost("CadastrarConsulta")]
        public async Task<ActionResult<ResponseModel<ConsultaModel>>> CriarConsulta(CriarConsultaDto consultadto)
        {
            var addconsulta = await _consultainterface.CriarConsulta(consultadto);
            return Ok(addconsulta);
        }
    }
}
