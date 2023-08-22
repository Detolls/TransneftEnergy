namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Точка измерения электроенергии.
    /// </summary>
    public class ElectricityMeasuringPoint : Entity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Идентификатор объекта потребления.
        /// </summary>
        public int ConsumptionObjectId { get; set; }

        /// <summary>
        /// Объект потребления.
        /// </summary>
        public virtual ConsumptionObject? ConsumptionObject { get; set; }

        /// <summary>
        /// Идентификатор счетчика электроэнергии.
        /// </summary>
        public int ElectricityMeterId { get; set; }

        /// <summary>
        /// Счетчик электроэнергии.
        /// </summary>
        public virtual ElectricityMeter? ElectricityMeter { get; set; }

        /// <summary>
        /// Идентификатор трансформатора тока.
        /// </summary>
        public int CurrentTransformerId { get; set; }

        /// <summary>
        /// Трансформатор тока.
        /// </summary>
        public virtual CurrentTransformer? CurrentTransformer { get; set; }

        /// <summary>
        /// Идентификатор трансформатора напряжения.
        /// </summary>
        public int VoltageTransformerId { get; set; }

        /// <summary>
        /// Трансформатор напряжения.
        /// </summary>
        public virtual VoltageTransformer? VoltageTransformer { get; set; }
    }
}
