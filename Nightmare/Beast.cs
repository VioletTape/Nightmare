﻿using System.Collections.Generic;

namespace Nightmare {
    /// <summary>
    /// Базовый класс для всех типов существ с которым будет сражаться главный герой
    /// Класс содержит все данные, которые учитываются при расчете защиты и атаки
    /// </summary>
    public class Beast {
        public int IsFlying = 0;
        public int IsStomping = 0;
        public int IsPoison = 0;
        public int Life = 10;
        public int Stamina = 10;
        public int Xp = 3;
        public int Level = 1;
        public int BaseAttack = 1;
        public int Defence = 0;
        public int Name;

        public int Stunned;

        /// <summary>
        /// Может быть больше одной атаки за раз
        /// </summary>
        /// <returns></returns>
        public List<Attack> GetAttacks() {
            var result = new Attack {
                Defence = 0,
                Power = BaseAttack,
                Special = 0
            };

            var val = BaseAttack;

            if (IsFlying == 1) {
                val = val + (int) (Level*0.7m);
            }
            result.Special += val;

            if (IsFlying == 1) {
                val = (int) (Defence*1.2m);
            }
            result.Defence += val;


            if (IsStomping > 0) {
                val = result.Power + IsStomping;
            }
            result.Power = val;

            if (IsStomping > 0) {
                val = result.Special + IsStomping;
            }
            result.Special += val;

            // If beast with IsPoison ability he can attack twice
            return IsPoison == 0
                ? new List<Attack> {result}
                : new List<Attack> {result, result};
        }

        /// <summary>
        /// Модификатор оглушения существа
        /// </summary>
        /// <returns></returns>
        private bool IsStunned() {
            return Stunned > 0;
        }
    }

    /// <summary>
    /// Структура для расчета повреждений во время боя
    /// </summary>
    public struct Attack {
        public int Power;
        public int Defence;
        public int Special;
    }
}