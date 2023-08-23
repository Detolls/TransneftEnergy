namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Объект потребления.
    /// </summary>
    public class ConsumptionObject : Entity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public required string Address { get; set; }

        /// <summary>
        /// Идентификатор дочерней организации.
        /// </summary>
        public int ChildOrganizationId { get; set; }

        /// <summary>
        /// Дочерняя организация.
        /// </summary>
        public virtual ChildOrganization? ChildOrganization { get; set; }

        /// <summary>
        /// Точки измерения электроэнергии.
        /// </summary>
        public virtual ICollection<ElectricityMeasuringPoint> ElectricityMeasuringPoints { get; } = new List<ElectricityMeasuringPoint>();

        /// <summary>
        /// Точки поставки электроэенергии.
        /// </summary>
        public virtual ICollection<ElectricitySupplyPoint> ElectricitySupplyPoints { get; } = new List<ElectricitySupplyPoint>();
    }
}
