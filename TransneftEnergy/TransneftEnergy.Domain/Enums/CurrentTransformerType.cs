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
        MultiTurn = 1,

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
