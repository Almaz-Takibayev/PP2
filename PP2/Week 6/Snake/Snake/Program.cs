using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            GameState game = new GameState();
            while (true)
            {
                game.Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                game.ProcessKeyEvent(consoleKeyInfo);
            }
        }
    }
}
