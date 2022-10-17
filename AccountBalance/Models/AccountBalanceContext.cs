using Microsoft.EntityFrameworkCore;
using AccountBalance.Models;

namespace AccountBalance.Models
{
    public class AccountBalanceContext : DbContext
    {
        public AccountBalanceContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<MoneyAccount> MoneyAccounts { get; set; }
        public DbSet<MoneyHistory> MoneyHistories { get; set; }
        public DbSet<User> Users { get; set; }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasOne(x => x.MoneyAccounts)
                .WithOne(x => x.User)
                .HasForeignKey<MoneyAccount>(x => x.UserId);

            modelBuilder.Entity<MoneyHistory>()
            .HasOne<MoneyAccount>(e => e.MoneyAccount)
            .WithMany(d => d.MoneyHistories)
            .HasForeignKey(e => e.MoneyAccId);
            



            modelBuilder.Entity<MoneyAccount>().ToTable("moneyaccount");
            modelBuilder.Entity<MoneyHistory>().ToTable("moneyhistory");
            modelBuilder.Entity<User>().ToTable("users");
        }

    }

}
