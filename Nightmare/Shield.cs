namespace Nightmare {
    /// <summary>
    /// Все щиты описываются этим классом
    /// </summary>
    public class Shield : Item {
        public int Id;
        public int Defence;

        public bool Equiped;

        public Shield() {
            Type = "S";
        }

        /// <summary>
        /// Определяет, может ли персонаж использовать щит
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool CanWearFor(Player player) {
            return true;
        }
    }
}