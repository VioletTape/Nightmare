namespace Nightmare {
    /// <summary>
    /// Базоый класс для всех типов одежды для персонажа. 
    /// Одёжа может быть как для защиты, так и добавлять бонусов к атаке. 
    /// Например пинок сабатоном чувствительнее пинка мокасином
    /// </summary>
    public class Wear : Item {
        public int Id;
        public int Attack;
        public int Defence;

        public bool Equiped;

        public Wear() {
            Type = "Wr";
        }

        /// <summary>
        /// Метод определяет может ли персонаж одеть конкретную одежку
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool CanWearFor(Player player) {
            return true;
        }
    }
}