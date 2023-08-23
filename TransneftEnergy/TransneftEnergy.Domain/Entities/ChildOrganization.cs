namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Дочерняя организация.
    /// </summary>
    public class ChildOrganization : BaseOrganizationEntity
    {
        /// <summary>
        /// Идентификатор родительской организации.
        /// </summary>
        public int ParentOrganizationId { get; set; }

        /// <summary>
        /// Родительская организация.
        /// </summary>
        public virtual Organization? ParentOrganization { get; set; }
    }
}
