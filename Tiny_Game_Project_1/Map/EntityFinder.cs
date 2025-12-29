using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiny_Game_Project_1.Map
{
    internal class EntityFinder
    {
        public static (int x, int y) Find(string[,] map, string symbol)
        {
            
            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    if (map[y, x] == symbol)
                        return (x, y);
                }
            }

            return (-1, -1);

        }


    }
}
