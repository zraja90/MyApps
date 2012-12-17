using System.Data.Entity.ModelConfiguration;
using ToolDepot.Core.Domain.Email;

namespace ToolDepot.Data.Mapping.Email
{
    public partial class EmailAccountMap : EntityTypeConfiguration<EmailAccount>
    {
        public EmailAccountMap()
        {
            this.ToTable("EmailAccount");
            this.HasKey(ea => ea.Id);

            this.Property(ea => ea.Email).IsRequired().HasMaxLength(255);
            this.Property(ea => ea.DisplayName).HasMaxLength(255);
            this.Property(ea => ea.Host).IsRequired().HasMaxLength(255);
            this.Property(ea => ea.Username).IsRequired().HasMaxLength(255);
            this.Property(ea => ea.Password).IsRequired().HasMaxLength(255);
            this.Property(ea => ea.IsDefault).IsRequired();
            this.Property(ea => ea.ProgramId);
            this.Ignore(ea => ea.FriendlyName);
        }
    }
}