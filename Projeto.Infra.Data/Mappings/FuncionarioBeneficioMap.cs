using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class FuncionarioBeneficioMap : IEntityTypeConfiguration<FuncionarioBeneficio>
    {
        public void Configure(EntityTypeBuilder<FuncionarioBeneficio> builder)
        {
            builder.ToTable("FuncionarioBeneficio");

            builder.HasKey(funcionarioBeneficio => funcionarioBeneficio.IdFuncionarioBeneficio);

            builder.Property(funcionarioBeneficio => funcionarioBeneficio.IdFuncionarioBeneficio)
            .HasColumnName("IdFuncionarioBeneficio")
           .IsRequired();

            builder.Property(funcionarioBeneficio => funcionarioBeneficio.IdFuncionario)
            .HasColumnName("IdCliente")
           .IsRequired();

            builder.Property(funcionarioBeneficio => funcionarioBeneficio.IdBeneficio)
            .HasColumnName("IdBeneficio")
           .IsRequired();

            builder.Property(funcionarioBeneficio => funcionarioBeneficio.DataInclusao)
           .HasColumnName("DataInclusao")
           .HasColumnType("datetimeoffset")
           .IsRequired();

            builder.HasOne(funcionarioBeneficio => funcionarioBeneficio.Funcionario)
                .WithMany(funcionario => funcionario.FuncionarioBeneficios)
                .HasForeignKey(funcionarioBeneficio => funcionarioBeneficio.IdFuncionario);

            builder.HasOne(funcionarioBeneficio => funcionarioBeneficio.Beneficio)
                .WithMany(beneficio => beneficio.FuncionarioBeneficios)
                .HasForeignKey(funcionarioBeneficio => funcionarioBeneficio.IdBeneficio);
        }
    }
}
