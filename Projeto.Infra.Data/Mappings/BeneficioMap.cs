using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class BeneficioMap : IEntityTypeConfiguration<Beneficio>
    {
        public void Configure(EntityTypeBuilder<Beneficio> builder)
        {
            builder.ToTable("Beneficio");

            builder.HasKey(beneficio => beneficio.IdBeneficio);

            builder.Property(beneficio => beneficio.IdBeneficio)
            .HasColumnName("IdBeneficio");

            builder.Property(beneficio => beneficio.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(beneficio => beneficio.DataInclusao)
            .HasColumnName("DataInclusao")
            .HasColumnType("datetimeoffset")
            .IsRequired();

            builder.Property(beneficio => beneficio.IdOperadora)
            .HasColumnName("IdOperadora")
            .IsRequired();

            builder.HasOne(beneficio => beneficio.Operadora)
                .WithMany(operadora => operadora.Beneficios)
                .HasForeignKey(beneficio => beneficio.IdOperadora);
        }
    }
}
