using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace ExpenseServiceAPI.Models
{
    public partial class RevatureDatabaseContext : DbContext
    {
        public RevatureDatabaseContext()
        {

        }

        public RevatureDatabaseContext(DbContextOptions<RevatureDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<Budgets> Budgets { get; set; }
        public virtual DbSet<Loan> Loan { get; set; }
        public virtual DbSet<LoanApplication> LoanApplication { get; set; }
        public virtual DbSet<Subscriptions> Subscriptions { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Cost).HasColumnType("money");

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(48);

                entity.Property(e => e.PurchaseName)
                    .IsRequired()
                    .HasMaxLength(48);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ID_Bills");
            });

            modelBuilder.Entity<Budgets>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ActualCost).HasColumnType("money");

                entity.Property(e => e.EstimatedCost).HasColumnType("money");

                entity.Property(e => e.Loan)
                    .IsRequired()
                    .HasMaxLength(48);

                entity.Property(e => e.Subscription)
                    .IsRequired()
                    .HasMaxLength(48);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Budgets)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ID");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccumulatedCost).HasColumnType("money");

                entity.Property(e => e.InterestRate).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MonthlyRate).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.RetainingCost).HasColumnType("money");

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Loan)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ID_Loan");
            });

            modelBuilder.Entity<LoanApplication>(entity =>
            {
                entity.HasIndex(e => e.Ssn)
                    .HasName("UQ__LoanAppl__CA1E8E3CC4D63E64")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreditScore).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.EstIncome).HasColumnType("money");

                entity.Property(e => e.LoanAmount).HasColumnType("money");

                entity.Property(e => e.Ssn)
                    .IsRequired()
                    .HasColumnName("SSN")
                    .HasMaxLength(9)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.LoanApplication)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ID_LoanApplication");
            });

            modelBuilder.Entity<Subscriptions>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Company)
                    .IsRequired()
                    .HasMaxLength(48);

                entity.Property(e => e.SubscriptionMonthCost).HasColumnType("money");

                entity.Property(e => e.SubscriptionName)
                    .IsRequired()
                    .HasMaxLength(48);

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subscriptions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ID_Subscriptions");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber)
                    .HasName("UQ__Users__85FB4E3866EE1686")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(1128);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
