using ConsultorioAPI.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConsultorioAPI.Models
{
    public class ConsultaModel
    {
        
        public int id { get; set; }
        public DateTime DataConsulta { get; set; }

        public DateTime HorarioConsulta { get; set; }

        public bool Confirmacao { get; set; }
        public EnumProcedimento Procedimento { get; set; }
        public bool Status { get; set; }
        [JsonIgnore]
        public ICollection<PacienteModel> Paciente { get; set; }

    }
}
