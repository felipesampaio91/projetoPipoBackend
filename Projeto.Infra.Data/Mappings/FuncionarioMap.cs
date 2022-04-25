using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class FuncionarioMap : IEntityTypeConfiguration<Funcionario>
    {
        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.ToTable("Funcionario");

            builder.HasKey(funcionario => funcionario.IdFuncionario);

            builder.Property(funcionario => funcionario.IdFuncionario)
            .HasColumnName("IdFuncionario");

            builder.Property(funcionario => funcionario.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(60)
            .IsRequired();

            builder.Property(funcionario => funcionario.Cpf)
            .HasColumnName("Cpf")
            .HasMaxLength(11)
            .IsRequired();

            builder.Property(funcionario => funcionario.Email)
            .HasColumnName("Email")
            .IsRequired();

            builder.Property(funcionario => funcionario.DataAdmissao)
            .HasColumnName("DataCadastro")
            .HasColumnType("date")
            .IsRequired();

            builder.Property(funcionario => funcionario.Endereco)
            .HasColumnName("Endereco")
            .HasMaxLength(60)
            .IsRequired();

            builder.Property(funcionario => funcionario.Peso)
            .HasColumnName("Peso")
            .HasColumnType("decimal(5,2)");


            builder.Property(funcionario => funcionario.Altura)
            .HasColumnName("Altura")
            .HasColumnType("decimal(5,2)");

            builder.Property(funcionario => funcionario.DataInclusao)
            .HasColumnName("DataInclusao")
            .HasColumnType("datetimeoffset")
            .IsRequired();

            builder.Property(funcionario => funcionario.IdCliente)
            .HasColumnName("IdCliente")
            .IsRequired();

            builder.HasOne(funcionario => funcionario.Cliente)
                .WithMany(cliente => cliente.Funcionarios)
                .HasForeignKey(funcionario => funcionario.IdCliente); 
        }
    }
}



