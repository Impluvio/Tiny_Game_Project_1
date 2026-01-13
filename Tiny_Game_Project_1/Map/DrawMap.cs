using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiny_Game_Project_1.Player;

namespace Tiny_Game_Project_1.Map
{
    public class DrawMap
    {
        public static string Message = "";
        public static void Draw(string[,] gameMap)
        {
            Console.SetCursorPosition(0, 0);

            int mapY = gameMap.GetLength(0); 
            int mapX = gameMap.GetLength(1);

            string healthBar = PlayerHealth.reportPlayerHealth(false);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(healthBar);
            Console.ResetColor();

            for (int x = 0; x < mapX; x++)
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
                        case "z" or "<" or "3":
                            Console.ForegroundColor = ConsoleColor.Red; break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White; break;
                    }
                    Console.Write(gameMap[y, x]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }

            
            Console.WriteLine($"Debug Output: {Message}");



        }


    }
}
