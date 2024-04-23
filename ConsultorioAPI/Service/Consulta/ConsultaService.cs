using ConsultorioAPI.DContext;
using ConsultorioAPI.Dto.Consulta;
using ConsultorioAPI.Enum;
using ConsultorioAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.Runtime.Serialization;

namespace ConsultorioAPI.Service.Consulta
{
    public class ConsultaService : IConsultaService
    {
        private readonly ConDbContext _context;
        public ConsultaService(ConDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<ConsultaModel>>> AlterarConsulta(EditarConsultaDto editarConsultaDto)
        {
            ResponseModel<List<ConsultaModel>> resposta = new ResponseModel<List<ConsultaModel>>();
            try
            {
                var consulta = await _context.Consulta.FirstOrDefaultAsync(id => id.id == editarConsultaDto.Id);

                if (consulta == null)
                {
                    resposta.Mensagem = "Nenhuma consulta localizado!";
                    return resposta;
                }
                consulta.Procedimento = editarConsultaDto.Procedimento;
                consulta.Confirmacao = editarConsultaDto.Confirmacao;
                consulta.DataConsulta = editarConsultaDto.DataConsulta;
                consulta.HorarioConsulta = editarConsultaDto.HorarioConsulta;
               
                _context.Update(consulta);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Consulta.ToListAsync();
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

        public async Task<ResponseModel<List<ConsultaModel>>> BuscarConsultaPorProcedimento(EnumProcedimento procedimento)
        {
            ResponseModel<List<ConsultaModel>> resposta = new ResponseModel<List<ConsultaModel>>();
            try
            {
                var Consulta = await _context.Consulta.Where(proc => proc.Procedimento == procedimento).ToListAsync();

                if (Consulta == null || Consulta.Count==0)
                {
                    resposta.Mensagem = "Nenhuma consulta localizada!";
                    return resposta;
                }

                resposta.Dados = Consulta;
                resposta.Mensagem = "Consulta(s) Localizada(s)!";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }           
        }

        public async Task<ResponseModel<List<ConsultaModel>>> BuscarTodasConsultas()
        {
            ResponseModel<List<ConsultaModel>> resposta = new ResponseModel<List<ConsultaModel>>();
            try
            {
                var consulta = await _context.Consulta.ToListAsync();
                resposta.Dados = consulta;
                resposta.Mensagem = "Todos as consultas foram coletadas!";
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
     
        public async Task<ResponseModel<List<ConsultaModel>>> CriarConsulta(CriarConsultaDto criarConsultaDto)
        {
            ResponseModel<List<ConsultaModel>> resposta = new ResponseModel<List<ConsultaModel>>();
            try
            {
                var novaconsulta = new ConsultaModel()
                {
                    DataConsulta = criarConsultaDto.DataConsulta,
                    HorarioConsulta = criarConsultaDto.HorarioConsulta,
                    Confirmacao = criarConsultaDto.Confirmacao,
                    Procedimento = criarConsultaDto.Procedimento,
                    Status = criarConsultaDto.Status
                };
                _context.Add(novaconsulta);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Consulta.ToListAsync();
                resposta.Mensagem = "Consulta marcada com sucesso!";

                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<List<ConsultaModel>>> DeletarConsulta(int id)
        {
            ResponseModel<List<ConsultaModel>> resposta = new ResponseModel<List<ConsultaModel>>();
            try
            {
                var consulta = await _context.Consulta
                    .FirstOrDefaultAsync(Consultabanco => Consultabanco.id == id);

                if (consulta == null)
                {
                    resposta.Mensagem = "Nenhuma consulta localizada!";
                    return resposta;
                }

                _context.Remove(consulta);
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Consulta.ToListAsync();
                resposta.Mensagem = "Consulta Removida com sucesso!";

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
