using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Infra.Data.Mappings
{
    public class ClienteBeneficioMap : IEntityTypeConfiguration<ClienteBeneficio>
    {
        public void Configure(EntityTypeBuilder<ClienteBeneficio> builder)
        {
            builder.ToTable("ClienteBeneficio");

            builder.HasKey(clienteBeneficio => clienteBeneficio.Id);

            builder.Property(clienteBeneficio => clienteBeneficio.Id)
            .HasColumnName("Id");

            builder.Property(clienteBeneficio => clienteBeneficio.IdCliente)
            .HasColumnName("IdCliente");

            builder.Property(clienteBeneficio => clienteBeneficio.IdBeneficio)
            .HasColumnName("IdBeneficio");

            builder.Property(clienteBeneficio => clienteBeneficio.DataInclusao)
           .HasColumnName("DataInclusao")
           .HasColumnType("datetimeoffset")
           .IsRequired();



            builder.HasOne(clienteBeneficio => clienteBeneficio.Beneficio)
                .WithMany(beneficio => beneficio.ClienteBeneficios)
                .HasForeignKey(clienteBeneficio => clienteBeneficio.IdBeneficio);

            builder.HasOne(clienteBeneficio => clienteBeneficio.Cliente)
                .WithMany(cliente => cliente.ClienteBeneficios)
                .HasForeignKey(clienteBeneficio => clienteBeneficio.IdCliente);
        }
    }
}
