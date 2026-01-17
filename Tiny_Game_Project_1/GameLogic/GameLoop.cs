using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Tiny_Game_Project_1.Enemy;
using Tiny_Game_Project_1.Map;
using Tiny_Game_Project_1.Player;

namespace Tiny_Game_Project_1.GameLogic
{
    internal class GameLoop
    {
        
        public static bool runningCentralLoop { get; set; } = true;
        public static bool playProgression = false;
        public static int sizeOfMap = 20;


        public static void RunGame()
        {
            string[,] finalisedMap = LevelManager.LevelCreator(sizeOfMap);
            var readyMap = (string[,])finalisedMap.Clone();
            bool keepPlaying = true;

            while (keepPlaying) //outter loop - if stopped Game Over
            {
                    mainLoop(ref sizeOfMap, ref finalisedMap, ref readyMap, ref keepPlaying);
            }

        }



        public static void mainLoop(ref int mapSize, ref string[,] finalisedMap, ref string[,] readyMap, ref bool keepPlaying)
        {
            int currentlevel = mapSize;

            centralLoop(readyMap);

            if (playProgression)
            {
                Console.Clear();
                Console.WriteLine("in play progression if statement");
                mapSize = mapSize + 5;
                finalisedMap = LevelManager.LevelCreator(mapSize);
                readyMap = (string[,])finalisedMap.Clone();
                centralLoop(readyMap);
                playProgression = false;
            }


            if (PlayerHealth.playerHealth.Length > 0)
            {
                Console.Clear();
                Console.WriteLine("you Got rekt!");
                Console.WriteLine("You have lives left... continue (y/n)?");
                string input = Console.ReadLine();

                if (input != null && input == "y")                                      // Crude Collision detection
                {
                    Console.Clear();
                    ToggleRunning();
                    readyMap = (string[,])finalisedMap.Clone();
                    centralLoop(readyMap);
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

        public static void ToggleRunning()
        {
            runningCentralLoop = !runningCentralLoop;
        }

        public static void centralLoop(string[,] mapToDraw) //this assesses and updates the core gameplay including movement, the map & win / loss conditions
        {

            DrawMap.Draw(mapToDraw);
            var finish = EntityFinder.Find(mapToDraw, "S");

            while (runningCentralLoop)
            {
                //what we need to do here is fix the handle input so that it checks to see if an entity is on the position we want to move to.
                // if it is empty "o" then we move to that position.
                // if it is not empty then we check the cases below.


                string[,] updatedMapPlayer = PlayerInput.handleInput(mapToDraw); // player could move over a entity. this would change that entities location.
                
                string[,] updatedMapPlayerEnemy = EnemyController.handleMovement(updatedMapPlayer); // enemy could move over an entity. this would change that entities location.

                DrawMap.Draw(updatedMapPlayerEnemy);
                var player = EntityFinder.Find(updatedMapPlayerEnemy, "u");
                Console.WriteLine("player location: " + player);
                var enemy = EntityFinder.Find(updatedMapPlayerEnemy, "z");
                Console.WriteLine("enemy location: " + enemy);
                

                if (player == enemy)
                {
                    Console.Beep(250, 400);
                    runningCentralLoop = false;
                    PlayerHealth.reportPlayerHealth(true);
                }
                else if (player == finish)
                {
                    Console.Beep(200, 400);
                    playProgression = true;
                    runningCentralLoop = false;
                    PlayerHealth.reportPlayerHealth(true);

                }
                else if (enemy == (-1, -1) || player == (-1, -1))
                {
                    Console.Beep(300, 400);
                    runningCentralLoop = false;
                    PlayerHealth.reportPlayerHealth(true);
                }
            }
        }


        

    }
}
