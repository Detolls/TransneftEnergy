namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Счетчик электрической энергии.
    /// </summary>
    public class ElectricityMeter : Entity
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public required string Number { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        public ElectricityMeterType Type { get; set; }

        /// <summary>
        /// Дата проверки.
        /// </summary>
        public DateTime VerificationDate { get; set; }

        /// <summary>
        /// Точка измерения электроенергии.
        /// </summary>
        public virtual ElectricityMeasuringPoint? ElectricityMeasuringPoint { get; set; }
    }
}
