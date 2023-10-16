﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoBaseNetCore;

#nullable disable

namespace ProyectoBaseNetCore.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231014195713_vet.002")]
    partial class vet002
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("Role", "SEG");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleClaim", "SEG");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaim", "SEG");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogin", "SEG");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", "SEG");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UsersToken", "SEG");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<bool>("Bloqueo")
                        .HasColumnType("bit");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("Users", "SEG");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.Clientes", b =>
                {
                    b.Property<long>("IdCliente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCliente"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Apellidos")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Identificacion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IpEliminacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("IpModificacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("IpRegistro")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Nombres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SesionEliminacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SesionModificacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SesionRegistro")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SistemaEliminacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SistemaModificacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SistemaRegistro")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Telefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UsuarioEliminacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("UsuarioModificacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("UsuarioRegistro")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("IdCliente");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Catalog", b =>
                {
                    b.Property<long>("IdCatalog")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCatalog"));

                    b.Property<string>("CatalogName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdCatalog");

                    b.ToTable("Catalogs", "CAT");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.CatalogItem", b =>
                {
                    b.Property<long>("IdCatalogItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdCatalogItem"));

                    b.Property<int>("CatalogOrder")
                        .HasColumnType("int");

                    b.Property<long>("IdCatalog")
                        .HasColumnType("bigint");

                    b.Property<long>("IdItem")
                        .HasColumnType("bigint");

                    b.Property<int>("ItemOrder")
                        .HasColumnType("int");

                    b.HasKey("IdCatalogItem");

                    b.HasIndex("IdCatalog");

                    b.HasIndex("IdItem");

                    b.ToTable("CatalogItems", "CAT");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Form", b =>
                {
                    b.Property<long>("IdForm")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdForm"));

                    b.Property<string>("FormName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdForm");

                    b.ToTable("Forms", "CAT");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.FormSectionQuestion", b =>
                {
                    b.Property<long>("IdFormSectionQuestion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdFormSectionQuestion"));

                    b.Property<int>("FormOrder")
                        .HasColumnType("int");

                    b.Property<long>("IdForm")
                        .HasColumnType("bigint");

                    b.Property<long>("IdQuestion")
                        .HasColumnType("bigint");

                    b.Property<long>("IdSection")
                        .HasColumnType("bigint");

                    b.Property<int>("QuestionOrder")
                        .HasColumnType("int");

                    b.Property<int>("SectionOrder")
                        .HasColumnType("int");

                    b.HasKey("IdFormSectionQuestion");

                    b.HasIndex("IdForm");

                    b.HasIndex("IdQuestion");

                    b.HasIndex("IdSection");

                    b.ToTable("FormSectionQuestions", "CAT");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Item", b =>
                {
                    b.Property<long>("IdItem")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdItem"));

                    b.Property<long?>("CatalogIdCatalog")
                        .HasColumnType("bigint");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdItem");

                    b.HasIndex("CatalogIdCatalog");

                    b.ToTable("Items", "CAT");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Question", b =>
                {
                    b.Property<long>("IdQuestion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdQuestion"));

                    b.Property<long?>("IdCatalog")
                        .HasColumnType("bigint");

                    b.Property<long>("IdQuestionType")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMultiAnswer")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<int>("MaxAnswersCount")
                        .HasColumnType("int");

                    b.Property<int>("MinAnswersCount")
                        .HasColumnType("int");

                    b.Property<int>("MinRequiredAnswersCount")
                        .HasColumnType("int");

                    b.Property<string>("Placeholder")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionDesc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("QuestionTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdQuestion");

                    b.HasIndex("IdCatalog");

                    b.HasIndex("IdQuestionType");

                    b.ToTable("Questions", "CAT");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.QuestionType", b =>
                {
                    b.Property<long>("IdQuestionType")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdQuestionType"));

                    b.Property<string>("QuestionTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdQuestionType");

                    b.ToTable("QuestionTypes", "CAT");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Section", b =>
                {
                    b.Property<long>("IdSection")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdSection"));

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRequired")
                        .HasColumnType("bit");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdSection");

                    b.ToTable("Sections", "CAT");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.Mascotas", b =>
                {
                    b.Property<long>("IdMascotas")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("IdMascotas"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<string>("Direccion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<DateTime?>("FechaEliminacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaModificacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<long?>("IdCliente")
                        .HasColumnType("bigint");

                    b.Property<string>("IpEliminacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("IpModificacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("IpRegistro")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("NombreMascota")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Raza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SesionEliminacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SesionModificacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SesionRegistro")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("Sexo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SistemaEliminacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SistemaModificacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("SistemaRegistro")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("UsuarioEliminacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("UsuarioModificacion")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.Property<string>("UsuarioRegistro")
                        .HasMaxLength(350)
                        .HasColumnType("nvarchar(350)");

                    b.HasKey("IdMascotas");

                    b.HasIndex("IdCliente");

                    b.ToTable("Mascotas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ProyectoBaseNetCore.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ProyectoBaseNetCore.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoBaseNetCore.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ProyectoBaseNetCore.Entities.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.CatalogItem", b =>
                {
                    b.HasOne("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Catalog", "Catalog")
                        .WithMany("CatalogItems")
                        .HasForeignKey("IdCatalog")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Item", "Item")
                        .WithMany("CatalogItems")
                        .HasForeignKey("IdItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalog");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.FormSectionQuestion", b =>
                {
                    b.HasOne("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Form", "Form")
                        .WithMany("FormSectionQuestions")
                        .HasForeignKey("IdForm")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Question", "Question")
                        .WithMany("FormSectionQuestions")
                        .HasForeignKey("IdQuestion")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Section", "Section")
                        .WithMany("FormSectionQuestions")
                        .HasForeignKey("IdSection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("Question");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Item", b =>
                {
                    b.HasOne("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Catalog", null)
                        .WithMany("Items")
                        .HasForeignKey("CatalogIdCatalog");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Question", b =>
                {
                    b.HasOne("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Catalog", "Catalog")
                        .WithMany("Questions")
                        .HasForeignKey("IdCatalog");

                    b.HasOne("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.QuestionType", "QuestionType")
                        .WithMany("Questions")
                        .HasForeignKey("IdQuestionType")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalog");

                    b.Navigation("QuestionType");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.Mascotas", b =>
                {
                    b.HasOne("ProyectoBaseNetCore.Entities.Clientes", "Cliente")
                        .WithMany("Mascotas")
                        .HasForeignKey("IdCliente");

                    b.Navigation("Cliente");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.Clientes", b =>
                {
                    b.Navigation("Mascotas");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Catalog", b =>
                {
                    b.Navigation("CatalogItems");

                    b.Navigation("Items");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Form", b =>
                {
                    b.Navigation("FormSectionQuestions");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Item", b =>
                {
                    b.Navigation("CatalogItems");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Question", b =>
                {
                    b.Navigation("FormSectionQuestions");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.QuestionType", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ProyectoBaseNetCore.Entities.DinamicQuestionEntities.Section", b =>
                {
                    b.Navigation("FormSectionQuestions");
                });
#pragma warning restore 612, 618
        }
    }
}