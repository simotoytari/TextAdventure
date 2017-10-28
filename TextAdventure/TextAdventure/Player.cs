using System;
using System.Text;
using System.Collections.Generic;

namespace TextAdventure
{
	public class Player : HumanoidBase
	{
		private string Gender;
		private string Race;
		private string Class;
		private List<string> inventory = new List<string>();

		public Player (string Gender, string Race, string Class, string Name)
			:base(Name, 100, 1, 1, 1, 1, 1, 1)
		{
			this.Gender = Gender;
			this.Race = Race;
			this.Class = Class;
			inventory.Add ("Rusty blade");
			inventory.Add ("Moldy bread");
			setPlayerDamage (Race, Class);
		}

		//returns players general info
		public string getPlayerInfo()
		{
			string output = String.Format("{0} is a {1} {2}. Class {3}",getName(),Race, Gender, Class);
			return output;
		}

		//returns players health
		public string getPlayerHealth()
		{
			string output = String.Format ("You have {0} health.", getHealth());
			return output;
		}


		//returns players inventory and writes it on screen
		public List<string> getPlayerInventory(bool writeInventory)
		{
			if (writeInventory) {
				Console.WriteLine ("Your inventory:");
				for (int i = 0; i < inventory.Count; i++) {
					Console.WriteLine (inventory [i]);
				}
			}
			return inventory;
		}

		//add items to player inventory
		public void setPlayerInventory(string item)
		{
			inventory.Add (item);
			Console.WriteLine ("{0} was added to your inventory!", item);
		}

		//return player combat stats
		public string getPlayerCS()
		{
			string output = String.Format ("Your combat stats are:\nAttack damage {0}\n" +
				"Ranged damage {1}\nMagic damage {2}\nAttack damage resistance {3}\n" +
				"Range damage resistance {4}\nMagic damage resistance {5}\nType STATS if you wants to see your combat stats midgame.", 
				getAttackDamage(), getRangeDamage(), getMagicDamage(), getARD(), getRDR(), getMDR());
			return output;
		}

		//Set attack, range and magic damage depending on player race and class
		private void setPlayerDamage(string race, string classs)
		{
			//set race bonuses
			if (race == "ORC") {
				heal (20);
				addADR (2);
			}
			if (race == "DWARF") {
				AddAttackDamage (2);
				addMDR (2);
			}
			if (race == "HUMAN") {
				AddMagicDamage (1);
				addMDR (2);
			}
			if (race == "ELF") {
				AddRangeDamage (1);
				addRDR (2);
			}

			//set class bonuses
			if (classs == "WARRIOR") {
				heal (30);
				AddAttackDamage (2);
			}
			if (classs == "HUNTER")
				AddRangeDamage (4);
			if (classs == "MAGE") {
				AddRangeDamage (2);
				AddMagicDamage (2);
			}
			if (classs == "THIEF") {
				AddAttackDamage (2);
				AddRangeDamage (2);
			}
		}
	}
}

