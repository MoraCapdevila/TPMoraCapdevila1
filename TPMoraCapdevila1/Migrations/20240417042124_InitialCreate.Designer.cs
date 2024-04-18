﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TPMoraCapdevila1.Data.Context;

#nullable disable

namespace TPMoraCapdevila1.Migrations
{
    [DbContext(typeof(TodoContext))]
    [Migration("20240417042124_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.0");

            modelBuilder.Entity("TPMoraCapdevila1.Data.Entities.TodoItem", b =>
                {
                    b.Property<int>("IdTodoItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("IdTodoItem");

                    b.HasIndex("UserId");

                    b.ToTable("TodoItems");

                    b.HasData(
                        new
                        {
                            IdTodoItem = 1,
                            Description = "Comprar milanesas, tomate y papas",
                            Title = "Ir al super",
                            UserId = 1
                        },
                        new
                        {
                            IdTodoItem = 2,
                            Description = "Comprar cuadernillo y birome negra",
                            Title = "Ir a la libreria",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("TPMoraCapdevila1.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Adress")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Adress = "Pellegrini 1876",
                            Email = "moracapdevila@gmail.com",
                            Name = "Mora"
                        },
                        new
                        {
                            UserId = 2,
                            Adress = "Dorrego 1515",
                            Email = "juanita@gmail.com",
                            Name = "Juana"
                        });
                });

            modelBuilder.Entity("TPMoraCapdevila1.Data.Entities.TodoItem", b =>
                {
                    b.HasOne("TPMoraCapdevila1.Entities.User", "User")
                        .WithMany("TodoItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TPMoraCapdevila1.Entities.User", b =>
                {
                    b.Navigation("TodoItems");
                });
#pragma warning restore 612, 618
        }
    }
}
