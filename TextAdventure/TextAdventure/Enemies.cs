using System;

namespace TextAdventure
{
	public class Enemies : HumanoidBase
	{
		private string desc;

		public Enemies (string desc, int enemyLvl, string name)
			:base(name, 1, 1, 1, 1, 1, 1, 1)
		{
			this.desc = desc;

			Random rnd = new Random();

			if (enemyLvl == 1) {
				setHealth(rnd.Next(20, 30));
				AddAttackDamage(rnd.Next(1, 2));
				AddRangeDamage (rnd.Next(0,1));
				AddMagicDamage (rnd.Next(0,1));
				addADR(rnd.Next(0,1));
				addRDR(rnd.Next(0,1));
				addMDR(rnd.Next(0,1));
			}
			if (enemyLvl == 2) {
				setHealth(rnd.Next(30, 60));
				AddAttackDamage(rnd.Next(2, 3));
				AddRangeDamage (rnd.Next(1,2));
				AddMagicDamage (rnd.Next(1,2));
				addADR(rnd.Next(1,2));
				addRDR(rnd.Next(1,2));
				addMDR(rnd.Next(1,2));
			}
			if (enemyLvl == 3) {
				setHealth(rnd.Next(60, 100));
				AddAttackDamage(rnd.Next(2, 4));
				AddRangeDamage (rnd.Next(2,3));
				AddMagicDamage (rnd.Next(2,3));
				addADR(rnd.Next(2,4));
				addRDR(rnd.Next(2,4));
				addMDR(rnd.Next(2,4));
			}
		}


		public string enemyDesc(){
			string output = String.Format ("Enemys is a {0}. {1}. It has {2} health.",getName(), desc, getHealth());
			return output;
		}
			
	}
}

