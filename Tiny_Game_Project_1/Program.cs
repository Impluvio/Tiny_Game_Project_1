// See https://aka.ms/new-console-template for more information
using Tiny_Game_Project_1.Map;
using Tiny_Game_Project_1.Player;


class program
{
    static void Main()
    {
        int mapSize = 50;
        Console.Clear();
        MapMaker mapMaker = new MapMaker();
        string[,] createdMap = mapMaker.buildMap(mapSize, mapSize);
        string[,] readyMap = PlayerPlacement.placePlayerOnMap(createdMap);
        
        bool running = true;
        DrawMap.Draw(readyMap);

        while (running)
        {
            string[,] updatedMap = PlayerInput.handleInput(readyMap);


            DrawMap.Draw(updatedMap);
        }

    }

}
//To Do:
//create logic for player
//create logic and simple ai for enemy - the 'z'
//player to spawn in top start zone
//create start and end zones - slight randomisation of this create 4x4 area in white? 
//stretch:- 
// - add music
// - add lives
// - would you like to try again Y/N. 









//place player in map - ensure this isn't on something that is blocked 

//start zone & spawn player 

//start zone & spawn baddy



