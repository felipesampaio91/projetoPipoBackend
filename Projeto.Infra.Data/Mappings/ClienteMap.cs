using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(cliente => cliente.IdCliente);

            builder.Property(cliente => cliente.IdCliente)
            .HasColumnName("IdCliente");

            builder.Property(cliente => cliente.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(60)
            .IsRequired();

            builder.Property(cliente => cliente.CNPJ)
            .HasColumnName("Cnpj")
            .HasMaxLength(25)
            .IsRequired();

            builder.Property(cliente => cliente.DataInclusao)
            .HasColumnName("DataInclusao")
            .HasColumnType("datetimeoffset")
            .IsRequired();
        }
    }
}
