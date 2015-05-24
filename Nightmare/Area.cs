using System.Collections.Generic;
using System.Linq;

namespace Nightmare {
    /// <summary>
    /// Класс содержит информацию об области где находится главный герой. 
    /// В зависимости от типа области накладываются штрафы или бонусы на героя 
    /// (так же зависят от способностей героя) 
    /// Область может быть только одной специализации. 
    /// </summary>
    public struct Area {
        public string Name;
        public AreaType AreaType;
        /// <summary>
        /// обозначает враждебную область. всегда.
        /// </summary>
        public bool IsFightArea;
        /// <summary>
        /// зона торговли или нет
        /// </summary>
        public bool IsMerchArea;
        /// <summary>
        /// является ли это скрытой областью, которая открывается спец.средствами
        /// </summary>
        public bool IsSecretArea;
        /// <summary>
        /// является ли эта область проходной для путешественника, где не обязательно 
        /// будут стычки с врагами
        /// </summary>
        public bool IsTravelArea;
        /// <summary>
        /// Является ли область выделенной под квест и попасть туда можно только
        /// взяв и выполняя определенный квест
        /// </summary>
        public bool IsQuestArea;


        /// <summary>
        /// количество опыта герою за открытие зоны 
        /// </summary>
        public int DiscoverXp;

        public bool Undiscovered;
        private Character character;
        public Game Game { get; set; }

        /// <summary>
        /// Обработка логики вхождения игрока в игровую зону
        /// </summary>
        /// <param name="character"></param>
        public void PlayerEnter(Character character) {
            Undiscovered = false;
            this.character = character;
            // тут должна быть реализация
        }

        public void GenerateBeasts() {
            
        }

        public void StartFight() {
            var beasts = new List<Beast>();
            Game.Fight(character, beasts.First());
            while (beasts.First().Life > 0 || character.Player.Life > 0) {
                Game.Turn(character, beasts.First(), Game.Dices(character.Player), Game.AiDice(beasts.First()));
            }

        }
    }
}