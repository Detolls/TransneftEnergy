namespace TransneftEnergy.Infrastructure.Data.Configurations
{
    internal sealed class ElectricityMeasuringPointsSettlementMetersConfiguration : IEntityTypeConfiguration<ElectricityMeasuringPointsSettlementMeters>
    {
        public void Configure(EntityTypeBuilder<ElectricityMeasuringPointsSettlementMeters> builder)
        {
            builder.HasKey(empsm => new 
            { 
                empsm.ElectricityMeasuringPointId,
                empsm.SettlementMeterId, 
                empsm.StartTime, 
                empsm.EndTime 
            });
        }
    }
}
