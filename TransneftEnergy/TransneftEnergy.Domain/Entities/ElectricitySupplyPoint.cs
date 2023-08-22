namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Точка поставки электроэнергии.
    /// </summary>
    public class ElectricitySupplyPoint : Entity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Максимальная мощность (кВт).
        /// </summary>
        public double MaxPower { get; set; }

        /// <summary>
        /// Идентификатор объекта потребления.
        /// </summary>
        public int ConsumptionObjectId { get; set; }

        /// <summary>
        /// Объект потребления.
        /// </summary>
        public virtual ConsumptionObject? ConsumptionObject { get; set; }

        /// <summary>
        /// Расчетные приборы учета.
        /// </summary>
        public virtual ICollection<SettlementMeter> SettlementMeters { get; } = new List<SettlementMeter>();
    }
}
