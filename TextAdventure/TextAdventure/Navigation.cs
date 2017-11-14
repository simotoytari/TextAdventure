using System;
using System.Collections.Generic;

namespace TextAdventure
{
	public class Navigation
	{

		private int _tila;
		private static Dictionary<string, int> _conv = new Dictionary<string,int>();

		private static int[][] trans = new int[15][];
			
		private bool[] _accept = {true, false, false, false, false, false, false, false, false, false, false, false, false, false, false};


		public Navigation ()
		{
			_tila = 0;

			_conv.Add ("NORTH", 1);
			_conv.Add ("SOUTH", 2);
			_conv.Add ("EAST", 3);
			_conv.Add ("WEST", 4);
			_conv.Add ("UP", 5);
			_conv.Add ("DOWN",6);
			_conv.Add ("NORTHEAST",7);
			_conv.Add ("NORTHWEST",8);
			_conv.Add ("SOUTHEAST",9);
			_conv.Add ("SOUTHWEST", 10);
			/*
			_conv ["NORTH"] = 1;
			_conv ["SOUTH"] = 2;
			_conv ["EAST"] = 3;
			_conv ["WEST"] = 4;
			_conv ["UP"] = 5;
			_conv ["DOWN"] = 6;
			_conv ["NORTHEAST"] = 7;
			_conv ["NORTHWEST"] = 8;
			_conv ["SOUTHEAST"] = 9;
			_conv ["SOUTHWEST"] = 10;
*/
			trans [0] = new int[10];
			trans [1] = new int[10];
			trans [2] = new int[10];
			trans [3] = new int[10];
			trans [4] = new int[10];
			trans [5] = new int[10];
			trans [6] = new int[10];
			trans [7] = new int[10];
			trans [8] = new int[10];
			trans [9] = new int[10];
			trans [10] = new int[10];
			trans [11] = new int[10];
			trans [12] = new int[10];
			trans [13] = new int[10];
			trans [14] = new int[10];

			//Alakerran eteinen
			trans [0] [0] = 3;
			trans [0] [2] = 1;
			trans [0] [3] = 2;
			trans [0] [4] = 7;
			trans [0] [1] = 0;
			trans [0] [5] = 0; 
			trans [0] [6] = 0;
			trans [0] [7] = 0;
			trans [0] [8] = 0;
			trans [0] [9] = 0;
			//Alakerran olohuone
			trans [1] [4] = 0;
			trans [1] [0] = 1; 
			trans [1] [1] = 1;
			trans [1] [2] = 1;
			trans [1] [4] = 1;
			trans [1] [5] = 1;
			trans [1] [6] = 1;
			trans [1] [7] = 1;
			trans [1] [8] = 1;
			trans [1] [9] = 1;
			//Alakerran ruokailutila
			trans [2] [0] = 4;
			trans [2] [2] = 0;
			trans [2] [1] = 2;
			trans [2] [3] = 2;
			trans [2] [4] = 2;
			trans [2] [5] = 2;
			trans [2] [6] = 2;
			trans [2] [7] = 2;
			trans [2] [8] = 2;
			trans [2] [9] = 2;
			//Alakerran perhehuone
			trans [3] [1] = 0;
			trans [3] [3] = 4;
			trans [3] [0] = 3;
			trans [3] [2] = 3;
			trans [3] [4] = 3;
			trans [3] [5] = 3;
			trans [3] [6] = 3;
			trans [3] [7] = 3;
			trans [3] [8] = 3;
			trans [3] [9] = 3;
			//Alakerran keittiö
			trans [4] [2] = 3;
			trans [4] [1] = 2;
			trans [4] [3] = 5;
			trans [4] [0] = 4;
			trans [4] [4] = 4;
			trans [4] [5] = 4;
			trans [4] [6] = 4;
			trans [4] [7] = 4;
			trans [4] [8] = 4;
			trans [4] [9] = 4;
			//Alakerran käytävä
			trans [5] [2] = 4;
			trans [5] [0] = 6;
			trans [5] [1] = 5;
			trans [5] [3] = 5;
			trans [5] [4] = 5;
			trans [5] [5] = 5;
			trans [5] [6] = 5;
			trans [5] [7] = 5;
			trans [5] [8] = 5;
			trans [5] [9] = 5;
			//Alakerran kylpyhuone
			trans [6] [1] = 5;
			trans [6] [0] = 6;
			trans [6] [2] = 6;
			trans [6] [3] = 6;
			trans [6] [4] = 6;
			trans [6] [5] = 6;
			trans [6] [6] = 6;
			trans [6] [7] = 6;
			trans [6] [8] = 6;
			trans [6] [9] = 6;
			//Yläkerran aula
			trans [7] [5] = 0;
			trans [7] [0] = 8;
			trans [7] [1] = 7;
			trans [7] [2] = 7;
			trans [7] [3] = 7;
			trans [7] [4] = 7;
			trans [7] [6] = 7;
			trans [7] [7] = 7;
			trans [7] [8] = 7;
			trans [7] [9] = 7;
			//Yläkerran käytävä
			trans [8] [1] = 7;
			trans [8] [8] = 10;
			trans [8] [6] = 9;
			trans [8] [0] = 11;
			trans [8] [3] = 12;
			trans [8] [2] = 8;
			trans [8] [4] = 8;
			trans [8] [5] = 8;
			trans [8] [7] = 8;
			trans [8] [9] = 8;
			//Yläkerran makuuhuone 3
			trans [9] [9] = 8;
			trans [9] [0] = 9;
			trans [9] [1] = 9;
			trans [9] [2] = 9;
			trans [9] [3] = 9;
			trans [9] [4] = 9;
			trans [9] [5] = 9;
			trans [9] [6] = 9;
			trans [9] [7] = 9;
			trans [9] [8] = 9;
			//Yläkerran makuuhuone 2
			trans [10] [7] = 8;
			trans [10] [0] = 10;
			trans [10] [1] = 10;
			trans [10] [2] = 10;
			trans [10] [3] = 10;
			trans [10] [4] = 10;
			trans [10] [5] = 10;
			trans [10] [6] = 10;
			trans [10] [8] = 10;
			trans [10] [9] = 10;
			//Yläkerran vessa 1
			trans [11] [1] = 8;
			trans [11] [0] = 11;
			trans [11] [2] = 11;
			trans [11] [3] = 11;
			trans [11] [4] = 11;
			trans [11] [5] = 11;
			trans [11] [6] = 11;
			trans [11] [7] = 11;
			trans [11] [8] = 11;
			trans [11] [0] = 11;
			//Yläkerran makuuhuone 1
			trans [12] [2] = 8;
			trans [12] [0] = 13;
			trans [12] [1] = 12;
			trans [12] [3] = 12;
			trans [12] [4] = 12;
			trans [12] [5] = 12;
			trans [12] [6] = 12;
			trans [12] [7] = 12;
			trans [12] [8] = 12;
			trans [12] [9] = 12;
			//Yläkerran käytävä 2
			trans [13] [1] = 12;
			trans [13] [2] = 14;
			trans [13] [0] = 13;
			trans [13] [3] = 13;
			trans [13] [4] = 13;
			trans [13] [5] = 13;
			trans [13] [6] = 13;
			trans [13] [7] = 13;
			trans [13] [8] = 13;
			trans [13] [9] = 13;
			//Yläkerran vessa 2
			trans [14] [3] = 13;
			trans [14] [0] = 14;
			trans [14] [1] = 14;
			trans [14] [2] = 14;
			trans [14] [4] = 14;
			trans [14] [5] = 14;
			trans [14] [6] = 14;
			trans [14] [7] = 14;
			trans [14] [8] = 14;
			trans [14] [9] = 14;

		}

		//Hoidetaan siirtymä
		public bool checkDir(string s) {
			int tila = _tila;
			int c_ = _conv[s] - 1;
			_tila = trans[_tila][c_];
			if (tila == _tila)
				return false;
			else
				return true;
		}
		//palautetaan nykyinen tila
		public int getTila(){
			return _tila;
		}
		//ollaanko hyväksyvässä tilassa (vain jos ollaan alakerran eteisessä missä voi päättää pelin)
		public bool isAccepted(){
			return _accept[_tila];
		}

	}
}

