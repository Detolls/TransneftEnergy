namespace TransneftEnergy.Infrastructure.Data.Configurations
{
    internal sealed class VoltageTransformerEntityConfiguration : IEntityTypeConfiguration<VoltageTransformer>
    {
        public void Configure(EntityTypeBuilder<VoltageTransformer> builder)
        {
            builder.Property(vt => vt.Number).HasMaxLength(256);
        }
    }
}
