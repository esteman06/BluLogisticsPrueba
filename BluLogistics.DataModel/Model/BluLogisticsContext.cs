using Microsoft.EntityFrameworkCore;

namespace BluLogistics.DataModel.Model
{
    public partial class BluLogisticsContext : DbContext
    {
        public BluLogisticsContext() { }
        public BluLogisticsContext(DbContextOptions<BluLogisticsContext> options) : base(options) { }
        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<Autores_has_libros> Autores_Has_Libros { get; set; }
        public virtual DbSet<Editoriales> Editoriales { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-J5RKTFBG\\SQLSERVER;Initial Catalog=BD_BluLogistics;Integrated Security=False;User ID=sa;password=Vianestoca08;Persist Security Info=True;MultipleActiveResultSets=True;App=EntityFramework&quot;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Autores>(entity =>
            {
                entity.Property(e => e.AutoresID)
                    .HasColumnName("autoresID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Apellidos).HasColumnName("apellidos");
            });

            modelBuilder.Entity<Autores_has_libros>(entity =>
            {
                entity.Property(e => e.Autores_has_librosID)
                   .HasColumnName("autores_has_librosID")
                   .ValueGeneratedNever();

                entity.Property(e => e.AutoresID)
                    .HasColumnName("autoresID")
                    .ValueGeneratedNever();

                entity.Property(e => e.LibrosID)
                     .HasColumnName("LibrosID")
                     .ValueGeneratedNever();
            });

            modelBuilder.Entity<Editoriales>(entity =>
            {
                entity.Property(e => e.EditorialesID)
                    .HasColumnName("editorialesID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasColumnName("nombre");

                entity.Property(e => e.Sede).HasColumnName("sede");
            });

            modelBuilder.Entity<Libros>(entity =>
            {
                entity.Property(e => e.LibrosID)
                    .HasColumnName("librosID")
                    .ValueGeneratedNever();

                entity.Property(e => e.EditorialesID)
                    .HasColumnName("editorialesID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tittulo).HasColumnName("tittulo");

                entity.Property(e => e.Sinopsis).HasColumnName("sinopsis");

                entity.Property(e => e.NPaginas).HasColumnName("NPaginas");
            });



        }
    }
}
