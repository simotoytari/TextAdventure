using System;

namespace TextAdventure
{
	public class Enemies
	{
		
		private string name;
		private string desc;
		private int health;
		private int AttackDamage;
		private int AttackDamageResistance;
		private int RangeDamageResistance;
		private int MagicDamageResistance;

		public Enemies (string name, string desc, int enemyLvl)
		{
			this.name = name;
			this.desc = desc;

			Random rnd = new Random();

			if (enemyLvl == 1) {
				this.health = rnd.Next(20, 30);
				AttackDamage = rnd.Next(1, 2);
				AttackDamageResistance = rnd.Next(0, 1);
				RangeDamageResistance = rnd.Next(0,1);
				MagicDamageResistance = rnd.Next(0,1);
			}
			if (enemyLvl == 2) {
				this.health = rnd.Next(30, 60);
				AttackDamage = rnd.Next(2,3);
				AttackDamageResistance = rnd.Next(1,2);
				RangeDamageResistance = rnd.Next(1,2);
				MagicDamageResistance = rnd.Next(1,2);
			}
			if (enemyLvl == 3) {
				this.health = rnd.Next(60,100);
				AttackDamage = rnd.Next(2,4);
				AttackDamageResistance = rnd.Next(2,4);
				RangeDamageResistance = rnd.Next(2,4);
				MagicDamageResistance = rnd.Next(2,4);
			}
		}

		public string enemyDesc(){
			string output = String.Format ("Enemys is a {0}. {1}. It has {2} health.",name, desc, health);
			return output;
		}

		//TODO: take to concideration players combat stats and enemys resistances to calculate taken damage
		public void setEnemyHealth(int damage){
			health = health - damage;
			Console.WriteLine ("Enemy took {0}! It has {1} health left.", damage, health);
		}

		public int enemyDamage(){
			return AttackDamage;
		}
	}
}

