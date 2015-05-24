namespace Nightmare {
    /// <summary>
    /// Класс содержит информацию об области где находится главный герой. 
    /// В зависимости от типа области накладываются штрафы или бонусы на героя 
    /// (так же зависят от способностей героя) 
    /// Область может быть только одной специализации. 
    /// </summary>
    public struct Area {
        public string Name;
        public AreaType AreaType;
        /// <summary>
        /// обозначает враждебную область. всегда.
        /// </summary>
        public bool IsFightArea;
        /// <summary>
        /// зона торговли или нет
        /// </summary>
        public bool IsMerchArea;
        /// <summary>
        /// является ли это скрытой областью, которая открывается спец.средствами
        /// </summary>
        public bool IsSecretArea;
        /// <summary>
        /// является ли эта область проходной для путешественника, где не обязательно 
        /// будут стычки с врагами
        /// </summary>
        public bool IsTravelArea;
        /// <summary>
        /// Является ли область выделенной под квест и попасть туда можно только
        /// взяв и выполняя определенный квест
        /// </summary>
        public bool IsQuestArea;


        /// <summary>
        /// количество опыта герою за открытие зоны 
        /// </summary>
        public int DiscoverXp;

        public bool Undiscovered;

        /// <summary>
        /// Обработка логики вхождения игрока в игровую зону
        /// </summary>
        /// <param name="character"></param>
        public void PlayerEnter(Character character) {
            Undiscovered = false;
            // тут должна быть реализация
        }
    }
}