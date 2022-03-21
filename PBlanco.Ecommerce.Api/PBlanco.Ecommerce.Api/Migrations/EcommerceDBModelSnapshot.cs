﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PBlanco.Ecommerce.Api.Data;

namespace PBlanco.Ecommerce.Api.Migrations
{
    [DbContext(typeof(EcommerceDB))]
    partial class EcommerceDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.22");

            modelBuilder.Entity("PBlanco.Ecommerce.Api.Models.Carrito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.ToTable("Carrito");
                });

            modelBuilder.Entity("PBlanco.Ecommerce.Api.Models.Categorias", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionProducto")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Categoria");
                });

            modelBuilder.Entity("PBlanco.Ecommerce.Api.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DescripcionProducto")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("PBlanco.Ecommerce.Api.Models.Carrito", b =>
                {
                    b.HasOne("PBlanco.Ecommerce.Api.Models.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PBlanco.Ecommerce.Api.Models.Producto", b =>
                {
                    b.HasOne("PBlanco.Ecommerce.Api.Models.Categorias", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
