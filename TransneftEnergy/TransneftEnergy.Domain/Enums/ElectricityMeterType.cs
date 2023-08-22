namespace TransneftEnergy.Domain.Enums
{
    /// <summary>
    /// Тип счетчика электроэнергии.
    /// </summary>
    public enum ElectricityMeterType
    {
        /// <summary>
        /// Индукционный.
        /// </summary>
        Induction = 1,

        /// <summary>
        /// Электронный.
        /// </summary>
        Electronic,

        /// <summary>
        /// Гибридный.
        /// </summary>
        Hybrid
    }
}
