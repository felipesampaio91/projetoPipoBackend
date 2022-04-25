using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class OperadoraMap : IEntityTypeConfiguration<Operadora>
    {
        public void Configure(EntityTypeBuilder<Operadora> builder)
        {
            builder.ToTable("Operadora");

            builder.HasKey(operadora => operadora.IdOperadora);

            builder.Property(operadora => operadora.IdOperadora)
            .HasColumnName("IdOperadora");

            builder.Property(operadora => operadora.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(50)
            .IsRequired();

            builder.Property(operadora => operadora.Cnpj)
            .HasColumnName("Cnpj")
            .HasMaxLength(25)
            .IsRequired();

            builder.Property(operadora => operadora.DataInclusao)
            .HasColumnName("DataInclusao")
            .HasColumnType("datetimeoffset")
            .IsRequired();
        }
    }
}
