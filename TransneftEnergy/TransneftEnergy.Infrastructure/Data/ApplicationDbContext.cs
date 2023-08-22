using Microsoft.EntityFrameworkCore;
using TransneftEnergy.Domain.Entities;

namespace TransneftEnergy.Infrastructure.Data
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        /// <summary>
        /// Организации.
        /// </summary>
        public DbSet<Organization> Organizations => Set<Organization>();

        /// <summary>
        /// Родительские организации.
        /// </summary>
        public DbSet<ChildOrganization> ChildOrganizations => Set<ChildOrganization>();

        /// <summary>
        /// Объекты потребления.
        /// </summary>
        public DbSet<ConsumptionObject> ConsumptionObjects => Set<ConsumptionObject>();

        /// <summary>
        /// Точки измерения электроэнергии.
        /// </summary>
        public DbSet<ElectricityMeasuringPoint> ElectricityMeasuringPoints => Set<ElectricityMeasuringPoint>();

        /// <summary>
        /// Счетчики электроэнергии.
        /// </summary>
        public DbSet<ElectricityMeter> ElectricityMeters => Set<ElectricityMeter>();

        /// <summary>
        /// Трансформаторы тока.
        /// </summary>
        public DbSet<CurrentTransformer> CurrentTransformers => Set<CurrentTransformer>();

        /// <summary>
        /// Трансформаторы напряжения.
        /// </summary>
        public DbSet<VoltageTransformer> VoltageTransformers => Set<VoltageTransformer>();

        /// <summary>
        /// Точки поставки электроэнергии.
        /// </summary>
        public DbSet<ElectricitySupplyPoint> ElectricitySupplyPoints => Set<ElectricitySupplyPoint>();

        /// <summary>
        /// Расчетные приборы учета.
        /// </summary>
        public DbSet<SettlementMeter> SettlementMeters => Set<SettlementMeter>();

        /// <summary>
        /// Связи между точками измерения электроэнергии и расчетными приборами учета.
        /// </summary>
        public DbSet<ElectricityMeasuringPointsSettlementMeters> ElectricityMeasuringPointsSettlementMeters => Set<ElectricityMeasuringPointsSettlementMeters>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
