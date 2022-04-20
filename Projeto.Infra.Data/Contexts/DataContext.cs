using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        { }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Operadora> Operadora { get; set; }
        public DbSet<Beneficio> Beneficio { get; set; }
        public DbSet<ClienteBeneficio> ClienteBeneficio{ get; set; }
        public DbSet<FuncionarioBeneficio> FuncionarioBeneficio { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new OperadoraMap());
            modelBuilder.ApplyConfiguration(new BeneficioMap());
            modelBuilder.ApplyConfiguration(new FuncionarioBeneficioMap());
            modelBuilder.ApplyConfiguration(new ClienteBeneficioMap());
        }
    }
}
