using System;

namespace Nightmare {
    /// <summary>
    /// Сервис для рассчета опыта получаемого героем за убийства разного рода упырей
    /// и прочих вражин
    /// </summary>
    public class ExpierenceService {
        /// <summary>
        /// Рассчет количества опыта получаемого за врага. 
        /// опыт начисляется в зависимости от того, какая разница уровней
        /// есть между сражающимися. Если один из них слишком крут, то опыта
        /// не будет.
        /// </summary>
        /// <param name="character"></param>
        /// <param name="beast"></param>
        public void AddXp(Character character, Beast beast) {
            if (beast == null) {
                throw new ArgumentNullException("beast");
            }

            if (character.Level - beast.Level > 10) {
                return;
            }

            if (character.Level - beast.Level > -10) {
                return;
            }

            if (character.Level > beast.Level) {
                character.Xp += beast.Xp*Math.Abs(character.Level - beast.Level)/10;
            }

            if (character.Level < beast.Level) {
                character.Xp += beast.Xp*(Math.Abs(character.Level - beast.Level)/10 + 1);
            }
        }

        /// <summary>
        /// При наступлении нового уровня, герою восполняются жизни
        /// </summary>
        /// <param name="character"></param>
        public void FillLife(Character character) {
            if (character == null) {
                throw new ArgumentNullException("character");
            }

            character.Player.Life = character.Player.MaxLife;
        }

        /// <summary>
        /// Рассчет того, сколько получит герой за убийство монстра
        /// </summary>
        /// <param name="character"></param>
        /// <param name="enemy"></param>
        public void AddXp(Character character, Enemy enemy) {
            if (character.Level - enemy.Level > 10) {
                return;
            }

            if (character.Level - enemy.Level > -10) {
                return;
            }

            if (character.Level > enemy.Level) {
                character.Xp += enemy.Xp*Math.Abs(character.Level - enemy.Level)/10;
            }

            if (character.Level < enemy.Level) {
                character.Xp += enemy.Xp*(Math.Abs(character.Level - enemy.Level)/10 + 1);
            }
        }

        /// <summary>
        /// Метод создает оружие в награду за убийство монстра
        /// </summary>
        /// <param name="game"></param>
        /// <returns></returns>
        public Weapon CastLoot(Game game) {
            return new WeaponSelector().Generate("Any", game);
        } 

        /// <summary>
        /// При наступлении нового уровня, метод восстанавливает выносливость у персонажа
        /// </summary>
        /// <param name="character"></param>
        public void FillStamina(Character character) {
            character.Player.Stamina = character.Player.MaxStamina;
        }
    }
}