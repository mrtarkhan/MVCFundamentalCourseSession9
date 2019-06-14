using Microsoft.EntityFrameworkCore;
using WebApiApp.EntityModel;

namespace WebApiApp.DataLayerConfiguration
{
	public class AccountingContext : DbContext
	{

		public AccountingContext (DbContextOptions<AccountingContext> dbContextOptions) : base (dbContextOptions) {}

		public virtual DbSet<UserAccount> UserAccountSet { get; set; }
		public virtual DbSet<AccountingDocument> AccountingDocumentSet { get; set; }
		public virtual DbSet<BasicDefinition> BasicDefinitionSet { get; set; }
		public virtual DbSet<AccountingCode> AccountingCodeSet { get; set; }


		protected override void OnConfiguring (DbContextOptionsBuilder options)
		{

		}

		protected override void OnModelCreating (ModelBuilder builder)
		{

			builder.Entity<UserAccount>().ToTable("UserAccount","auth");
			builder.Entity<UserAccount>().HasKey(e => e.Id);
			builder.Entity<UserAccount>().Property(e => e.RowVersion).IsRowVersion().IsRequired();
			builder.Entity<UserAccount>().Property(e => e.CreatedDate).HasColumnType("datetime");
			builder.Entity<UserAccount>().Property(e => e.LastModifiedDate).HasColumnType("datetime");
			builder.Entity<UserAccount>().Property(e => e.Email).HasMaxLength(500).IsUnicode().IsRequired();
			builder.Entity<UserAccount>().Property(e => e.FirstName).HasMaxLength(300).IsRequired();
			builder.Entity<UserAccount>().Property(e => e.LastName).HasMaxLength(300).IsRequired();
			builder.Entity<UserAccount>().Property(e => e.Password).HasMaxLength(2000).IsRequired();
			


			builder.Entity<AccountingDocument>().ToTable("AccountingDocument","acc");
			builder.Entity<AccountingDocument>().HasKey(e => e.Id);
			builder.Entity<AccountingDocument>().Property(e => e.RowVersion).IsRowVersion().IsConcurrencyToken().IsRequired();
			builder.Entity<AccountingDocument>().Property(e => e.CreatedDate).HasColumnType("datetime");
			builder.Entity<AccountingDocument>().Property(e => e.LastModifiedDate).HasColumnType("datetime");
			builder.Entity<AccountingDocument>().Property(e => e.Price).HasColumnType("decimal(18,0)").IsRequired();
			builder.Entity<AccountingDocument>().Property(e => e.Description).HasMaxLength(2000);
			builder.Entity<AccountingDocument>().Property(e => e.Title).HasMaxLength(1000).IsRequired();
			builder.Entity<AccountingDocument>()
				.HasOne(e => e.BasicDefinition)
				.WithMany(e => e.AccountingDocuments)
				.HasForeignKey(e => e.BasicDefinitionId);

			builder.Entity<AccountingDocument>()
				.HasOne(e => e.AccountingCode)
				.WithMany(e => e.AccountingDocuments)
				.HasForeignKey(e => e.AccountingCodeId);




			builder.Entity<BasicDefinition>().ToTable("BasicDefinition","acc");
			builder.Entity<BasicDefinition>().HasKey(e => e.Id);
			builder.Entity<BasicDefinition>().Property(e => e.RowVersion).IsRowVersion().IsRequired();
			builder.Entity<BasicDefinition>().Property(e => e.CreatedDate).HasColumnType("datetime");
			builder.Entity<BasicDefinition>().Property(e => e.LastModifiedDate).HasColumnType("datetime");
			builder.Entity<BasicDefinition>().Property(e => e.Title).HasMaxLength(1000).IsRequired();
			builder.Entity<BasicDefinition>().Property(e => e.Description).HasMaxLength(2000);
			builder.Entity<BasicDefinition>().Property(e => e.Code).IsUnicode().IsRequired();




			builder.Entity<AccountingCode>().ToTable("AccountingCode","acc");
			builder.Entity<AccountingCode>().HasKey(e => e.Id);
			builder.Entity<AccountingCode>().Property(e => e.RowVersion).IsRowVersion().IsRequired();
			builder.Entity<AccountingCode>().Property(e => e.CreatedDate).HasColumnType("datetime");
			builder.Entity<AccountingCode>().Property(e => e.LastModifiedDate).HasColumnType("datetime");
			builder.Entity<AccountingCode>().Property(e => e.Title).HasMaxLength(1000).IsRequired();
			builder.Entity<AccountingCode>().Property(e => e.Description).HasMaxLength(2000);
			builder.Entity<AccountingCode>().Property(e => e.Code).IsUnicode().IsRequired();

		}



	}
}
