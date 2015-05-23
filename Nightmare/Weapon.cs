namespace Nightmare {
    /// <summary>
    /// Класс для описания всех видов оружия. Оно может быть следующих типов:
    /// - Дубина
    /// - Меч
    /// - Кинжал
    /// - Посох
    /// - Лук
    /// </summary>
    public class Weapon : Item {
        public int Id;

        public bool Mace;
        public bool Sword;
        public bool Dagger;
        public bool Staff;
        public bool Bow;

        // урон оружия
        public int Attack;

        // используется оружие или нет
        public bool Equiped;

        public Weapon() {
            Type = "W";
        }

        /// <summary>
        /// В классе указывается, какой класс персонажа 
        /// какой тип оружия может быть использован
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public bool CanWearFor(Player player) {
            switch (player.Class) {
                case "Warrior":
                    Equiped = true;
                    return true;
                    break;
                case "Paladin":
                    if (Mace || Sword || Dagger || Bow) {
                        Equiped = true;
                        return true;
                    }
                    else {
                        return false;
                    }

                    break;
                case "Wizard":
                    if (!Staff) {
                        return false;
                    }
                    else {
                        Equiped = true;
                        return true;
                    }
                    break;
                case "Rouge":
                    if (Dagger || Bow) {
                        Equiped = true;

                        return true;
                    }
                    else {
                        return false;
                    }
                    break;
                case "Barbarian":
                    Equiped = true;

                    return true;
                    break;
            }

            return true;
        }
    }
}