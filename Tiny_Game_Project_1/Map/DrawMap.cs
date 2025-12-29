using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiny_Game_Project_1.Map
{
    public class DrawMap
    {

        public static void Draw(string[,] gameMap)
        {
            Console.Clear();

            int mapY = gameMap.GetLength(0); 
            int mapX = gameMap.GetLength(1); 

            
                for(int x = 0; x < mapX; x++)
                {
                for (int y = 0; y < mapY; y++)
                {
                    switch (gameMap[y, x])
                    {
                        case "o":
                            Console.ForegroundColor = ConsoleColor.DarkGreen; break;
                        case "X":
                            Console.ForegroundColor = ConsoleColor.DarkGray; break;
                        case "^":
                            Console.ForegroundColor = ConsoleColor.DarkBlue; break;
                        case "u": 
                            Console.ForegroundColor = ConsoleColor.Yellow; break;
                        case "z":
                            Console.ForegroundColor = ConsoleColor.Red; break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White; break;
                    }
                    Console.Write(gameMap[y, x]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
                
            



        }


    }
}
