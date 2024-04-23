using ConsultorioAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ConsultorioAPI.DContext
{
    public class ConDbContext : DbContext
    {
        public ConDbContext(DbContextOptions<ConDbContext> options) : base(options)
        {
            
        }
        public DbSet<ConsultaModel> Consulta { get; set; }
        public DbSet<PacienteModel> Paciente { get; set; }

    }
}
