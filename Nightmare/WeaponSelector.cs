namespace Nightmare {
    /// <summary>
    /// Генерация и выбор оружия для персонажа на основе переданных параметров
    /// </summary>
    public class WeaponSelector {
        private Weapon weapon;

        /// <summary>
        /// Генерация и выбор оружия для персонажа на основе переданных параметров.
        /// Если передается Any, то генерируем любое оружие. Если передается конкретный тип,
        /// то генерируем до тех пор, пока не попадется нужный тип оружия   
        /// </summary>
        /// <param name="name">Имя оружия для генерации. Any - рандомное оружие</param>
        /// <param name="game"></param>
        /// <returns></returns>
        public Weapon Generate(string name, Game game) {
            var weaponGenerator = new WeaponGenerator();
            var flag = true;

            if (name == "Any") {
                return weaponGenerator.Generate(game.Character);
            }

            do {
                weapon = weaponGenerator.Generate(game.Character);
                if (weapon.Mace) {
                    flag = name.ToLower() == "mace";
                }
                if (weapon.Sword) {
                    flag = name.ToLower() == "sword";
                }
                if (weapon.Dagger) {
                    flag = name.ToLower() == "dagger";
                }
                if (weapon.Staff) {
                    flag = name.ToLower() == "staff";
                }
                if (weapon.Bow) {
                    flag = name.ToLower() == "bow";
                }
            } while (!flag);

            return weapon;
        }
    }
}