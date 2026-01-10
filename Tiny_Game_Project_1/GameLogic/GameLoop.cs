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
        static int counter = 0;
        public static bool running { get; set; } = true; 

        public static void ToggleRunning()
        {
            running = !running;
        }

        public static void initiateLoop(string[,] mapToDraw)
        {
            counter++;
            DrawMap.Draw(mapToDraw);

            while (running)
            {

                string[,] updatedMapPlayer = PlayerInput.handleInput(mapToDraw);
                string[,] updatedMapPlayerEnemy = EnemyController.handleMovement(updatedMapPlayer);

                DrawMap.Draw(updatedMapPlayerEnemy);
                var player = EntityFinder.Find(updatedMapPlayerEnemy, "u");
                Console.WriteLine("player location: " + player);
                var enemy = EntityFinder.Find(updatedMapPlayerEnemy, "z");
                Console.WriteLine("enemy location: " + enemy);

                if (player == enemy) 
                {
                    Console.Beep(250, 400);
                    running = false;
                    PlayerHealth.reportPlayerHealth(true);
                }
                else if (enemy == (-1, -1) || player == (-1, -1))
                {
                    Console.Beep(250, 400);
                    running = false;
                    PlayerHealth.reportPlayerHealth(true);
                }



            }
        }

    }
}
