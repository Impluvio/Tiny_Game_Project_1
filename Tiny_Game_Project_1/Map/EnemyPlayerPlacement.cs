using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tiny_Game_Project_1.Map
{
    public class EnemyPlayerPlacement
    {
        public static string[,] placePlayerOnMap(string[,] mapToProcess)
        {
            int mapHeight = mapToProcess.GetLength(0);
            int mapWidth = mapToProcess.GetLength(1);

            int backrow = mapHeight - 2; // obstacles cannot be planted here.
            int frontRow = 1;

            Random randRange = new Random();
            int randomCoordX = randRange.Next(2, mapWidth - 3);
            int secondRandomCoordX = randRange.Next(2, mapWidth - 3);

            mapToProcess[randomCoordX, backrow] = "u";
            mapToProcess[randomCoordX, frontRow] = "z";
            

            return mapToProcess;

        }

    }
}
