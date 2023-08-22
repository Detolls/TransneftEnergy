namespace TransneftEnergy.Infrastructure.Data.Configurations
{
    internal sealed class CurrentTransformerEntityConfiguration : IEntityTypeConfiguration<CurrentTransformer>
    {
        public void Configure(EntityTypeBuilder<CurrentTransformer> builder)
        {
            builder.Property(ct => ct.Number).HasMaxLength(256);
        }
    }
}
