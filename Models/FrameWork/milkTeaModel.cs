namespace Models.FrameWork
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class milkTeaModel : DbContext
    {
        public milkTeaModel()
            : base("name=milkTeaModels")
        {
        }

        public virtual DbSet<Acc_Sell_Pro> Acc_Sell_Pro { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<User_Accounts> User_Accounts { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Acc_Sell_Pro>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<Cart>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<Order>()
                .Property(e => e.Size)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Imgage_url)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Desciption)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Acc_Sell_Pro)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_Accounts>()
                .Property(e => e.Username)
                .IsFixedLength();

            modelBuilder.Entity<User_Accounts>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<User_Accounts>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<User_Accounts>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User_Accounts>()
                .HasMany(e => e.Acc_Sell_Pro)
                .WithRequired(e => e.User_Accounts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_Accounts>()
                .HasMany(e => e.Carts)
                .WithRequired(e => e.User_Accounts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User_Accounts>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User_Accounts)
                .WillCascadeOnDelete(false);
        }
    }
}
