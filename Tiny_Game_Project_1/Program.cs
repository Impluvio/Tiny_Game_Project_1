// See https://aka.ms/new-console-template for more information
using Tiny_Game_Project_1.Map;

Console.WriteLine("Hello, World!");



// params for the mapMaker should always be equal. 

int mapSize = 50;

MapMaker mapMaker = new MapMaker();

string[,] mapOne = mapMaker.buildMap(mapSize, mapSize);

DrawMap.Draw(mapOne);

