using System;
using System.Linq;
using TheSlum.Bonuses;
using TheSlum.Characters;
using TheSlum.Items;

namespace TheSlum.GameEngine
{
    class ModifiedEngine : Engine
    {
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "add":
                    this.AddItem(inputParams);
                    break;
                case "create":
                    this.CreateCharacter(inputParams);
                    break;
                case "status":
                    this.PrintCharactersStatus(characterList);
                    break;
                default:
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            string id = inputParams[2];
            int x = Convert.ToInt32(inputParams[3]);
            int y = Convert.ToInt32(inputParams[4]);
            var team = (Team) Enum.Parse(typeof(Team), inputParams[5]);

            switch (inputParams[1])
            {
                case "warrior":
                    this.characterList.Add(new Warrior(id, x, y, team));
                    break;
                case "mage":
                    this.characterList.Add(new Mage(id, x, y, team));
                    break;
                case "healer":
                    this.characterList.Add(new Healer(id, x, y, team));
                    break;
                default:
                    break;
            }
        }

        protected new void AddItem(string[] inputParams)
        {
            string characterId = inputParams[1];
            string itemClass = inputParams[2];
            string itemId = inputParams[3];
            var value = this.characterList.FindIndex(c => c.Id == characterId);

            switch (itemClass)
            {
                case "shield":
                    this.characterList[value].AddToInventory(new Shield(itemId));
                    break;
                case "axe":
                    this.characterList[value].AddToInventory(new Axe(itemId));
                    break;
                case "injection":
                    this.characterList[value].AddToInventory(new Injection(itemId));
                    break;
                case "pill":
                    this.characterList[value].AddToInventory(new Pill(itemId));
                    break;
            }
        }
    }
}

// create characterClass id x y team
// add character itemClass itemId
