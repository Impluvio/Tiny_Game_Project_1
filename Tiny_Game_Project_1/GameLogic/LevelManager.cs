using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiny_Game_Project_1.Map;

namespace Tiny_Game_Project_1.GameLogic
{
    internal class LevelManager
    {

        
        public static string[,] LevelCreator(int levelNo)
        {
            

            int mapSize = levelNo;
            Console.Clear();
            MapMaker mapMaker = new MapMaker();
            string[,] initialMap = mapMaker.buildMap(mapSize, mapSize);
            string[,] penultimateMap = EnemyPlayerPlacement.placePlayerOnMap(initialMap); //master - remains unchanged
            string[,] finalMap = (string[,])penultimateMap.Clone();                       //Copy of master.

            return finalMap;
        }

        

    }
}
