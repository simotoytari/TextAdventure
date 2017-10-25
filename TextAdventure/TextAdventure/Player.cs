using System;
using System.Text;
using System.Collections.Generic;

namespace TextAdventure
{
	public class Player
	{
		private string Gender;
		private string Race;
		private string Class;
		private int Health;
		private int AttackDamage;
		private int RangeDamage;
		private int MagicDamage;
		private List<string> inventory = new List<string>();

		public Player (string Gender, string Race, string Class)
		{
			this.Gender = Gender;
			this.Race = Race;
			this.Class = Class;
			this.Health = 100;
			this.AttackDamage = 1;
			this.RangeDamage = 1;
			this.MagicDamage = 1;
			inventory.Add ("Rusty blade");
			inventory.Add ("Moldy bread");
			setPlayerDamage (Race, Class);
		}

		//returns players general info
		public string getPlayerInfo()
		{
			string output = String.Format("Your gender is {0}, race {1} and class {2}.",Gender, Race, Class);
			return output;
		}

		//returns players health
		public string getPlayerHealth()
		{
			string output = String.Format ("You have {0} health.", Health);
			return output;
		}

		//set players health
		public void setPlayerHealth(int damage)
		{
			Health = Health - damage;
			Console.WriteLine ("You took {0} damage! Your health is {1}.", damage, Health);
		}

		//returns players inventory and writes it on screen
		public List<string> getPlayerInventory()
		{
			Console.WriteLine ("Your inventory:");
			for(int i = 0; i < inventory.Count;i++){
				Console.WriteLine (inventory[i]);
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
				"Ranged damage {1}\nMagic damage {2}", AttackDamage, RangeDamage, MagicDamage);
			return output;
		}

		//Set attack, range and magic damage depending on player race and class
		private void setPlayerDamage(string race, string classs)
		{
			//set race bonuses
			if (race == "ORC") 
				Health = Health + 20;
			if (race == "DWARF")
				AttackDamage = AttackDamage + 1;
			if (race == "HUMAN")
				MagicDamage = MagicDamage + 1;
			if (race == "ELF")
				RangeDamage = RangeDamage + 1;

			//set class bonuses
			if (classs == "WARRIOR") {
				Health = Health + 30;
				AttackDamage = AttackDamage + 2;
			}
			if (classs == "HUNTER") 
				RangeDamage = RangeDamage + 4;
			if (classs == "MAGE") {
				RangeDamage = RangeDamage + 2;
				MagicDamage = MagicDamage + 2;
			}
			if (classs == "THIEF") {
				AttackDamage = AttackDamage + 2;
				RangeDamage = RangeDamage + 2;
			}
		}
	}
}

