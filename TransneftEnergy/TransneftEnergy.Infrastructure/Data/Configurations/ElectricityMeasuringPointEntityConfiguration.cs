namespace TransneftEnergy.Infrastructure.Data.Configurations
{
    internal sealed class ElectricityMeasuringPointEntityConfiguration : IEntityTypeConfiguration<ElectricityMeasuringPoint>
    {
        public void Configure(EntityTypeBuilder<ElectricityMeasuringPoint> builder)
        {
            builder.Property(emp => emp.Name).HasMaxLength(256);
        }
    }
}
