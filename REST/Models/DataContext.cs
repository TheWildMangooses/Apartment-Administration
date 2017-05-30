namespace REST.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Apartment> Apartments { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Facility> Facilities { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Resident> Residents { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apartment>()
                .Property(e => e.Number)
                .IsFixedLength();

            modelBuilder.Entity<Apartment>()
                .Property(e => e.Rent)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Apartment>()
                .Property(e => e.Uploaded_Doc_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Facilities)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);

/*            modelBuilder.Entity<Apartment>()
                .HasMany(e => e.Residents)
                .WithRequired(e => e.Apartment)
                .WillCascadeOnDelete(false);*/

            modelBuilder.Entity<Building>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Facility>()
                .Property(e => e.F_Name)
                .IsFixedLength();

            modelBuilder.Entity<Facility>()
                .Property(e => e.F_Condition)
                .IsFixedLength();

            modelBuilder.Entity<Facility>()
                .Property(e => e.Uploaded_F_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Message1)
                .IsUnicode(false);

            modelBuilder.Entity<Message>()
                .Property(e => e.Uploaded_File_Name)
                .IsUnicode(false);

            modelBuilder.Entity<Resident>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Resident>()
                .Property(e => e.L_Name)
                .IsFixedLength();

            modelBuilder.Entity<Resident>()
                .Property(e => e.E_Mail)
                .IsFixedLength();

/*            modelBuilder.Entity<Resident>()
                .HasMany(e => e.Messages)
                .WithRequired(e => e.Resident)
                .HasForeignKey(e => e.Sent_To)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Resident>()
                .HasMany(e => e.Messages1)
                .WithRequired(e => e.Resident1)
                .HasForeignKey(e => e.R_No)
                .WillCascadeOnDelete(false); */

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
