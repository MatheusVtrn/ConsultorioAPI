using ConsultorioAPI.Enum;
using System.Runtime.Serialization;

namespace ConsultorioAPI.Dto.LinkPacienteConsulta
{
    public class LinkPacCons
    {
        public int Id { get; set; }

        public DateTime DataConsulta { get; set; }

        public DateTime HorarioConsulta { get; set; }

        public bool Confirmacao { get; set; }
        public EnumProcedimento Procedimento { get; set; }
    }
}
