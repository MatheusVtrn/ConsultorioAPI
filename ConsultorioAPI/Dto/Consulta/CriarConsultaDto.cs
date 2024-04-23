using ConsultorioAPI.Enum;
using ConsultorioAPI.Models;
using System.Text.Json.Serialization;

namespace ConsultorioAPI.Dto.Consulta
{
    public class CriarConsultaDto
    {

        public DateTime DataConsulta { get; set; }

        public DateTime HorarioConsulta { get; set; }

        public bool Confirmacao { get; set; }

        public EnumProcedimento Procedimento { get; set; }
        public bool Status { get; set; }

    }
}
