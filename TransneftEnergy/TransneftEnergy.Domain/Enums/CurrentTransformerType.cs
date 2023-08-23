namespace TransneftEnergy.Domain.Enums
{
    /// <summary>
    /// Тип трансформатора тока.
    /// </summary>
    public enum CurrentTransformerType
    {
        /// <summary>
        /// Обмоточный.
        /// </summary>
        Winding = 1,

        /// <summary>
        /// Тороидальный.
        /// </summary>
        Toroidal,

        /// <summary>
        /// Стержневой.
        /// </summary>
        Pivotal
    }
}
