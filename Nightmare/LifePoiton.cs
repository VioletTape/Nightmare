namespace Nightmare {
    /// <summary>
    /// Пузырёк для восстановления жизни. Всей.
    /// </summary>
    public class LifePoiton : Item {
        public void Use(Character character) {
            new ExpierenceService().FillLife(character);
        }
    }
}