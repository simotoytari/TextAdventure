using System;

namespace TextAdventure
{
	public class HumanoidBase
	{

		private string Name;
		private double Health;
		private int AttackDamage;
		private int RangeDamage;
		private int MagicDamage;
		private int AttackDamageResistance;
		private int RangeDamageResistance;
		private int MagicDamageResistance;

		public HumanoidBase ( string Name, double Health, int AD, int RD, int MD, int ADR, int RDR, int MDR)
		{
			this.Name = Name;
			this.AttackDamage = AD;
			this.Health = Health;
			this.RangeDamage = RD;
			this.MagicDamage = MD;
			this.AttackDamageResistance = ADR;
			this.RangeDamageResistance = RDR;
			this.MagicDamageResistance = MDR;
		}

		public void setHealth(double health){
			Health = health;
		}

		public void heal(double amount){
			Health = Health + amount;
		}

		public double getHealth(){
			return Health;
		}

		public string getName(){
			return Name;
		}

		public int getAttackDamage(){
			return AttackDamage;
		}

		public int getRangeDamage(){
			return RangeDamage;
		}

		public int getMagicDamage(){
			return MagicDamage;
		}

		public int getARD(){
			return AttackDamageResistance;
		}

		public int getRDR(){
			return RangeDamageResistance;
		}

		public int getMDR(){
			return MagicDamageResistance;
		}

		public void AddAttackDamage(int amount){
			AttackDamage = AttackDamage + amount;
		}

		public void AddRangeDamage(int amount){
			RangeDamage = RangeDamage + amount;
		}

		public void AddMagicDamage(int amount){
			MagicDamage = MagicDamage + amount;
		}

		public void addADR(int amount){
			AttackDamageResistance = AttackDamageResistance + amount;
		}

		public void addRDR(int amount){
			RangeDamageResistance = RangeDamageResistance + amount;
		}

		public void addMDR(int amount){
			MagicDamageResistance = MagicDamageResistance + amount;
		}

		//Calculates amount of damage taken based on enemy and player combat stats
		public void takeDamage(int ad, int rd, int md){

		}
	}
}

