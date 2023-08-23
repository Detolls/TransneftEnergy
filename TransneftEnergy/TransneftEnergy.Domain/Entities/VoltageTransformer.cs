namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Трансформатор напряжения.
    /// </summary>
    public class VoltageTransformer : BaseTransformerEntity<VoltageTransformerType>
    {
        /// <summary>
        /// Точка измерения электроенергии.
        /// </summary>
        public virtual ElectricityMeasuringPoint? ElectricityMeasuringPoint { get; set; }
    }
}
