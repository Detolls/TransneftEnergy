namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Расчетный прибор учета.
    /// </summary>
    public class SettlementMeter : Entity
    {
        /// <summary>
        /// Идентификатор точки поставки электроэнергии.
        /// </summary>
        public int ElectricitySupplyPointId { get; set; }

        /// <summary>
        /// Точка поставки электроэнергии.
        /// </summary>
        public virtual ElectricitySupplyPoint? ElectricitySupplyPoint { get; set; }
    }
}
