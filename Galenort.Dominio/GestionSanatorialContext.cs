using Galenort.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

#nullable disable

namespace Galenort.Dominio
{
    public partial class GestionSanatorialContext : DbContext
    {
        public GestionSanatorialContext()
        {
        }

        public GestionSanatorialContext(DbContextOptions<GestionSanatorialContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comprobante> Comprobante { get; set; }
        public virtual DbSet<DetalleComprobante> DetalleComprobante { get; set; }
        public virtual DbSet<DetalleCtaCte> DetalleCtaCte { get; set; }
        public virtual DbSet<EstadoComprobante> EstadoComprobante { get; set; }
        public virtual DbSet<Paciente> Paciente { get; set; }
        public virtual DbSet<Parentezco> Parentezco { get; set; }
        public virtual DbSet<Persona> Persona { get; set; }
        public virtual DbSet<TipoComprobante> TipoComprobante { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS; Database = GestionSanatorial; Trusted_Connection = true; Connection Timeout = 30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comprobante>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(x => x.Id).HasColumnName("ComprobanteId");
                entity.Property(e => e.Monto)
                    .HasColumnType("decimal(18, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(18, 0)");

                entity.Property(e => e.NumeroComprobante)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.HasOne(d => d.EstadoComprobante)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(x => x.EstadoComprobanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comproban__Estad__0F624AF8");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(x => x.PacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comproban__Pacie__10566F31");

                entity.HasOne(d => d.TipoComprobante)
                    .WithMany(p => p.Comprobantes)
                    .HasForeignKey(x => x.TipoComprobanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comproban__TipoC__114A936A");
            });

            modelBuilder.Entity<DetalleComprobante>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);
                entity.Property(x => x.Id).HasColumnName("DetalleComprobanteId");

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Periodo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.PrecioUnitario)
                    .HasColumnType("decimal(18, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(18, 0)");

                entity.HasOne(d => d.Comprobante)
                    .WithMany(p => p.DetalleComprobantes)
                    .HasForeignKey(x => x.ComprobanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleCo__Compr__14270015");
            });

            modelBuilder.Entity<DetalleCtaCte>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(x => x.Id).HasColumnName("DetalleCtaCteId");

                entity.Property(e => e.Debe)
                    .HasColumnType("decimal(18, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(18, 0)");

                entity.Property(e => e.Haber)
                    .HasColumnType("decimal(18, 0)")
                    .HasAnnotation("Relational:ColumnType", "decimal(18, 0)");

                entity.Property(e => e.Periodo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Comprobante)
                    .WithMany(p => p.DetalleCtaCtes)
                    .HasForeignKey(x => x.ComprobanteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleCt__Compr__17036CC0");

                entity.HasOne(d => d.Imputacion)
                    .WithMany(p => p.InverseImputacion)
                    .HasForeignKey(x => x.ImputacionId)
                    .HasConstraintName("FK__DetalleCt__Imput__18EBB532");

                entity.HasOne(d => d.Paciente)
                    .WithMany(p => p.DetalleCtaCtes)
                    .HasForeignKey(x => x.PacienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DetalleCt__Pacie__17F790F9");
            });

            modelBuilder.Entity<EstadoComprobante>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(x => x.Id).HasColumnName("EstadoComprobanteId");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Paciente>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(x => x.Id).HasColumnName("PacienteId");
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.HasOne(d => d.Parentezco)
                    .WithMany(p => p.Pacientes)
                    .HasForeignKey(x => x.ParentezcoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Pacientes__Paren__08B54D69");
            });

            modelBuilder.Entity<Parentezco>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(x => x.Id).HasColumnName("ParentezcoId");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(x => x.Id).HasColumnName("PersonaId");
                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Dni)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TipoComprobante>(entity =>
            {
                entity.HasAnnotation("Relational:IsTableExcludedFromMigrations", false);

                entity.Property(x => x.Id).HasColumnName("TipoComprobanteId");
                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(350)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entidad in ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted && x.CurrentValues.Properties.Any(y => y.Name.Contains("Estado"))))
            {
                entidad.State = EntityState.Unchanged;
                entidad.CurrentValues["Estado"] = true;
            }
            return base.SaveChangesAsync();
        }
    }
}
