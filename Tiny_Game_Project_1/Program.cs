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
        string[,] initialMap = mapMaker.buildMap(mapSize, mapSize);
        string[,] finalisedMap = EnemyPlayerPlacement.placePlayerOnMap(initialMap); //master - remains unchanged

        string[,] readyMap = (string[,])finalisedMap.Clone();                       //Copy of master. 
        bool keepPlaying = true;
        int loopCounter = 0;


        while (keepPlaying)
        {

            GameLoop.initiateLoop(readyMap);


            if (PlayerHealth.playerHealth.Length > 0)
            {
                Console.Clear();
                Console.WriteLine("you Got rekt!");
                Console.WriteLine("You have lives left... continue (y/n)?");
                string input = Console.ReadLine();

                if (input != null && input == "y")                                      // Crude Collision detection
                {
                    Console.Clear();
                    GameLoop.ToggleRunning();
                    readyMap = (string[,])finalisedMap.Clone();
                    GameLoop.initiateLoop(readyMap);
                }
                else if (input != null && input == "n")
                {
                    Console.Clear();
                    Console.WriteLine("game over");
                    keepPlaying = false;
                }
            }
            else
            {
                Console.WriteLine("game over");
                keepPlaying = false;
            }
            Console.ReadKey();

        }
    }


}

