using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Infrastructure
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Custom> Custom { get; set; }
        public virtual DbSet<Discount> Discount { get; set; }
        public virtual DbSet<Good> Good { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Review> Review { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Type> Type { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Custom>()
                .Property(e => e.Total_Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Discount>()
                .HasMany(e => e.Person)
                .WithRequired(e => e.Discount)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Good>()
                .Property(e => e.Price)
                .HasPrecision(128, 0);

            modelBuilder.Entity<Good>()
                .HasMany(e => e.Custom)
                .WithRequired(e => e.Good)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .Property(e => e.Gender)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .Property(e => e.Number_phone)
                .IsFixedLength();

            modelBuilder.Entity<Person>()
                .HasOptional(e => e.User)
                .WithRequired(e => e.Person);

            modelBuilder.Entity<Review>()
                .Property(e => e.Value)
                .HasPrecision(5, 0);

            modelBuilder.Entity<Review>()
                .HasMany(e => e.Good)
                .WithMany(e => e.Review)
                .Map(m => m.ToTable("Good_Review").MapLeftKey("ReviewID").MapRightKey("GoodID"));

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Custom)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Type>()
                .HasMany(e => e.Good)
                .WithRequired(e => e.Type)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Custom)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CustomerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Good)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.SellerID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Review)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CustomerID)
                .WillCascadeOnDelete(false);
        }
    }
}
