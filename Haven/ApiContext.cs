using Microsoft.EntityFrameworkCore;

namespace Haven.Models
{
    public partial class ApiContext : DbContext
    {
        public ApiContext() { }

        public ApiContext(DbContextOptions<ApiContext> options) : base(options) { }

        public virtual DbSet<Depoimento> Depoimento { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Ocorrencia> Ocorrencia { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localDb)\\mssqllocaldb;Database=Haven;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depoimento>(entity =>
            {
                entity.Property(x => x.Descricao);
                entity.Property(x => x.ModalidadeCrime);
                entity.HasOne(x => x.Usuario).WithMany().HasForeignKey("IdUsuario");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.Property(x => x.Bairro);
                entity.Property(x => x.Cep);
                entity.Property(x => x.Cidade);
                entity.Property(x => x.Logradouro);
                entity.Property(x => x.UF);

                entity.HasMany(x => x.Ocorrencias).WithOne().HasForeignKey("IdEndereco");
                entity.HasMany(x => x.Depoimentos).WithOne().HasForeignKey("IdEndereco");
            });

            modelBuilder.Entity<Ocorrencia>(entity =>
            {
                entity.Property(x => x.Descricao);
                entity.Property(x => x.ModalidadeCrime);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(x => x.Cpf);
                entity.Property(x => x.Email);
                entity.Property(x => x.Nome);
                entity.Property(x => x.Senha);
                entity.Property(x => x.Telefone);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}