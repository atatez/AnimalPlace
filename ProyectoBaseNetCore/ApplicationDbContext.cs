using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Entities.DinamicQuestionEntities;

namespace ProyectoBaseNetCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "SEG");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UsersToken", "SEG");
            modelBuilder.Entity<IdentityRole>().ToTable("Role", "SEG");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim", "SEG");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRole", "SEG");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim", "SEG");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogin", "SEG");
            modelBuilder.Entity<Form>().ToTable("Forms", "CAT");
            modelBuilder.Entity<Section>().ToTable("Sections", "CAT");
            modelBuilder.Entity<Question>().ToTable("Questions", "CAT");
            modelBuilder.Entity<FormSectionQuestion>().ToTable("FormSectionQuestions", "CAT");
            modelBuilder.Entity<QuestionType>().ToTable("QuestionTypes", "CAT");
            modelBuilder.Entity<Item>().ToTable("Items", "CAT");
            modelBuilder.Entity<Catalog>().ToTable("Catalogs", "CAT");
            modelBuilder.Entity<CatalogItem>().ToTable("CatalogItems", "CAT");

            // Configuración de las relaciones entre Clientes y Mascotas
            modelBuilder.Entity<Clientes>()
                .HasMany(c => c.Mascotas)
                .WithOne(m => m.Cliente)
                .HasForeignKey(m => m.IdCliente);

            // Configuración de las relaciones entre Enfermedad y TipoEnfermedad
            modelBuilder.Entity<Enfermedad>()
                .HasMany(e => e.Tipos)
                .WithOne(t => t.Enfermedad)
                .HasForeignKey(t => t.IdEnfermedad);

            // Configuración de las relaciones entre Usuario, UserRol y Rol
            modelBuilder.Entity<UserRol>()
                .HasKey(ur => new { ur.IdUser, ur.IdRol });

            modelBuilder.Entity<UserRol>()
                .HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.IdUser);

            modelBuilder.Entity<UserRol>()
                .HasOne(ur => ur.Rol)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.IdRol);

            // Configuración de las relaciones entre FichaSintoma, Mascotas, Resultado y User
            modelBuilder.Entity<FichaSintoma>()
                .HasMany(fs => fs.Detalles)
                .WithOne(d => d.FichaSintomas)
                .HasForeignKey(d => d.IdFicha);

            modelBuilder.Entity<Mascotas>()
                .HasMany(m => m.FichaSintomas)
                .WithOne(fs => fs.Mascotas)
                .HasForeignKey(fs => fs.IdMascotas);

            modelBuilder.Entity<Resultado>()
                .HasMany(r => r.FichaSintomas)
                .WithOne(fs => fs.Resultado)
                .HasForeignKey(fs => fs.IdResultado);

            modelBuilder.Entity<User>()
                .HasMany(u => u.FichaSintomas)
                .WithOne(fs => fs.User)
                .HasForeignKey(fs => fs.IdUser);

            // Configuración de las relaciones entre HistoriaClinica, Mascotas, Resultado y User
            modelBuilder.Entity<HistoriaClinica>()
            .HasOne(hc => hc.Mascotas)
            .WithMany(m => m.HistoriaClinicas)
            .HasForeignKey(hc => hc.IdMascotas);

            modelBuilder.Entity<HistoriaClinica>()
                .HasOne(hc => hc.Resultado)
                .WithMany(r => r.HistoriaClinicas)
                .HasForeignKey(hc => hc.IdResultado);

            modelBuilder.Entity<HistoriaClinica>()
                .HasOne(hc => hc.User)
                .WithMany(u => u.HistoriaClinicas)
                .HasForeignKey(hc => hc.IdUser);
        }

        public DbSet<Form> Forms { get; set; }
        public DbSet<Section> Sections { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<FormSectionQuestion> FormSectionQuestions { get; set; }
        public DbSet<QuestionType> QuestionTypes { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Mascotas> Mascotas { get; set; }
        public DbSet<FichaSintoma> FichaSintomas { get; set; }
        public DbSet<HistoriaClinica> HistoriaClinica { get; set; }
        public DbSet<Resultado> Resultado { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserRol> UserRol { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<TipoEnfermedad> TipoEnfermedad { get; set; }
        public DbSet<Enfermedad> Enfermedad { get; set; }
        public DbSet<Detalle> Detalles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      => optionsBuilder
           
           .UseSqlServer("Data Source=localhost;Initial Catalog=VetAnimal;Integrated Security=True;TrustServerCertificate=True");
    }

    
}