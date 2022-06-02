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

            builder.HasKey(clienteBeneficio => clienteBeneficio.IdClienteBeneficio);

            builder.Property(clienteBeneficio => clienteBeneficio.IdClienteBeneficio)
            .HasColumnName("IdClienteBeneficio")
           .IsRequired();

            builder.Property(clienteBeneficio => clienteBeneficio.IdCliente)
            .HasColumnName("IdCliente")
           .IsRequired();

            builder.Property(clienteBeneficio => clienteBeneficio.IdBeneficio)
            .HasColumnName("IdBeneficio")
           .IsRequired();

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
