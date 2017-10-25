using System;
using System.Collections.Generic;
using System.IO;

namespace TextAdventure
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			//Ints
			int correct = 0;

			//Strings
			string Gender;
			string Race;
			string Class;

			//Lists
			List<Locations> locations = new List<Locations>();

			//Booleans
			bool first_time = true;

			//Character creation
			do {
				Console.Clear();
				Console.WriteLine("Please choose a gender as below:");
				Console.WriteLine("Male/ Female");
				Gender = Console.ReadLine().ToUpper();
				if (Gender == "MALE") correct = 1;
				if (Gender == "FEMALE") correct = 1;

			} while (correct == 0);
			correct = 0;

			//Race creaation
			do {
				Console.Clear();
				Console.WriteLine("Please choose race as below:");
				Console.WriteLine("Human");
				Console.WriteLine("Dwarf");
				Console.WriteLine("Elf");
				Console.WriteLine("Orc");
				Race = Console.ReadLine().ToUpper();
				if(Race == "HUMAN" || Race == "DWARF" || Race == "ELF" || Race == "ORC") correct = 1;
			} while(correct == 0);
			correct = 0;

			//Class creation
			do {
				Console.Clear();
				Console.WriteLine("Please choose class as below:");
				Console.WriteLine("Warrior");
				Console.WriteLine("Hunter");
				Console.WriteLine("Mage");
				Console.WriteLine("Thief");
				Class = Console.ReadLine().ToUpper();
				if (Class == "WARRIOR" || Class == "HUNTER" || Class == "MAGE" || Class == "THIEF") correct = 1;
			} while (correct == 0);
			correct = 0;

			//Load locations
			string[] lines = File.ReadAllLines("loc.txt");

			string loc_name = "";
			string loc_desc = "";
			for(int i = 0; i < lines.Length; i++)
			{
				if (i % 2 == 0)
					loc_name = lines[i];
				else
				{
					loc_desc = lines[i];
					Locations loc = new Locations (loc_name, loc_desc);
					locations.Add(loc);
				}
			}



			//Make player
			Player player = new Player (Gender, Race, Class);
			Console.Clear ();
			Console.WriteLine (player.getPlayerInfo() + "\n");
			Console.WriteLine (player.getPlayerHealth() + "\n");
			Console.WriteLine (player.getPlayerCS() + "\n");
			player.getPlayerInventory ();//method will write out inventory to screen
			Console.ReadLine ();
			Console.Clear ();

			//TESTS
			//player.setPlayerHealth(10);
			//player.setPlayerInventory ("Gold nugget");
			/*for(int i = 0; i < locations.Count; i++){
				Console.WriteLine (locations[i].getName());
				Console.WriteLine(locations[i].getDesc());
				Console.ReadLine ();
				Console.Clear ();
			}
			*/


			//Game loop
			do{
				if (first_time){
					Console.WriteLine("Introtext blaablaa. Choose actions.");
					first_time = false;
				}
				/*
				 * Check actions (like take, pick up, direction, eat)
				 * if actions are valid do something
				 * action = direction, check location, give loc desc
				 * action = pick up/ take / eat, go to player inventory
				 * /

			}while(correct == 0);

		}
	}
}
