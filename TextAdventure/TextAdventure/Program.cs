using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

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
			string Name;

			//Lists
			List<Locations> locations = new List<Locations>();

			//Booleans
			bool first_time = true;

			//Player name
			do {
				//Console.Clear();
				Console.WriteLine("Please give characters name:");
				Name = Console.ReadLine().ToUpper();
				Regex regex = new Regex("^[A-Z]+$");
				Match match = regex.Match(Name);
				if (match.Success) correct = 1;
				else 
					Console.WriteLine("Give a name that containts only letters between a-z.");
			} while (correct == 0);
			correct = 0;

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

			List<string> loc_details = new List<string> ();

			for(int i = 0; i < lines.Length; i++)
			{
				if (lines [i] == "//")
					break;
				if (lines [i] != "-") {
					loc_details.Add (lines [i]);
				} else {
					Locations loc = new Locations (loc_details[0], loc_details[1], loc_details[2], loc_details[3], loc_details[4]);
					locations.Add (loc);
					loc_details.Clear ();
				}
			}



			//Make player
			Player player = new Player (Gender, Race, Class, Name);
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
			/*
			for(int i = 0; i < locations.Count; i++){
				Console.WriteLine (locations[i].getName());
				Console.WriteLine(locations[i].getDesc());
				Console.WriteLine (locations [i].getEnemyCount ());
				Console.WriteLine (locations[i].getEnemyLvl());
				List<string> itemss = locations [i].getItemsInLoc ();
				for(int j = 0; j < itemss.Count; j++){
					Console.WriteLine (itemss[j].ToString());
				}
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
				 */
				correct = 1;// prevents infinite loop

			}while(correct == 0);

		}

		//Check player input and choose correct actions
		public static bool checkActions(string input)
		{
			return true;
		}
	}
}
