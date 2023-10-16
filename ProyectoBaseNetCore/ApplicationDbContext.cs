using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoBaseNetCore.Entities;
using ProyectoBaseNetCore.Entities.DinamicQuestionEntities;

namespace ProyectoBaseNetCore
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
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

            modelBuilder.Entity<Clientes>()
                .HasMany(cliente => cliente.Mascotas)
                .WithOne(mascota => mascota.Cliente)
                .HasForeignKey(mascota => mascota.IdCliente);
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
    }
}