namespace TransneftEnergy.Infrastructure.Data.Configurations
{
    internal sealed class OrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.Property(o => o.Name).HasMaxLength(256);
        }
    }
}
