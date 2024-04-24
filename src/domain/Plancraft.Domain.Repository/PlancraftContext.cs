using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Plancraft.Domain.Models;

namespace Plancraft.Domain.Repository;

public class PlancraftContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public PlancraftContext()
    {
    }

    public PlancraftContext(DbContextOptions<PlancraftContext> options) : base(options)
    {
    }
    
    public virtual DbSet<Contract> Contracts { get; set; }

    public virtual DbSet<ContractItem> ContractItems { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<FinancialTransaction> FinancialTransactions { get; set; }

    public virtual DbSet<Funder> Funders { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<PaymentModality> PaymentModalities { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Setting> Settings { get; set; }

    public virtual DbSet<ApplicationUser> Users { get; set; }
}