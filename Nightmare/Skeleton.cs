namespace Nightmare {
    class Skeleton : Beast {
        public Skeleton() {
            base.BaseAttack = 13;
            base.Defence = 20;
            base.Name = "Thursty Skelet";
        }
    }

    class SkeletonArcher : Skeleton {
        public SkeletonArcher() {
            Name = "Skeleton Archer";
            BaseAttack = 12;
        }
    }
}