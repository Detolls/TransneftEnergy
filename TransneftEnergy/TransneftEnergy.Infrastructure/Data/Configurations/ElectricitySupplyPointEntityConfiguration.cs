namespace TransneftEnergy.Infrastructure.Data.Configurations
{
    internal sealed class ElectricitySupplyPointEntityConfiguration : IEntityTypeConfiguration<ElectricitySupplyPoint>
    {
        public void Configure(EntityTypeBuilder<ElectricitySupplyPoint> builder)
        {
            builder.Property(esp => esp.Name).HasMaxLength(256);
        }
    }
}
