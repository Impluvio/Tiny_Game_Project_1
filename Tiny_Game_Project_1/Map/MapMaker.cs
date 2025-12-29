using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tiny_Game_Project_1.Map
{
    public class MapMaker
    {

        public static string[,] buildMap(int mapHeight, int mapWidth) // map height and width should be the same as one another
        {
            string[,] gameArea = new string[mapHeight, mapWidth];


            //put in perimeter 
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    gameArea[x, y] = "o";
                }

            }

            for (int i= 0; i<mapHeight; i++) //adds perimeter
            {

                gameArea[i, 0] = "X";
                gameArea[0, i] = "X";
                gameArea[mapWidth - 1, i] = "X";
                gameArea[i, mapHeight - 1] = "X";
            }

            foreach ( string s in  gameArea) // to crudely test if it displays correctly.
            {
                Console.WriteLine(s);
            }

           return gameArea; 

        }








    }
}
