namespace TransneftEnergy.Domain.Enums
{
    /// <summary>
    /// Тип трансформатора напряжения.
    /// </summary>
    public enum VoltageTransformerType
    {
        /// <summary>
        /// Заземляемый.
        /// </summary>
        Grounded = 1,

        /// <summary>
        /// Незаземляемый.
        /// </summary>
        Ungrounded,

        /// <summary>
        /// Каскадный.
        /// </summary>
        Cascading,

        /// <summary>
        /// Ёмкостный.
        /// </summary>
        Capacitive,

        /// <summary>
        /// Двухобмоточный.
        /// </summary>
        DoubleWinding,

        /// <summary>
        /// Трёхобмоточный.
        /// </summary>
        ThreeWinding,

        /// <summary>
        /// Оптико-электронный.
        /// </summary>
        Optoelectronic
    }
}
