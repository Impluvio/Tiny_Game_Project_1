using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;

namespace Tiny_Game_Project_1.Map
{
    public class MapMaker
    {
        public int currentCoordX = 0;
        public int currentCoordY = 0;

        public string[,] buildMap(int mapHeight, int mapWidth) // map height and width should be the same as one another
        {
            string[,] gameArea = new string[mapHeight, mapWidth];
            
            for (int y = 0; y < mapHeight; y++)
            {
                for (int x = 0; x < mapWidth; x++)
                {
                    gameArea[x, y] = "o";
                }

            }

            for (int i = 0; i < mapHeight; i++) //adds perimeter, overwrites same coords but negligable. 
            {
                gameArea[i, 0] = "X";
                gameArea[0, i] = "X";
                gameArea[mapWidth - 1, i] = "X";
                gameArea[i, mapHeight - 1] = "X";
            }


            string[,] intermediaryGameMap = runRandomWalkers(gameArea, mapWidth, mapHeight);
            string[,] finishedGameMap = runRandomWalkers(intermediaryGameMap, mapWidth, mapHeight); 

            //foreach ( string s in  gameArea) // to crudely test if it displays correctly.
            //{
            //    Console.WriteLine(s);
            //}
            
            return finishedGameMap;

        }



        public string[,] runRandomWalkers(string[,] gameAreaToProcess, int mapWidth, int mapHeight)
        {
            int largeWalkerLength = mapWidth; // number of steps in a big walker
            int smallWalkerLength = mapHeight / 7; // number of steps in a small walker

            int smallWalkers = mapHeight - mapWidth / 2;
            int largeWalkers = mapWidth / 20;



            for (int i = smallWalkers; i > 0; i--)
            {
                Random randomCoord = new Random(); //using random 
                int randomCoordX = randomCoord.Next(2, mapWidth - 3); // ensures buffer of 3 from left and right of the grid & assigns coord.
                int randomCoordY = randomCoord.Next(2, mapHeight - 3); // ensures buffer of 3 from top and bottom of the grid & assigns coord.
                currentCoordX = randomCoordX; //start of walker
                currentCoordY = randomCoordY; //start of walker

                for (int j = 0; j < smallWalkerLength; j++)
                {
                    
                    gameAreaToProcess[currentCoordX, currentCoordY] = "^";
                    getCoordNeighbour(gameAreaToProcess, currentCoordX, currentCoordY);

                }

            }


            return gameAreaToProcess; // fix this later
        }

         public void getCoordNeighbour(string[,] gameAreaToProcess, int coordX, int coordY)
        {
            //this needs to take the present random coord and check n,s,e,w
            int mapHeight = gameAreaToProcess.GetLength(0);  //y - GetLength(0) returns height data.
            int mapWidth = gameAreaToProcess.GetLength(1);   //x - Get Length(1) returns width data. 

            List<int> availableDirections = new List<int>();  //this will be populated with 1 - north, 2 - east, 3 - south, 4 - west;


            if (coordY + 1 < mapHeight - 3)
            {
                availableDirections.Add(1); // North
            }
            if (coordX + 1 < mapWidth - 3)
            {
                availableDirections.Add(2); //East
            }
            if (coordY - 1 > 2)
            {
                availableDirections.Add(3); // South
            }
            
            if (coordX - 1 > 2)
            {
                availableDirections.Add(4); //West
            }

            Random randomDirection = new Random();

            int randomDirectionIndex = randomDirection.Next(0, availableDirections.Count);
            int resultantDirection = availableDirections[randomDirectionIndex]; //suggests 1 - north, 2 - east, 3 - south, 4 - west; 

            if (resultantDirection == 1)
            {
                currentCoordY = coordY + 1;

            }
            if (resultantDirection == 2)
            {
                currentCoordX = coordX + 1;

            }
            if (resultantDirection == 3)
            {
                currentCoordY = coordY - 1;
            }
            if (resultantDirection == 4)
            {
                currentCoordX = coordX - 1;
            }

            return;   

        }
    }
}
