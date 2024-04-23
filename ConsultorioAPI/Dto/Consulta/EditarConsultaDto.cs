using ConsultorioAPI.Enum;

namespace ConsultorioAPI.Dto.Consulta
{
    public class EditarConsultaDto
    {
        public int Id { get; set; }
        public DateTime DataConsulta { get; set; }

        public DateTime HorarioConsulta { get; set; }

        public bool Confirmacao { get; set; }
        public EnumProcedimento Procedimento { get; set; }
        public bool Status { get; set; }


    }
}
