using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FindCarrier.Models
{
    public partial class FindCarrierDbModel : DbContext
    {
        public FindCarrierDbModel()
            : base("name=FindCarrierDbModel")
        {
        }

        public virtual DbSet<BodyType> BodyTypes { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        //public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Transporter> Transporters { get; set; }
        public virtual DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BodyType>()
                .Property(e => e.VehicleType)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<City>()
                .Property(e => e.CityName)
                .IsUnicode(false);

            //modelBuilder.Entity<Material>()
            //    .Property(e => e.MaterialName)
            //    .IsUnicode(false);

            modelBuilder.Entity<State>()
                .Property(e => e.StateName)
                .IsUnicode(false);

            modelBuilder.Entity<Transporter>()
                .Property(e => e.TransportName)
                .IsUnicode(false);

            modelBuilder.Entity<Transporter>()
                .Property(e => e.OwnerName)
                .IsUnicode(false);

            modelBuilder.Entity<Transporter>()
                .Property(e => e.ContactNo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Transporter>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Transporter>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Transporter>()
                .Property(e => e.State)
                .IsUnicode(false);

            //modelBuilder.Entity<Transporter>()
            //    .HasMany(e => e.Vehicles)
            //    .WithRequired(e => e.Transporter)
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.VehicleName)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.VehicleNo)
                .IsUnicode(false);
            
            modelBuilder.Entity<Vehicle>()
                .Property(e => e.BodyType)
                .IsUnicode(false);

            modelBuilder.Entity<Vehicle>()
                .Property(e => e.Amount)
                .HasPrecision(19, 4);

            

        }
    }
}
