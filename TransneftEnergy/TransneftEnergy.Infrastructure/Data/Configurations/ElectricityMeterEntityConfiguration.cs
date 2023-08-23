namespace TransneftEnergy.Infrastructure.Data.Configurations
{
    internal sealed class ElectricityMeterEntityConfiguration : IEntityTypeConfiguration<ElectricityMeter>
    {
        public void Configure(EntityTypeBuilder<ElectricityMeter> builder)
        {
            builder.Property(em => em.Number).HasMaxLength(256);
        }
    }
}
