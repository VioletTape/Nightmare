using System.Collections.Generic;
using System.Linq;

namespace Nightmare {
    /// <summary>
    /// Описание персонажа и все связанные с ним действия: 
    /// броски кубиков, рассчет атаки и так далее.
    /// Работа с инвентарем.
    /// </summary>
    public class Character {
        public List<Item> Bag = new List<Item>();
        public Player Player { get; set; }

        public decimal Level { get; set; }
        public decimal Xp { get; set; }

        public Character() {
            Level = 1;
        }

        /// <summary>
        /// Вывод значения кубиков, брошеных игроком
        /// </summary>
        /// <param name="dices"></param>
        /// <returns></returns>
        public string GetDices(List<int> dices) {
            return string.Join(":", dices);
        }

        /// <summary>
        /// Рассчет атак (сила и защита) на основе одетой одежды, оружия\щитов
        /// </summary>
        /// <returns></returns>
        public List<Attack> GetAttacks() {
            var weapons = new List<Weapon>();
            var shields = new List<Shield>();
            var wears = new List<Wear>();

            foreach (var item in Bag) {
                if (item.Type == "W") {
                    var weapon = ((Weapon) item);
                    if (!weapon.Equiped == false) {
                        weapons.Add(weapon);
                    }
                }
                if (item.Type == "S") {
                    var shield = ((Shield) item);
                    if (!shield.Equiped == false) {
                        shields.Add(shield);
                    }
                }
                if (item.Type == "Wr") {
                    var wear = ((Wear) item);
                    if (wear.Equiped == false) {
                        wears.Add(wear);
                    }
                }
            }


            var attack = new Attack {
                // power consist of a number different variable and parameters. The main of them and the basement is 
                // the GetAttacks parameter. Then it should be summarized with bonus power depends on level.
                // Finally it adds attack abilities from wears. 
                Power = (int) (weapons.Sum(i => i.Attack) + weapons.Sum(i => i.Attack)*Level*0.5m + wears.Sum(i => i.Attack) + wears.Sum(i => i.Attack)*Level*0.2m),
                Defence = (int) (shields.Sum(i => i.Defence) + shields.Sum(i => i.Defence)*Level*0.5m + wears.Sum(i => i.Defence) + wears.Sum(i => i.Defence)*Level*0.2m),
                Special = 0
            };

            return new List<Attack> {attack};
        }

        /// <summary>
        /// Определение можно ли использовать оружие персонажу
        /// если можно, то использует
        /// </summary>
        /// <param name="weapon"></param>
        public void Equip(Weapon weapon) {
            var result = weapon.CanWearFor(Player);
            if (result) {
                weapon.Equiped = true;
            }
        }

        /// <summary>
        /// Пополнение жизни персонажу
        /// </summary>
        /// <param name="character"></param>
        public void FillLife(Character character) {
            character.Player.Life = character.Player.MaxLife;
        }

        /// <summary>
        /// Пополнение выносливости персонажу
        /// </summary>
        /// <param name="character"></param>
        public void FillStamina(Character character) {
            character.Player.Stamina = character.Player.MaxStamina;
        }

        /// <summary>
        /// Определение можно ли использовать одежу персонажу
        /// если можно, то использует
        /// </summary>
        /// <param name="wear"></param>
        public void Equip(Wear wear) {
            var result = wear.CanWearFor(Player);
            if (result) {
                wear.Equiped = true;
            }
        }

        /// <summary>
        /// Определение можно ли использовать щит персонажу
        /// если можно, то использует
        /// </summary>
        /// <param name="shield"></param>
        public void Equip(Shield shield) {
            var result = shield.CanWearFor(Player);
            if (result) {
                shield.Equiped = true;
            }
        }
    }
}