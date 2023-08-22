namespace TransneftEnergy.Infrastructure.Data.Configurations
{
    internal sealed class ConsumptionObjectEntityConfiguration : IEntityTypeConfiguration<ConsumptionObject>
    {
        public void Configure(EntityTypeBuilder<ConsumptionObject> builder)
        {
            builder.Property(co => co.Name).HasMaxLength(256);
        }
    }
}
