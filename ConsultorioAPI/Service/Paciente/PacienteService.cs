using ConsultorioAPI.DContext;
using ConsultorioAPI.Dto.Consulta;
using ConsultorioAPI.Dto.Paciente;
using ConsultorioAPI.Enum;
using ConsultorioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsultorioAPI.Service.Paciente
{
    public class PacienteService : IPacienteService
    {
        private readonly ConDbContext _context;
        public PacienteService(ConDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<List<PacienteModel>>> BuscarTodosPacientes()
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();
            try
            {
                var pacientes = await _context.Paciente.Include(con => con.Consulta).ToListAsync();

                if (pacientes == null || pacientes.Count == 0)
                {
                    resposta.Dados = null;
                    resposta.Status = false;
                    resposta.Mensagem = "Nenhum paciente localizado!";
                    return resposta;
                }
                resposta.Dados = pacientes;
                resposta.Status = true;
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<PacienteModel>> BuscarPacientePorId(int id)
        {
            ResponseModel<PacienteModel> resposta = new ResponseModel<PacienteModel>();
            try
            {
                PacienteModel paciente = await _context.Paciente.Include(con => con.Consulta).
                    FirstOrDefaultAsync(pac => pac.id == id);

                if (paciente == null)
                {
                    resposta.Dados = null;
                    resposta.Status = false;
                    resposta.Mensagem = "Nenhum paciente localizado!";
                    return resposta;
                }

                resposta.Dados = paciente;
                resposta.Status = true;
                resposta.Mensagem = "Paciente localizado!";

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            return resposta;
        }

        public async Task<ResponseModel<PacienteModel>> BuscarPacientePorNome(string nome)
        {

            ResponseModel<PacienteModel> resposta = new ResponseModel<PacienteModel>();
            try
            {
                var paciente = await _context.Paciente.Include(con => con.Consulta).
                    FirstOrDefaultAsync(pac => pac.Nome == nome);

                if (paciente == null)
                {
                    resposta.Dados = null;
                    resposta.Status = false;
                    resposta.Mensagem = "Nenhum paciente localizado!";
                    return resposta;
                }
                resposta.Dados = paciente;
                resposta.Status = true;
                resposta.Mensagem = "Paciente localizado!";
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
            return resposta;
        }

        public async Task<ResponseModel<List<PacienteModel>>> BuscarPacientePorProcedimento(EnumProcedimento procedimento)
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();
            try
            {
                var paciente = await _context.Paciente.Include(bancoconsulta => bancoconsulta.Consulta).
                    Where(proc => proc.Consulta.Procedimento == procedimento).ToListAsync();
                if (paciente == null || paciente.Count == 0)
                {
                    resposta.Mensagem = "Nenhum paciente localizado!";
                    return resposta;
                }
                resposta.Dados = paciente;
                resposta.Mensagem = "Paciente(s) Localizado(s)!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PacienteModel>>> AlterarPaciente(EditarPacienteDto editarpacientedto)
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();
            try
            {
                var paciente = await _context.Paciente.FirstOrDefaultAsync(id => id.id == editarpacientedto.Id);

                var consulta = await _context.Consulta.FirstOrDefaultAsync(con => con.id == editarpacientedto.Consulta.Id);

                if (paciente == null)
                {
                    resposta.Mensagem = "Nenhum paciente localizado!";
                    return resposta;
                }
                if (consulta == null)
                {
                    resposta.Mensagem = "Nenhuma consulta localizada!";
                    return resposta;
                }
                paciente.Nome = editarpacientedto.Nome;
                paciente.Endereco = editarpacientedto.Endereco;
                paciente.Telefone = editarpacientedto.Telefone;
                paciente.Status = true;

                _context.Update(paciente);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Paciente.ToListAsync();
                resposta.Mensagem = "Consulta Editada com Sucesso!";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PacienteModel>>> CriarPaciente(CriarPacienteDto criarpacientedto)
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();
            try
            {
                var consulta = await _context.Consulta.FirstOrDefaultAsync(pacban => pacban.id == criarpacientedto.Consulta.Id);
                if (consulta == null)
                {
                    resposta.Mensagem = "Nenhum paciente localizado!";
                    return resposta;
                }

                var novopaciente = new PacienteModel()
                {
                    Nome = criarpacientedto.Nome,
                    Endereco = criarpacientedto.Endereco,
                    Telefone = criarpacientedto.Telefone,
                    Consulta = consulta,
                    Status = true
                };
                _context.Add(novopaciente);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Paciente.Include(p => p.Consulta).ToListAsync();
                resposta.Status = true;
                resposta.Mensagem = "Paciente cadastrado com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<PacienteModel>>> DeletarPaciente(int id)
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();
            try
            {
                var parciente = await _context.Paciente.FirstOrDefaultAsync(pac => pac.id == id);
                if (parciente == null)
                {
                    resposta.Mensagem = "Nenhum paciente localizado!";
                    return resposta;
                }
                _context.Remove(parciente);
                _context.SaveChangesAsync();
                resposta.Mensagem = "Paciente deletado com sucesso!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }
        public async Task<ResponseModel<List<PacienteModel>>> BuscarPacientePorConsulta(int idConsulta)
        {
            ResponseModel<List<PacienteModel>> resposta = new ResponseModel<List<PacienteModel>>();
            try
            {
                var paciente = await _context.Paciente.Include(bancoconsulta => bancoconsulta.Consulta).Where(CodId => CodId.Consulta.id == idConsulta).ToListAsync();

                if (paciente == null || paciente.Count == 0)
                {
                    resposta.Mensagem = "Nenhum registro localizado!";
                    return resposta;
                }

                resposta.Dados = paciente;
                resposta.Mensagem = "Paciente(s) Localizado(s)!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}

