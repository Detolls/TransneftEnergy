namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Связь между точкой измерения электроэнергии и расчетным прибором учета.
    /// </summary>
    public class ElectricityMeasuringPointsSettlementMeters
    {
        /// <summary>
        /// Идентификатор точки измерения электроэнергии.
        /// </summary>
        public int ElectricityMeasuringPointId { get; set; }

        /// <summary>
        /// Точка измерения электроэнергии.
        /// </summary>
        public virtual ElectricityMeasuringPoint? ElectricityMeasuringPoint { get; set; }

        /// <summary>
        /// Идентификатор расчетного прибора учета.
        /// </summary>
        public int SettlementMeterId { get; set; }

        /// <summary>
        /// Расчетный прибор учета.
        /// </summary>
        public SettlementMeter? SettlementMeter { get; set; }

        /// <summary>
        /// Интервал (с).
        /// </summary>
        public DateTime StartTime { get; set; }

        /// <summary>
        /// Интервал (по).
        /// </summary>
        public DateTime EndTime { get; set; }
    }
}
