using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiny_Game_Project_1.Map;

namespace Tiny_Game_Project_1.Player
{
    public class PlayerInput
    {
        public static string[,] handleInput(string[,] mapToUpdate)
        {
            

            var key = Console.ReadKey(true).Key;


            var (currentX, currentY) = EntityFinder.Find(mapToUpdate, "u");

            int newX = currentX;
            int newY = currentY;

            if (key == ConsoleKey.W || key == ConsoleKey.A || key == ConsoleKey.S || key == ConsoleKey.D) 
            {
                switch (key)
                {
                    case ConsoleKey.W: newX--; break;   //these are in the wrong order so up/down is A and D and left right is W and S
                    case ConsoleKey.S: newX++; break;
                    case ConsoleKey.A: newY--; break;
                    case ConsoleKey.D: newY++; break;
                    default: break;                     //do nothing
                }

                if (newY >= 1 && newY < mapToUpdate.GetLength(0) - 1 && newX >= 1 && newX < mapToUpdate.GetLength(1) - 1) //bounds check.
                {
                    if (mapToUpdate[newY, newX] != "X" && mapToUpdate[newY, newX] != "^")
                    {
                        mapToUpdate[newY, newX] = "u";
                        mapToUpdate[currentY, currentX] = "o";
                    }

                }
            }
            else
            {
                
            }

                return mapToUpdate;
        }



    }
}
