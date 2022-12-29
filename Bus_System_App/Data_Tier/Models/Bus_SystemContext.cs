using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data_Tier.Models
{
    public partial class Bus_SystemContext : DbContext
    {
        public Bus_SystemContext()
        {
        }

        public Bus_SystemContext(DbContextOptions<Bus_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autobuse> Autobuses { get; set; }
        public virtual DbSet<Chofere> Choferes { get; set; }
        public virtual DbSet<Parada> Paradas { get; set; }
        public virtual DbSet<Viaje> Viajes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=BFLORENTINO\\SQLBRYAN;Database=Bus_System;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Autobuse>(entity =>
            {
                entity.HasKey(e => e.IdAutobus)
                    .HasName("PK__Autobuse__F14EB7866ED0D8D2");

                entity.Property(e => e.IdAutobus).HasColumnName("id_autobus");

                entity.Property(e => e.Anio).HasColumnName("anio");

                entity.Property(e => e.Capacidad).HasColumnName("capacidad");

                entity.Property(e => e.FechaAdquisicion)
                    .HasColumnType("date")
                    .HasColumnName("fecha_adquisicion");

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("marca");

                entity.Property(e => e.Modelo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("modelo");
            });

            modelBuilder.Entity<Chofere>(entity =>
            {
                entity.HasKey(e => e.IdChofer)
                    .HasName("PK__Choferes__0337858D6C1DEFF3");

                entity.HasIndex(e => e.Cedula, "UQ__Choferes__415B7BE527A26B44")
                    .IsUnique();

                entity.Property(e => e.IdChofer).HasColumnName("id_chofer");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("apellido");

                entity.Property(e => e.Cedula)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cedula");

                entity.Property(e => e.FechaContratado)
                    .HasColumnType("date")
                    .HasColumnName("fecha_contratado")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FechaNacimiento)
                    .HasColumnType("date")
                    .HasColumnName("fecha_nacimiento");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<Parada>(entity =>
            {
                entity.HasKey(e => e.IdParada)
                    .HasName("PK__Paradas__AB1E2973B44A4BB1");

                entity.Property(e => e.IdParada).HasColumnName("id_parada");

                entity.Property(e => e.Calle)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("calle");

                entity.Property(e => e.Municipio)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("municipio");

                entity.Property(e => e.NombreParada)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("nombre_parada");

                entity.Property(e => e.Provincia)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("provincia");
            });

            modelBuilder.Entity<Viaje>(entity =>
            {
                entity.HasKey(e => e.IdViaje)
                    .HasName("PK__Viajes__29535AC316906709");

                entity.Property(e => e.IdViaje).HasColumnName("id_viaje");

                entity.Property(e => e.HoraEstimadaLlegada).HasColumnName("hora_estimada_llegada");

                entity.Property(e => e.HoraSalida).HasColumnName("hora_salida");

                entity.Property(e => e.IdAutobus).HasColumnName("id_autobus");

                entity.Property(e => e.IdChofer).HasColumnName("id_chofer");

                entity.Property(e => e.IdPuntoLlegada).HasColumnName("id_punto_llegada");

                entity.Property(e => e.IdPuntoSalida).HasColumnName("id_punto_salida");

                entity.Property(e => e.StatusViaje)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("status_viaje");

                entity.HasOne(d => d.IdAutobusNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdAutobus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Viajes__id_autob__4222D4EF");

                entity.HasOne(d => d.IdChoferNavigation)
                    .WithMany(p => p.Viajes)
                    .HasForeignKey(d => d.IdChofer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Viajes__id_chofe__4316F928");

                entity.HasOne(d => d.IdPuntoLlegadaNavigation)
                    .WithMany(p => p.ViajeIdPuntoLlegadaNavigations)
                    .HasForeignKey(d => d.IdPuntoLlegada)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Viajes__id_punto__412EB0B6");

                entity.HasOne(d => d.IdPuntoSalidaNavigation)
                    .WithMany(p => p.ViajeIdPuntoSalidaNavigations)
                    .HasForeignKey(d => d.IdPuntoSalida)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Viajes__id_punto__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
