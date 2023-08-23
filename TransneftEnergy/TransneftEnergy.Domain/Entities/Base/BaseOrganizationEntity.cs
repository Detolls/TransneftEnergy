namespace TransneftEnergy.Domain.Entities.Base
{
    public abstract class BaseOrganizationEntity : Entity
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Адрес.
        /// </summary>
        public required string Address { get; set; }
    }
}
