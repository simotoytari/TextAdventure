using System;

namespace TextAdventure
{
	public class Locations
	{
		private string name;
		private string desc;


		public Locations(string name,string desc)
		{
			this.name = name;
			this.desc = desc;
		}

		public string getName()
		{
			return name;
		}

		public string getDesc()
		{
			return desc;
		}
	}
}

