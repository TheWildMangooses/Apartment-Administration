namespace REST.Models_log
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LogDataContext : DbContext
    {
        public LogDataContext()
            : base("name=LogDataContext")
        {
        }

        public virtual DbSet<Apartments_log> Apartments_log { get; set; }
        public virtual DbSet<Facilities_log> Facilities_log { get; set; }
        public virtual DbSet<Residents_log> Residents_log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartments_log>()
                .Property(e => e.Rent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Apartments_log>()
                .Property(e => e.Uploaded_Doc_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Apartments_log>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Facilities_log>()
                .Property(e => e.F_Name)
                .IsFixedLength();

            modelBuilder.Entity<Facilities_log>()
                .Property(e => e.F_Condition)
                .IsFixedLength();

            modelBuilder.Entity<Facilities_log>()
                .Property(e => e.Uploaded_F_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Residents_log>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Residents_log>()
                .Property(e => e.L_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Residents_log>()
                .Property(e => e.E_Mail)
                .IsUnicode(false);
        }
    }
}
