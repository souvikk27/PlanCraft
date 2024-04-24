using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Plancraft.Domain.Models;
using PlancraftContext = Plancraft.Domain.Repository.PlancraftContext;

namespace Plancraft.Domain.Migrations;

public partial class MigrationContext : PlancraftContext
{
    public MigrationContext()
    {
    }

    public MigrationContext(DbContextOptions<PlancraftContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("SqlConnection"),
                option => option.MigrationsAssembly("Plancraft.Domain.Migrations"));
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
         modelBuilder.Entity<Contract>(entity =>
        {
            entity.HasKey(e => e.ContractId).HasName("PK__Contract__C90D3409DA4AF841");

            entity.Property(e => e.ContractId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ContractID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Project).WithMany(p => p.Contracts)
                .HasForeignKey(d => d.ProjectId)
                .HasConstraintName("FK__Contracts__Proje__3D5E1FD2");

            entity.HasMany(d => d.Documents).WithMany(p => p.Contracts)
                .UsingEntity<Dictionary<string, object>>(
                    "ContractDocument",
                    r => r.HasOne<Document>().WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ContractD__Docum__5629CD9C"),
                    l => l.HasOne<Contract>().WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ContractD__Contr__5535A963"),
                    j =>
                    {
                        j.HasKey("ContractId", "DocumentId").HasName("PK__Contract__28A6DAFF4527FBC5");
                        j.ToTable("ContractDocuments");
                        j.IndexerProperty<Guid>("ContractId").HasColumnName("ContractID");
                        j.IndexerProperty<Guid>("DocumentId").HasColumnName("DocumentID");
                    });

            entity.HasMany(d => d.Modalities).WithMany(p => p.Contracts)
                .UsingEntity<Dictionary<string, object>>(
                    "ContractModality",
                    r => r.HasOne<PaymentModality>().WithMany()
                        .HasForeignKey("ModalityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ContractM__Modal__59FA5E80"),
                    l => l.HasOne<Contract>().WithMany()
                        .HasForeignKey("ContractId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ContractM__Contr__59063A47"),
                    j =>
                    {
                        j.HasKey("ContractId", "ModalityId").HasName("PK__Contract__651AA048930E7BD1");
                        j.ToTable("ContractModalities");
                        j.IndexerProperty<Guid>("ContractId").HasColumnName("ContractID");
                        j.IndexerProperty<Guid>("ModalityId").HasColumnName("ModalityID");
                    });
        });

        modelBuilder.Entity<ContractItem>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__Contract__727E83EB489862DB");

            entity.Property(e => e.ItemId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ItemID");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.QuantityOrBudget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Contract).WithMany(p => p.ContractItems)
                .HasForeignKey(d => d.ContractId)
                .HasConstraintName("FK__ContractI__Contr__412EB0B6");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.DocumentId).HasName("PK__Document__1ABEEF6FA75931B4");

            entity.Property(e => e.DocumentId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("DocumentID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UploadDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<FinancialTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Financia__55433A4B72677581");

            entity.Property(e => e.TransactionId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("TransactionID");
            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ContractItemId).HasColumnName("ContractItemID");
            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.FunderId).HasColumnName("FunderID");
            entity.Property(e => e.PaymentType).HasMaxLength(50);

            entity.HasOne(d => d.ContractItem).WithMany(p => p.FinancialTransactions)
                .HasForeignKey(d => d.ContractItemId)
                .HasConstraintName("FK__Financial__Contr__4D94879B");

            entity.HasOne(d => d.Funder).WithMany(p => p.FinancialTransactions)
                .HasForeignKey(d => d.FunderId)
                .HasConstraintName("FK__Financial__Funde__4E88ABD4");
        });

        modelBuilder.Entity<Funder>(entity =>
        {
            entity.HasKey(e => e.FunderId).HasName("PK__Funders__B752D7C1D2EF142D");

            entity.Property(e => e.FunderId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("FunderID");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__Groups__149AF30ACDCA3E6E");

            entity.Property(e => e.GroupId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("GroupID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__Notifica__20CF2E32CB169C23");

            entity.Property(e => e.NotificationId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("NotificationID");
            entity.Property(e => e.ScheduledDate).HasColumnType("datetime");
            entity.Property(e => e.SentDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Notificat__UserI__6383C8BA");
        });

        modelBuilder.Entity<PaymentModality>(entity =>
        {
            entity.HasKey(e => e.ModalityId).HasName("PK__PaymentM__C179441B11C5A650");

            entity.Property(e => e.ModalityId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ModalityID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABED0F44558C0");

            entity.Property(e => e.ProjectId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("ProjectID");
            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasMany(d => d.Documents).WithMany(p => p.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectDocument",
                    r => r.HasOne<Document>().WithMany()
                        .HasForeignKey("DocumentId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProjectDo__Docum__52593CB8"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProjectDo__Proje__5165187F"),
                    j =>
                    {
                        j.HasKey("ProjectId", "DocumentId").HasName("PK__ProjectD__97B1502638C0F9CE");
                        j.ToTable("ProjectDocuments");
                        j.IndexerProperty<Guid>("ProjectId").HasColumnName("ProjectID");
                        j.IndexerProperty<Guid>("DocumentId").HasColumnName("DocumentID");
                    });

            entity.HasMany(d => d.Funders).WithMany(p => p.Projects)
                .UsingEntity<Dictionary<string, object>>(
                    "ProjectFunder",
                    r => r.HasOne<Funder>().WithMany()
                        .HasForeignKey("FunderId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProjectFu__Funde__7B5B524B"),
                    l => l.HasOne<Project>().WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__ProjectFu__Proje__7A672E12"),
                    j =>
                    {
                        j.HasKey("ProjectId", "FunderId").HasName("PK__ProjectF__7D6F93AC0C5E4FA3");
                        j.ToTable("ProjectFunders");
                        j.IndexerProperty<Guid>("ProjectId").HasColumnName("ProjectID");
                        j.IndexerProperty<Guid>("FunderId").HasColumnName("FunderID");
                    });
        });

        modelBuilder.Entity<Setting>(entity =>
        {
            entity.HasKey(e => e.SettingId).HasName("PK__Settings__54372AFDBD7CE998");

            entity.Property(e => e.SettingId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("SettingID");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable(name: "Users");
            entity.Property(e => e.Id)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.UserName).HasMaxLength(50);

            entity.HasMany(d => d.Groups).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserGroupMapping",
                    r => r.HasOne<Group>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserGroup__Group__6754599E"),
                    l => l.HasOne<ApplicationUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__UserGroup__UserI__66603565"),
                    j =>
                    {
                        j.HasKey("UserId", "GroupId").HasName("PK__UserGroups__A6C1639C94EA34FE");
                        j.ToTable("UserGroupMapping");
                        j.IndexerProperty<Guid>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<Guid>("GroupId").HasColumnName("GroupID");
                    });
        });
        
        modelBuilder.Entity<IdentityRole>(entity =>
        {
            entity.ToTable(name: "Role");
        });

        modelBuilder.Entity<IdentityUserRole<string>>(entity =>
        {
            entity.ToTable("UserRoles");
        });

        modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
        {
            entity.ToTable("UserClaims");
        });

        modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.ToTable("UserLogins");
        });

        modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
        {
            entity.ToTable("RoleClaims");

        });

        modelBuilder.Entity<IdentityUserToken<string>>(entity =>
        {
            entity.ToTable("UserTokens");
        });
        
        
        modelBuilder.Entity<VwContractDocument>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ContractDocuments");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.DocumentName).HasMaxLength(255);
            entity.Property(e => e.DocumentType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UploadDate).HasColumnType("datetime");
            entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<VwDocumentProjectsContract>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_DocumentProjectsContracts");

            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.ContractName).HasMaxLength(255);
            entity.Property(e => e.ContractType).HasMaxLength(50);
            entity.Property(e => e.ContractValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.DocumentId).HasColumnName("DocumentID");
            entity.Property(e => e.DocumentName).HasMaxLength(255);
            entity.Property(e => e.DocumentType).HasMaxLength(50);
            entity.Property(e => e.DocumentUploadDate).HasColumnType("datetime");
            entity.Property(e => e.ProjectBudget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectName).HasMaxLength(255);
            entity.Property(e => e.ProjectStatus).HasMaxLength(50);
        });

        modelBuilder.Entity<VwFinancialTransactionDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_FinancialTransactionDetails");

            entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.FunderId).HasColumnName("FunderID");
            entity.Property(e => e.FunderName).HasMaxLength(255);
            entity.Property(e => e.FunderType).HasMaxLength(50);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
        });

        modelBuilder.Entity<VwFunderProjectsTransaction>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_FunderProjectsTransactions");

            entity.Property(e => e.Currency).HasMaxLength(3);
            entity.Property(e => e.FunderId).HasColumnName("FunderID");
            entity.Property(e => e.FunderName).HasMaxLength(255);
            entity.Property(e => e.FunderType).HasMaxLength(50);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.PaymentType).HasMaxLength(50);
            entity.Property(e => e.ProjectBudget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectName).HasMaxLength(255);
            entity.Property(e => e.ProjectStatus).HasMaxLength(50);
            entity.Property(e => e.TransactionAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
        });

        modelBuilder.Entity<VwProjectContractsItem>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectContractsItems");

            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ContractId).HasColumnName("ContractID");
            entity.Property(e => e.ContractName).HasMaxLength(255);
            entity.Property(e => e.ContractType).HasMaxLength(50);
            entity.Property(e => e.ContractValue).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ItemCurrency).HasMaxLength(3);
            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.ItemName).HasMaxLength(255);
            entity.Property(e => e.ItemQuantity).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ItemUnitPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.ProjectName).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<VwProjectFunder>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_ProjectFunders");

            entity.Property(e => e.Budget).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.FunderId).HasColumnName("FunderID");
            entity.Property(e => e.FunderName).HasMaxLength(255);
            entity.Property(e => e.FunderType).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.ProjectId).HasColumnName("ProjectID");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }
    
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}