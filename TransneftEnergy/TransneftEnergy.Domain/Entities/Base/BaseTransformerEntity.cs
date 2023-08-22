namespace TransneftEnergy.Domain.Entities.Base
{
    public abstract class BaseTransformerEntity<TType> : Entity
        where TType : struct, Enum
    {
        /// <summary>
        /// Номер.
        /// </summary>
        public required string Number { get; set; }

        /// <summary>
        /// Тип.
        /// </summary>
        public TType Type { get; set; }

        /// <summary>
        /// Коэффициент трансформации.
        /// </summary>
        public double TransformationRatio { get; set; }

        /// <summary>
        /// Дата проверки.
        /// </summary>
        public DateTime VerificationDate { get; set; }
    }
}
