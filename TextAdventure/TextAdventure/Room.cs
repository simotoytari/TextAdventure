using System;

namespace TextAdventure
{
	public class Room
	{
		private string _name;
		private string _description;

		public Room (string name, string description)
		{
			_name = name;
			_description = description;
		}

		public void getInfo(){
			Console.WriteLine(String.Format("Current room: {0}\n{1}",_name, _description));
		}
	}
}

