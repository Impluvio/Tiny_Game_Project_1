using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tiny_Game_Project_1.Map;

namespace Tiny_Game_Project_1.Player
{
    public class PlayerHealth
    {
       public static string playerHealth = "<3<3<3";
       static string label = "Lives: ";

        public static string reportPlayerHealth(bool hit)
        {
            
            if (hit)
            {
                playerHealth = playerHealth.Substring(0, playerHealth.Length - 1);
                return label + playerHealth;
                
            }

            return label + playerHealth;
        }



    }
}
