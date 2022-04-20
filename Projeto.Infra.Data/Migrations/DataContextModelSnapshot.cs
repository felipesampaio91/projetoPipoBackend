﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto.Infra.Data.Contexts;

namespace Projeto.Infra.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Projeto.Domain.Entities.Beneficio", b =>
                {
                    b.Property<int>("IdBeneficio")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdBeneficio")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnName("DataInclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdOperadora")
                        .HasColumnName("IdOperadora")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdBeneficio");

                    b.HasIndex("IdOperadora");

                    b.ToTable("Beneficio");
                });

            modelBuilder.Entity("Projeto.Domain.Entities.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdCliente")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnName("Cnpj")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnName("DataInclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Projeto.Domain.Entities.ClienteBeneficio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnName("DataInclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdBeneficio")
                        .HasColumnName("IdBeneficio")
                        .HasColumnType("int");

                    b.Property<int>("IdCliente")
                        .HasColumnName("IdCliente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBeneficio");

                    b.HasIndex("IdCliente");

                    b.ToTable("ClienteBeneficio");
                });

            modelBuilder.Entity("Projeto.Domain.Entities.Funcionario", b =>
                {
                    b.Property<int>("IdFuncionario")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdFuncionario")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Altura")
                        .HasColumnName("Altura")
                        .HasColumnType("decimal(5,2)");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasColumnName("Cpf")
                        .HasColumnType("nvarchar(11)")
                        .HasMaxLength(11);

                    b.Property<DateTime>("DataAdmissao")
                        .HasColumnName("DataCadastro")
                        .HasColumnType("date");

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnName("DataInclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasColumnName("Endereco")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<int>("IdCliente")
                        .HasColumnName("IdCliente")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.Property<decimal>("Peso")
                        .HasColumnName("Peso")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("IdFuncionario");

                    b.HasIndex("IdCliente");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("Projeto.Domain.Entities.FuncionarioBeneficio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnName("DataInclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<int>("IdBeneficio")
                        .HasColumnName("IdBeneficio")
                        .HasColumnType("int");

                    b.Property<int>("IdFuncionario")
                        .HasColumnName("IdCliente")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdBeneficio");

                    b.HasIndex("IdFuncionario");

                    b.ToTable("FuncionarioBeneficio");
                });

            modelBuilder.Entity("Projeto.Domain.Entities.Operadora", b =>
                {
                    b.Property<int>("IdOperadora")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IdOperadora")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CNPJ")
                        .IsRequired()
                        .HasColumnName("Cnpj")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<DateTimeOffset>("DataInclusao")
                        .HasColumnName("DataInclusao")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdOperadora");

                    b.ToTable("Operadora");
                });

            modelBuilder.Entity("Projeto.Domain.Entities.Beneficio", b =>
                {
                    b.HasOne("Projeto.Domain.Entities.Operadora", "Operadora")
                        .WithMany("Beneficios")
                        .HasForeignKey("IdOperadora")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto.Domain.Entities.ClienteBeneficio", b =>
                {
                    b.HasOne("Projeto.Domain.Entities.Beneficio", "Beneficio")
                        .WithMany("ClienteBeneficios")
                        .HasForeignKey("IdBeneficio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto.Domain.Entities.Cliente", "Cliente")
                        .WithMany("ClienteBeneficios")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto.Domain.Entities.Funcionario", b =>
                {
                    b.HasOne("Projeto.Domain.Entities.Cliente", "Cliente")
                        .WithMany("Funcionarios")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Projeto.Domain.Entities.FuncionarioBeneficio", b =>
                {
                    b.HasOne("Projeto.Domain.Entities.Beneficio", "Beneficio")
                        .WithMany("FuncionarioBeneficios")
                        .HasForeignKey("IdBeneficio")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Projeto.Domain.Entities.Funcionario", "Funcionario")
                        .WithMany("FuncionarioBeneficios")
                        .HasForeignKey("IdFuncionario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
