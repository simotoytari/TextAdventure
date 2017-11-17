using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

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

			//strings
			string intro = File.ReadAllText("intro.txt");
			string guide = File.ReadAllText("guide.txt");

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
				if (intro != null) Console.WriteLine(intro);
				if (guide != null) Console.WriteLine(guide);
				intro = null;
				guide = null;
				rooms[nav.getTila()].getInfo();//get current rooms name and description
				Console.Write("Command: ");
				string action = Console.ReadLine().ToUpper();
				//TODO:if (action.Equals("INVENTORY")) showInventory(player);
				if (action.Equals("QUIT")) Environment.Exit(0);
				string ans = checkActions(action, nav);
				Console.Clear();
				Console.WriteLine(ans + "\n");

			}while(correct == 0);

		}

		//Check player input and choose correct actions
		public static string checkActions(string input, Navigation nav)
		{
			string ans = "";
			Regex directions = new Regex (@"\b(SOUTH|NORTH|EAST|WEST|UP|DOWN|((NORTH|SOUTH)EAST)|((NORTH|SOUTH)WEST))\b");
			Regex actions = new Regex (@"\b(PICK|USE)\b");
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
			if (dir_words.Count > 0 && act_words.Count <= 0) { // direction commands
				if (dir_words.Count > 1) {
					StringBuilder s = new StringBuilder ();
					s.Append ("Which is it? ");
					for (int i = 0; i < dir_words.Count - 1; i++) {
						s.Append(String.Format("{0} ", dir_words [i]));
					}
					s.Append(String.Format("or {0}?\n", dir_words [dir_words.Count - 1]));
					ans = s.ToString ();
				} else {
					//check if direction is ok
					if (!nav.checkDir (dir_words [0])) {
						ans = "Can't go that way.";
					}
				}
			}
			else if (act_words.Count > 0) {//Action commands
				ans = "Action command!";
			}
			else {
				Random r = new Random ();
				int answer = r.Next (1, 4);
				switch (answer)
				{
				case 1:
					ans = "Umm... I didn't really understand.";
					break;
				case 2:
					ans = "You want what?";
					break;
				case 3:
					ans = "I didn't quite get that one..";
					break;
				default:
					ans = "Try again.";
					break;
				}
			
			}

			return ans;
		}
			
	}
}
