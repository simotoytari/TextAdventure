using System;
using System.Collections.Generic;
using System.Text;

namespace TextAdventure
{
	public class Locations
	{
		private string name;
		private string desc;
		private int enemyCount;
		private int enemyLvl;
		private List<string> items = new List<string>();


		public Locations(string name,string desc, string enemyCount, string enemyLvl, string items)
		{
			this.name = name;
			this.desc = desc;
			this.enemyCount = Int32.Parse (enemyCount);
			this.enemyLvl = Int32.Parse (enemyLvl);
			itemParser (items);
		}

		//parse item string that contains multiple items or just one
		public void itemParser(string item)
		{
			StringBuilder givenItems = new StringBuilder ();
			for (int i = 0; i < item.Length; i++) {
				if (!item[i].Equals(','))
					givenItems.Append (item [i]);
				else {
					items.Add (givenItems.ToString());
					givenItems.Clear ();
				}
			}
		}

		public string getName()
		{
			return name;
		}

		public string getDesc()
		{
			return desc;
		}

		public int getEnemyCount(){
			return enemyCount;
		}

		public int getEnemyLvl(){
			return enemyLvl;
		}

		public List<string> getItemsInLoc(){
			return items;
		}
	}
}

