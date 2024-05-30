using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Avtopark
{
    public partial class praktContext : DbContext
    {
        public praktContext()
        {
        }

        public praktContext(DbContextOptions<praktContext> options)
            : base(options)
        {
        }

        public virtual DbSet<GryzovoiAvto> GryzovoiAvto { get; set; }
        public virtual DbSet<LegkovoiAvto> LegkovoiAvto { get; set; }
        public virtual DbSet<Master> Master { get; set; }
        public virtual DbSet<Parkovka> Parkovka { get; set; }
        public virtual DbSet<Users> Polzovateli { get; set; }
        public virtual DbSet<VoditelGryzovoiAvto> VoditelGryzovoiAvto { get; set; }
        public virtual DbSet<VoditelLegkovoiAvto> VoditelLegkovoiAvto { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GryzovoiAvto>(entity =>
            {
                entity.HasKey(e => e.IdG);

                entity.ToTable("Gryzovoi_avto");

                entity.Property(e => e.IdG).HasColumnName("id_g");

                entity.Property(e => e.ChisloOsei)
                    .IsRequired()
                    .HasColumnName("Chislo_osei")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.GosNomer)
                    .IsRequired()
                    .HasColumnName("Gos_nomer")
                    .HasMaxLength(100);

                entity.Property(e => e.Gryzopodemnost)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.IdMas).HasColumnName("id_mas");

                entity.Property(e => e.IdPar).HasColumnName("id_par");

                entity.Property(e => e.Marka)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MochnostDvigatelay)
                    .IsRequired()
                    .HasColumnName("Mochnost_dvigatelay")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ObiemKyzova)
                    .IsRequired()
                    .HasColumnName("Obiem_kyzova")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.RashodTopliva)
                    .IsRequired()
                    .HasColumnName("Rashod_topliva")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.IdMasNavigation)
                    .WithMany(p => p.GryzovoiAvto)
                    .HasForeignKey(d => d.IdMas)
                    .HasConstraintName("FK_Gryzovoi_avto_Master");

                entity.HasOne(d => d.IdParNavigation)
                    .WithMany(p => p.GryzovoiAvto)
                    .HasForeignKey(d => d.IdPar)
                    .HasConstraintName("FK_Gryzovoi_avto_Parkovka");
            });

            modelBuilder.Entity<LegkovoiAvto>(entity =>
            {
                entity.HasKey(e => e.IdL);

                entity.ToTable("Legkovoi_avto");

                entity.Property(e => e.IdL)
                    .HasColumnName("id_l")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ChisloPassajirov)
                    .IsRequired()
                    .HasColumnName("Chislo_passajirov")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.GosNomer)
                    .IsRequired()
                    .HasColumnName("Gos_nomer")
                    .HasMaxLength(10);

                entity.Property(e => e.IdMas).HasColumnName("id_mas");

                entity.Property(e => e.IdPar).HasColumnName("id_par");

                entity.Property(e => e.Marka)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MochnostDvigatelay)
                    .IsRequired()
                    .HasColumnName("Mochnost_dvigatelay")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.RashodTopliva)
                    .IsRequired()
                    .HasColumnName("Rashod_topliva")
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TipKyzova)
                    .IsRequired()
                    .HasColumnName("Tip_kyzova")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdLNavigation)
                    .WithOne(p => p.LegkovoiAvto)
                    .HasForeignKey<LegkovoiAvto>(d => d.IdL)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Legkovoi_avto_Voditel_legkovoiAvto");

                entity.HasOne(d => d.IdMasNavigation)
                    .WithMany(p => p.LegkovoiAvto)
                    .HasForeignKey(d => d.IdMas)
                    .HasConstraintName("FK_Legkovoi_avto_Master");

                entity.HasOne(d => d.IdParNavigation)
                    .WithMany(p => p.LegkovoiAvto)
                    .HasForeignKey(d => d.IdPar)
                    .HasConstraintName("FK_Legkovoi_avto_Parkovka");
            });

            modelBuilder.Entity<Master>(entity =>
            {
                entity.HasKey(e => e.IdMas);

                entity.Property(e => e.IdMas).HasColumnName("id_mas");

                entity.Property(e => e.Doljnost)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Familia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdG).HasColumnName("id_g");

                entity.Property(e => e.IdL).HasColumnName("id_l");

                entity.Property(e => e.Imia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.KontNomer)
                    .IsRequired()
                    .HasColumnName("Kont_nomer")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Otchestvo).HasMaxLength(100);

                entity.Property(e => e.Specialetet).HasMaxLength(50);

                entity.Property(e => e.Zp)
                    .HasColumnName("ZP")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Parkovka>(entity =>
            {
                entity.HasKey(e => e.IdPar);

                entity.Property(e => e.IdPar).HasColumnName("id_par");

                entity.Property(e => e.ChisloAvto)
                    .IsRequired()
                    .HasColumnName("Chislo_avto")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Dom)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();

                entity.Property(e => e.Gorod)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.IdG).HasColumnName("id__g");

                entity.Property(e => e.IdL).HasColumnName("id_l");

                entity.Property(e => e.KontLico)
                    .IsRequired()
                    .HasColumnName("Kont_lico")
                    .HasMaxLength(100);

                entity.Property(e => e.KontNomer)
                    .IsRequired()
                    .HasColumnName("Kont_nomer")
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Nazvanie)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ylica)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdPolz);

                entity.Property(e => e.IdPolz)
                    .HasColumnName("id_polz")
                    .ValueGeneratedNever();

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Parol)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.IsAdmin)
                    .IsRequired()
                    .HasColumnName("IsAdmin") // Укажите имя столбца в базе данных, если оно отличается от имени свойства
                    .HasColumnType("bit")
                    .HasDefaultValue(true); // Установка значения по умолчанию, если это необходимо
            });

            modelBuilder.Entity<VoditelGryzovoiAvto>(entity =>
            {
                entity.HasKey(e => e.IdGv);

                entity.ToTable("Voditel_gryzovoiAvto");

                entity.Property(e => e.IdGv)
                    .HasColumnName("id_gv")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.DataRojdeniy)
                    .IsRequired()
                    .HasColumnName("Data_rojdeniy")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Familia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Imia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.KontNomer)
                    .IsRequired()
                    .HasColumnName("Kont_nomer")
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.Otchestvo).HasMaxLength(100);

                entity.Property(e => e.Stag)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Zp)
                    .HasColumnName("ZP")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdGvNavigation)
                    .WithOne(p => p.VoditelGryzovoiAvto)
                    .HasForeignKey<VoditelGryzovoiAvto>(d => d.IdGv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Voditel_gryzovoiAvto_Gryzovoi_avto");
            });

            modelBuilder.Entity<VoditelLegkovoiAvto>(entity =>
            {
                entity.HasKey(e => e.IdLv);

                entity.ToTable("Voditel_legkovoiAvto");

                entity.Property(e => e.IdLv).HasColumnName("id_lv");

                entity.Property(e => e.DataRojdeniy)
                    .HasColumnName("Data_rojdeniy")
                    .HasColumnType("date");

                entity.Property(e => e.Familia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Imia)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.KontNomer)
                    .IsRequired()
                    .HasColumnName("Kont_nomer")
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.Otchestvo).HasMaxLength(100);

                entity.Property(e => e.Stag)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Zp)
                    .HasColumnName("ZP")
                    .HasColumnType("money");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
