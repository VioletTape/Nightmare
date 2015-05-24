using System;
using System.Collections.Generic;
using System.Linq;

namespace Nightmare {
    /// <summary>
    /// Класс ответственный за коммуникацию между разными 
    /// частями и механиками игры. 
    /// </summary>
    public class Game {
        private List<Attack> charAttack;
        private List<Attack> beastAttack;
        public Character Character;

        /// <summary>
        /// Бросок кубиков для игрока. Количество кубиков рассчитывается на основе 
        /// параметров игрока. 
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Количество точек для каждого кубика</returns>
        public List<int> Dices(Player player) {
            var rolls = 2;
            if (player.Stats[6] > 5) {
                rolls += 1;
            }
            if (player.Stats[6] > 15 && player.Stats[1] > 10) {
                rolls += 2;
            }
            if (player.Stats[6] > 25 && player.Stats[4] > 20) {
                rolls += 3;
            }

            var ints = new List<int>();
            var random = new Random();

            for (var i = 0; i < rolls; i++) {
                ints.Add(random.Next(6) + 1);
            }

            return ints;
        }

        /// <summary>
        /// Игрок получает новый уровень. Задается количество очков для увеличения
        /// характеристик. Жизнь и выносливость растут согласно коэффициентам 
        /// класса персонажа
        /// </summary>
        /// <param name="character"></param>
        /// <param name="form1"></param>
        public void LevelUp(Character character, Form1 form1) {
            character.Player.LevelPoints = 5;
            character.Player.Life = character.Player.Life + character.Player.Life*(int) character.Player.life[character.Player.Class][0];
            character.Player.Stamina = character.Player.Stamina + character.Player.Life*(int) character.Player.life[character.Player.Class][1];

            form1.NewLevel();
        }

        /// <summary>
        /// Битва между персонажем и чудовищем
        /// </summary>
        /// <param name="character"></param>
        /// <param name="beast"></param>
        public void Fight(Character character, Beast beast) {
            charAttack = character.GetAttacks();
            beastAttack = beast.GetAttacks();
        }

        /// <summary>
        /// Рассчет одного хода битвы 
        /// В зависимости от того, у кого круче уровень, будет по разному рассчитаны коэффициенты атаки и защиты,
        /// соответственно и урона. 
        /// Далее сравниваются атака и защита борющихся и в зависимости от этого опять же меняются коэффициенты. 
        /// </summary>
        /// <param name="character"></param>
        /// <param name="beast"></param>
        /// <param name="charDices"></param>
        /// <param name="beastDices"></param>
        public void Turn(Character character, Beast beast, List<int> charDices, List<int> beastDices) {
            if (character.Level > beast.Level) {
                if (charAttack.Count >= beastAttack.Count) {
                    for (var i = 0; i < charAttack.Count; i++) {
                        if (charAttack[i].Power > beastAttack[i].Defence) {
                            if (charDices.Count(j => j == 6) >= 1) {
                                beast.Life -= charAttack[i].Power - (int) (beastAttack[i].Defence*0.4m);
                            }
                            else {
                                if (charDices.Count(j => j == 5) >= 2) {
                                    beast.Life -= charAttack[i].Power - (int) (beastAttack[i].Defence*0.6m);
                                }
                                if (charDices.Count(j => j == 5) >= 1) {
                                    beast.Life -= charAttack[i].Power - (int) (beastAttack[i].Defence*0.8m);
                                }
                            }
                        }

                        if (charAttack[i].Power < beastAttack[i].Defence) {
                            if (charDices.Count(j => j == 6) >= 2) {
                                beast.Life -= charAttack[i].Power - (int) (beastAttack[i].Defence*0.5m);
                            }
                            else {
                                if (charDices.Count(j => j == 5) <= 0) {
                                    character.Player.Life -= charAttack[i].Power - (int) (beastAttack[i].Defence*0.8m);
                                }
                                if (charDices.Count(j => j == 5) < 2) {
                                    beast.Life -= charAttack[i].Power - (int) (beastAttack[i].Defence*0.4m);
                                }
                            }
                        }
                    }
                }
            }

            if (beast.Life <= 0) {
                new ExpierenceService().AddXp(character, beast);
            }
        }

        /// <summary>
        /// Бросок костей для монстра, в зависимости от уровня
        /// </summary>
        /// <param name="beast"></param>
        /// <returns></returns>
        public List<int> AiDice(Beast beast) {
            var ints = new List<int>();
            var random = new Random();

            var rolls = beast.Level;
            for (var i = 0; i < rolls; i++) {
                ints.Add(random.Next(6) + 1);
            }

            return ints;
        }

        /// <summary>
        /// Создание различных областей игры, по которым будет путешествовать персонаж
        /// </summary>
        /// <param name="name"></param>
        /// <param name="areaType"></param>
        /// <param name="IsFightArea"></param>
        /// <param name="IsMerchArea"></param>
        /// <param name="IsSecretArea"></param>
        /// <param name="discoverXp"></param>
        /// <returns></returns>
        public Area CreateArea(string name, AreaType areaType, bool IsFightArea, bool IsMerchArea, bool IsSecretArea, bool IsTravelArea, bool IsQuestArea, int discoverXp) {
            if (name == "" || name == null) {
                throw new ArgumentException("Name should be filled");
            }

            return new Area {
                Name = name,
                AreaType = areaType,
                DiscoverXp = discoverXp,
                IsFightArea = IsFightArea,
                IsMerchArea = IsMerchArea,
                IsSecretArea = IsSecretArea,
                IsQuestArea = IsQuestArea,
                IsTravelArea = IsTravelArea,
                Undiscovered = true,
                Game = this
            };
        }
    }
}