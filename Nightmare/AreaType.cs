namespace Nightmare {
    /// <summary>
    /// Тип области куда попадает игрок, в зависимости от этого доступны разные действия, 
    /// накладываются бонусы и штрафы.
    /// </summary>
    public enum AreaType {
        /// <summary>
        /// Арена
        /// </summary>
        Arena,
        /// <summary>
        /// Перекресток
        /// </summary>
        Crossroad,
        /// <summary>
        /// Квестовая зона 
        /// </summary>
        Quest,
        /// <summary>
        /// Рынок
        /// </summary>
        Market,
        /// <summary>
        /// Дорога
        /// </summary>
        Road
    }
}