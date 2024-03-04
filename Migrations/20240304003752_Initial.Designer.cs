﻿// <auto-generated />
using Caso_estudio1_Grupo1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Caso_estudio1_Grupo1.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240304003752_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Caso_estudio1_Grupo1.Models.Historial", b =>
                {
                    b.Property<int>("IdJuego")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdJuego"));

                    b.Property<int>("Duracion")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<bool>("Resultado")
                        .HasColumnType("bit");

                    b.Property<string>("Tablero")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdJuego");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Historial");
                });

            modelBuilder.Entity("Caso_estudio1_Grupo1.Models.Sesiones", b =>
                {
                    b.Property<string>("IdSesion")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.HasKey("IdSesion");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Sesiones");
                });

            modelBuilder.Entity("Caso_estudio1_Grupo1.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Contrasena")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Foto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdUsuario");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Caso_estudio1_Grupo1.Models.Historial", b =>
                {
                    b.HasOne("Caso_estudio1_Grupo1.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Caso_estudio1_Grupo1.Models.Sesiones", b =>
                {
                    b.HasOne("Caso_estudio1_Grupo1.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
