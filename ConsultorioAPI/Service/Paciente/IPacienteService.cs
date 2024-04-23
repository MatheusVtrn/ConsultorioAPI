using ConsultorioAPI.Dto.Paciente;
using ConsultorioAPI.Enum;
using ConsultorioAPI.Models;

namespace ConsultorioAPI.Service.Paciente
{
    public interface IPacienteService
    {
        //EndPoints Solicitados

        //Buscar todos Pacientes
        Task<ResponseModel<List<PacienteModel>>> BuscarTodosPacientes();

        //Buscar Paciente por Id
        Task<ResponseModel<PacienteModel>> BuscarPacientePorId(int id);
        //Buscar Paciente por Nome
        Task<ResponseModel<PacienteModel>> BuscarPacientePorNome(string nome);
        //Buscar Paciente por procedimento
        Task<ResponseModel<List<PacienteModel>>> BuscarPacientePorProcedimento (EnumProcedimento procedimento);
        Task<ResponseModel<List<PacienteModel>>> BuscarPacientePorConsulta(int idConsulta);
        //Criar Paciente
        Task<ResponseModel<List<PacienteModel>>> CriarPaciente(CriarPacienteDto criarpacientedto);
        //Alterar Paciente
        Task<ResponseModel<List<PacienteModel>>> AlterarPaciente(EditarPacienteDto editarpacientedto);
        //Deletar Paciente
        Task<ResponseModel<List<PacienteModel>>> DeletarPaciente(int id); 



    }
}
