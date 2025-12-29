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

            switch (key)
            {
                case ConsoleKey.W: newY++; break;   //these are in the wrong order so up/down is A and D and left right is W and S
                case ConsoleKey.S: newY--; break;
                case ConsoleKey.A: newX--; break;
                case ConsoleKey.D: newX++; break;
            }

            if (mapToUpdate[newY, newX] != "X" || mapToUpdate[newY, newX] != "^" //this does not work if we go out of bounds, and it does not put the cursor back.
            {
                mapToUpdate[newY, newX] = "u";
                mapToUpdate[currentY, currentX] = "o";
            }

            return mapToUpdate;
        }



    }
}
