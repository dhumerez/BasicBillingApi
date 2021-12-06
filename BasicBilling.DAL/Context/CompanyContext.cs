namespace BasicBilling.DAL.Context
{
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class CompanyContext
        : DbContext
    {
        public CompanyContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Bill> Bills { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<BillType> BillTypes { get; set; }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bill>()
                .Property(b => b.Total)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Bill>()
                .Property(b => b.RemainingBalance)
                .HasPrecision(14, 2);

            modelBuilder.Entity<Payment>()
                .Property(b => b.Amount)
                .HasPrecision(14, 2);
        }
    }
}
