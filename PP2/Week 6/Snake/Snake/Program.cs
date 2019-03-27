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
            Player player = new Player();
            while (true)
            {
                game.Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
                {
                    Serialize(player);
                }
                else
                {
                    game.ProcessKeyEvent(consoleKeyInfo);
                }
            }
        }

        static void Serialize(Player player)
        {
            XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(Player));
            string fileName = string.Format("{0}.xml", player.Name);
            FileStream fs = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            StreamWriter sr = new StreamWriter(fs);
            sr.Write(player.Name + player.Score);
            sr.Close();          
            fs.Close();
        }
    }
}
