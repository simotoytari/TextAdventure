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

			//Lists
			List<Room> rooms = new List<Room>();

			//Booleans
			bool first_time = true;

			//ints
			int correct = 0;

			//Load locations
			string[] lines = File.ReadAllLines("rooms.txt");
			List<string> room_d = new List<string> ();

			for (int i = 0; i < lines.Length; i++) {
				if (i % 2 == 0)
					room_d.Add (lines [i]);
				else {
					room_d.Add (lines [i]);
					Room r = new Room (room_d [0], room_d [1]);
					rooms.Add (r);
					room_d.Clear ();
				}

			}

			//new game
			Navigation nav = new Navigation();

			//Game loop
			do{
				if (first_time){
					Console.WriteLine("Welcome to House Escape!\n");
                    string intro = File.ReadAllText("intro.txt");
                    Console.WriteLine(intro + "\n");
                    Console.WriteLine("\n");
                    string guide = File.ReadAllText("guide.txt");
                    Console.WriteLine(guide + "\n");
					first_time = false;
				}
				rooms[nav.getTila()].getInfo();//get current rooms name and description
				string action = Console.ReadLine().ToUpper();
				//TODO:if (action.Equals("INVENTORY")) showInventory(player);
				if (action.Equals("QUIT")) Environment.Exit(0);
				checkActions(action, nav);
				Console.WriteLine("\nPress ENTER.");
				Console.ReadLine();
				Console.Clear();
			}while(correct == 0);

		}

		//Check player input and choose correct actions
		public static void checkActions(string input, Navigation nav)
		{
			Regex directions = new Regex (@"\b(SOUTH|NORTH|EAST|WEST|UP|DOWN|((NORTH|SOUTH)EAST)|((NORTH|SOUTH)WEST))\b");
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
						Console.Write ("{0} ", dir_words [i]);
					}
					Console.Write ("or {0}?\n", dir_words [dir_words.Count - 1]);
				} else {
					//check if direction is ok
					if (!nav.checkDir (dir_words [0])) {
						Console.WriteLine ("Can't go that way.");
					}
				}
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
		}
			
	}
}
