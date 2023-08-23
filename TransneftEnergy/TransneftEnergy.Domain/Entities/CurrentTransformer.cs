namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Трансформатор тока.
    /// </summary>
    public class CurrentTransformer : BaseTransformerEntity<CurrentTransformerType>
    {
        /// <summary>
        /// Точка измерения электроенергии.
        /// </summary>
        public virtual ElectricityMeasuringPoint? ElectricityMeasuringPoint { get; set; }
    }
}
