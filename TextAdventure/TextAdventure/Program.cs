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
			showStats (player);


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
				Console.Clear();
				if (first_time){
					Console.WriteLine("Introtext blaablaa. Choose actions.");
					first_time = false;
				}else
					Console.WriteLine("Give me next command please.");
				string action = Console.ReadLine().ToUpper();
				if (action.Equals("STATS")) showStats(player);
				if (action.Equals("QUIT")) Environment.Exit(0);
				checkActions(action, player);
				Console.WriteLine("Press ENTER.");
				Console.ReadLine();

			}while(correct == 0);

		}

		//Check player input and choose correct actions
		public static bool checkActions(string input, Player player)
		{
			Regex directions = new Regex (@"\b(SOUTH|NORTH|EAST|WEST)\b");
			Regex actions = new Regex (@"\b(PICK|USE|ATTACK|FLEE|RUN)\b");
			Match m = directions.Match (input);
			Match m2 = actions.Match (input);
			List<string> dir_words = new List<string> ();
			List<string> act_words = new List<string> ();
			do 
			{
				Group g = m.Groups[0];
				dir_words.Add(g.ToString());
				m = m.NextMatch();
			} while(m.Success);

			do 
			{
				Group g = m2.Groups[0];
				act_words.Add(g.ToString());
				m2 = m2.NextMatch();
			} while(m2.Success);

			//Empty lists if "" added
			if(dir_words[0].Equals("")) dir_words.Clear();
			if (act_words [0].Equals ("")) act_words.Clear ();
			//Lets check if we understood anything
			if (dir_words.Count > 0) { // direction commands
				if (dir_words.Count > 1) {
					Console.Write ("Which is it? ");
					for (int i = 0; i < dir_words.Count - 1; i++) {
						Console.Write ("{0} ", dir_words[i]);
					}
					Console.Write ("or {0}?\n", dir_words[dir_words.Count - 1]);
				}else
					Console.WriteLine ("Ok. Lets go {0}!", dir_words [0]);
			}
			else if (act_words.Count > 0) {//Action commands
				Console.WriteLine ("Action command!");
			}
			else {
				Random r = new Random ();
				int answer = r.Next (1, 4);
				switch (answer)
				{
				case 1:
					Console.WriteLine("Umm... I didn't really understand.");
					break;
				case 2:
					Console.WriteLine("You want what?");
					break;
				case 3:
					Console.WriteLine ("I didn't quite get that one..");
					break;
				default:
					Console.WriteLine("Try again.");
					break;
				}
			
			}
			return true;
		}

		//show stats
		public static void showStats(Player player){
			Console.WriteLine (player.getPlayerInfo() + "\n");
			Console.WriteLine (player.getPlayerHealth() + "\n");
			Console.WriteLine (player.getPlayerCS() + "\n");
			player.getPlayerInventory (true);//method will write out inventory to screen
			Console.ReadLine ();
			Console.Clear ();
		}
	}
}
