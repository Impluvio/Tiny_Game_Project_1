using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiny_Game_Project_1.Map;

namespace Tiny_Game_Project_1.Enemy
{
    internal class EnemyController
    {
        public static string[,] handleMovement(string[,] map) // this works for very simple maps, but loses out on larger more complex ones. 
        {
            var (playerX, playerY) = EntityFinder.Find(map, "u");
            var (enemyX, enemyY) = EntityFinder.Find(map, "z");

            int directionX = Math.Sign(playerX - enemyX);
            int directionY = Math.Sign(playerY - enemyY);

            if (tryMove(map, enemyX, enemyY, enemyX + directionX, enemyY))
            {
                return map;
            }
            else tryMove(map, enemyX, enemyY, enemyX, enemyY + directionY);
            {
                return map;
            }
        }

        private static bool tryMove(string[,] map, int currentEnemyX, int currentEnemyY, int targetX, int targetY)
        {
            if (targetX < 0 || targetX >= map.GetLength(1) ||
            targetY < 0 || targetY >= map.GetLength(0))
            {
                return false;
            }

            if (map[targetY, targetX] == "o" || map[targetY, targetX] == "u")
            {
                map[currentEnemyY, currentEnemyX] = "o";
                map[targetY, targetX] = "z";
                return true;
            }

            return false;

        }

    }
}
