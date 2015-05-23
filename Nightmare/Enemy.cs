using System.Collections.Generic;

namespace Nightmare {
    /// <summary>
    /// Базовый класс для всех типов существ с которым будет сражаться главный герой
    /// Класс содержит все данные, которые учитываются при расчете защиты и атаки.
    ///  
    /// Существа могут быть летающими, ядовитыми, а так же с "пробивным" ударом.  
    /// Все эти свойства могут комбинироваться в произвольном порядке и проявится все
    /// вместе в одном существе.
    /// 
    /// Класс задает некоторые базовые значения для чудовища 1го уровня.
    /// 
    /// Может быть оглушен и получить штраф к защите в размере оглушения. Может сам оглушать
    /// специальной атакой.
    /// </summary>
    public abstract class Enemy {
        public int Life = 10;
        public int Stamina = 10;
        public int Xp = 3;
        public int Level = 1;
        public int BaseAttack = 1;
        public int Defence = 0;
        public int Name;

        /// <summary>
        /// Расчет структуры защиты, мощи и спец.ударов для выяснения 
        /// кто круче, герой-задохлик или же этот красавец.
        /// </summary>
        /// <returns></returns>
        public virtual List<Attack> Attacks() {
            return new List<Attack> {
                new Attack {
                    Defence = OrdinalDefence() + SpecialDefence(),
                    Power = OrdinalAttack() + AirAttack() + StunAttack(),
                    Special =  SpecialAttack() + BonusAttack()
                }
            };
        }

        // Методы должны быть переопределены в наследниках, 
        // чтобы можно было рассчитать структуру для выяснения того,
        // кто круче
        public abstract int OrdinalAttack();
        public abstract int AirAttack();
        public abstract int SpecialAttack();
        public abstract int StunAttack();
        public abstract int BonusAttack();
        public abstract int OrdinalDefence();
        public abstract int SpecialDefence();
        
    }
}