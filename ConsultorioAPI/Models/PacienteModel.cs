using System.ComponentModel.DataAnnotations;

namespace ConsultorioAPI.Models
{
    public class PacienteModel
    {
        
        public int id { get; set; }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public bool Status{ get; set; }
        public ConsultaModel Consulta { get; set; }


    }
}
