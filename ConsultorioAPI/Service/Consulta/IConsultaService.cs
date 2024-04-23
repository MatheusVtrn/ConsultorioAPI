using ConsultorioAPI.Dto.Consulta;
using ConsultorioAPI.Enum;
using ConsultorioAPI.Models;

namespace ConsultorioAPI.Service.Consulta
{
    public interface IConsultaService
    {
        //EndPoints solicitados
        // CRIAR CONSULTA
        
        Task<ResponseModel<List<ConsultaModel>>> CriarConsulta(CriarConsultaDto criarConsultaDto); 
        // DELETAR CONSULTA
        Task<ResponseModel<List<ConsultaModel>>> DeletarConsulta(int id);
        //ALTERAR CONSULTA
        Task<ResponseModel<List<ConsultaModel>>> AlterarConsulta(EditarConsultaDto editarConsultaDto);
        
        // BUSCAR TODAS AS CONSULTAS
        Task<ResponseModel<List<ConsultaModel>>> BuscarTodasConsultas();
        // BUSCAR CONSULTAS POR PROCEDIMENTO
        Task<ResponseModel<List<ConsultaModel>>> BuscarConsultaPorProcedimento(EnumProcedimento procedimento);

    }
}
