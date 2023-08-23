namespace TransneftEnergy.Infrastructure.Data.Configurations
{
    internal sealed class ChildOrganizationEntityConfiguration : IEntityTypeConfiguration<ChildOrganization>
    {
        public void Configure(EntityTypeBuilder<ChildOrganization> builder)
        {
            builder.Property(o => o.Name).HasMaxLength(256);
        }
    }
}
