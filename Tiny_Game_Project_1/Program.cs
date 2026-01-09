// See https://aka.ms/new-console-template for more information
using Tiny_Game_Project_1;
using Tiny_Game_Project_1.Enemy;
using Tiny_Game_Project_1.Extras;
using Tiny_Game_Project_1.Map;
using Tiny_Game_Project_1.Player;
using Tiny_Game_Project_1.GameLogic;


class program
{
    static void Main()
    {
        DisplayTitle.showTitle();
        Thread.Sleep(5000);

        int mapSize = 20;
        Console.Clear();
        MapMaker mapMaker = new MapMaker();
        string[,] createdMap = mapMaker.buildMap(mapSize, mapSize);
        string[,] readyMap = EnemyPlayerPlacement.placePlayerOnMap(createdMap);

        GameLoop.initiateLoop(readyMap);

        //  Console.Clear();
        Console.WriteLine("you Got rekt!");

        if (PlayerHealth.playerHealth.Length > 0)
        {
            Console.WriteLine("You have lives left... continue (y/n)?");
            string input = Console.ReadLine();
            
            if (input != null && input == "y") // so at this point when the two players collide the game loop 
            {
                
                GameLoop.ToggleRunning();
                var player = EntityFinder.Find(readyMap, "u");
                var enemy = EntityFinder.Find(readyMap, "z");
                Console.WriteLine($"player is:{player} & enemy is:{enemy}");
                if (player == (-1, -1) && enemy != (-1,-1))
                {
                    readyMap[enemy.x, enemy.y] = "o"; 
                }
                if (enemy == (-1, -1) && player != (-1, -1))
                {
                    readyMap[player.x, player.y] = "o"; 
                }


                var mapReset = EnemyPlayerPlacement.placePlayerOnMap(readyMap);
                GameLoop.initiateLoop(mapReset);
            }
            else if (input != null && input == "n")
            {
                Console.WriteLine("game over");
            }
        }
        else
        {
            Console.WriteLine("game over");
        }
            Console.ReadKey();


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



