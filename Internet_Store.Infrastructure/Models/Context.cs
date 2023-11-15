namespace Infrastructure
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Goods>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Goods>()
                .Property(e => e.Amount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Role>()
                .Property(e => e.Id)
                .HasPrecision(18, 0);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Person)
                .WithMany(e => e.User)
                .Map(m => m.ToTable("User_Person").MapLeftKey("Login_User").MapRightKey("Id_Person"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.Role)
                .WithMany(e => e.User)
                .Map(m => m.ToTable("User_Role"));
        }
    }
}
