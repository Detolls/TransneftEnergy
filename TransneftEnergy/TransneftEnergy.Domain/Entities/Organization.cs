namespace TransneftEnergy.Domain.Entities
{
    /// <summary>
    /// Организация.
    /// </summary>
    public class Organization : BaseOrganizationEntity
    {
        /// <summary>
        /// Дочерние организации.
        /// </summary>
        public virtual ICollection<ChildOrganization>? ChildOrganizations { get; set; }
    }
}
