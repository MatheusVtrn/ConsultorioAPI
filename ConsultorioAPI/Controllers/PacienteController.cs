using ConsultorioAPI.Dto.Paciente;
using ConsultorioAPI.Enum;
using ConsultorioAPI.Models;
using ConsultorioAPI.Service.Consulta;
using ConsultorioAPI.Service.Paciente;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteService _pacienteservice;
        public PacienteController(IPacienteService pacienteservice)
        {
            _pacienteservice = pacienteservice;
        }
        
        [HttpGet("BuscarTodosPacientes")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> ListarTodosPacientes()
        {
            var paciente = await _pacienteservice.BuscarTodosPacientes();
            return Ok(paciente);
        }

        [HttpGet("BuscarPacientesporId")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> ListarPacientesPorId(int id)
        {
            var paciente = await _pacienteservice.BuscarPacientePorId(id);
            return Ok(paciente);
        }

        [HttpGet("BuscarPacientesporNome")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> ListarPacientesPorNome(string Nome)
        {
            var paciente = await _pacienteservice.BuscarPacientePorNome(Nome);
            return Ok(paciente);
        }
        
        [HttpGet("ListarPacientesporProcedimento")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> ListarPacientesPorProcedimento(EnumProcedimento procedimento)
        {
            var paciente = await _pacienteservice.BuscarPacientePorProcedimento(procedimento);
            return Ok(paciente);
        }

        [HttpGet("ListarPacientesporConsulta")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> ListarPacientesPorConsulta(int id)
        {
            var paciente = await _pacienteservice.BuscarPacientePorConsulta(id);
            return Ok(paciente);
        }

        [HttpPut("AlterarPaciente")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> AlterarPaciente(EditarPacienteDto editarPacienteDto)
        {
            var Paciente = await _pacienteservice.AlterarPaciente(editarPacienteDto);
            return Ok(Paciente);
        }

        [HttpPost("CadastrarPaciente")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> CriarPaciente(CriarPacienteDto criarPacienteDto)
        {
            var Paciente = await _pacienteservice.CriarPaciente(criarPacienteDto);
            return Ok(Paciente);
        }

        [HttpDelete("DeletarPaciente")]
        public async Task<ActionResult<List<ResponseModel<ConsultaModel>>>> DeletarPaciente(int id )
        {
            var Paciente = await _pacienteservice.DeletarPaciente(id);
            return Ok(Paciente);
        }
    }
}
