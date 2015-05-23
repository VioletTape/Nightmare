using System.Collections.Generic;

namespace Nightmare {
    public abstract class Enemy {
        public int Life = 10;
        public int Stamina = 10;
        public int Xp = 3;
        public int Level = 1;
        public int BaseAttack = 1;
        public int Defence = 0;
        public int Name;

        public virtual List<Attack> Attacks() {
            return new List<Attack> {
                new Attack {
                    Defence = OrdinalDefence() + SpecialDefence(),
                    Power = OrdinalDamage() + AirDamage() + StunDamage(),
                    Special =  SpecialDamage() + BonusDamage()
                }
            };
        }

        public abstract int OrdinalDamage();
        public abstract int AirDamage();
        public abstract int SpecialDamage();
        public abstract int StunDamage();
        public abstract int BonusDamage();
        public abstract int OrdinalDefence();
        public abstract int SpecialDefence();
        
    }
}