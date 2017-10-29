using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace _7CWin.Models
{
    public partial class _7cwinContext : DbContext
    {
        public virtual DbSet<Bin> Bin { get; set; }

        public _7cwinContext(DbContextOptions<_7cwinContext> options) : base(options) {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bin>(entity =>
            {
                entity.ToTable("bin");

                entity.Property(e => e.Id)
                .HasMaxLength(12)
                .HasColumnName("id");

                entity.Property(e => e.Ciphertext)
                    .IsRequired()
                    .HasColumnName("ciphertext");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Iv)
                    .IsRequired()
                    .HasMaxLength(32)
                    .HasColumnName("iv");
            });
        }
    }
}
