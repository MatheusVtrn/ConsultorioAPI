﻿using ConsultorioAPI.Dto.LinkPacienteConsulta;

namespace ConsultorioAPI.Dto.Paciente
{
    public class CriarPacienteDto
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public LinkPacCons Consulta {  get; set; } 
        

    }
}
