// See https://aka.ms/new-console-template for more information
using Tiny_Game_Project_1;
using Tiny_Game_Project_1.Enemy;
using Tiny_Game_Project_1.Extras;
using Tiny_Game_Project_1.Map;
using Tiny_Game_Project_1.Player;
using Tiny_Game_Project_1.GameLogic;
using System.Data.SqlTypes;
using Microsoft.VisualBasic;


class program
{
    static void Main()
    {
        DisplayTitle.showTitle();
        Thread.Sleep(5000);

        GameLoop.RunGame();

    }

    
}

