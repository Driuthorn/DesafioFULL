﻿// <auto-generated />
using System;
using DesafioBackend.Data.Database.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioBackend.Data.Database.Migrations
{
    [DbContext(typeof(DesafioBackendContext))]
    [Migration("20210429031211_DesafioFULL")]
    partial class DesafioFULL
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesafioBackend.Data.Database.Entities.Parcela", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdTitulo")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NumeroParcela")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,3)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnType("Date");

                    b.HasKey("Id")
                        .HasName("PK_Parcela");

                    b.HasIndex("IdTitulo");

                    b.ToTable("Parcela");
                });

            modelBuilder.Entity("DesafioBackend.Data.Database.Entities.Titulo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPFDevedor")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nchar(12)")
                        .IsFixedLength(true);

                    b.Property<decimal>("Juros")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Multa")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("NomeDevedor")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("NumeroTitulo")
                        .HasColumnType("int");

                    b.Property<int>("QtdParcelas")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK_Titulo");

                    b.ToTable("Titulo");
                });

            modelBuilder.Entity("DesafioBackend.Data.Database.Entities.Parcela", b =>
                {
                    b.HasOne("DesafioBackend.Data.Database.Entities.Titulo", "Titulo")
                        .WithMany("Parcelas")
                        .HasForeignKey("IdTitulo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Titulo");
                });

            modelBuilder.Entity("DesafioBackend.Data.Database.Entities.Titulo", b =>
                {
                    b.Navigation("Parcelas");
                });
#pragma warning restore 612, 618
        }
    }
}
