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
        static Player player = new Player();

        

        static void Serialize(GameState game)
        {
            //Player player = new Player();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameState));
            //string fname = string.Format("game_{0}.xml", DateTime.Now.ToString("yyyyMMddHHmmss"));
            //string fname = string.Format("game.xml");
            string fileName = string.Format("{0}.xml", player.Name);
            string path = @"C:\Users\User\Desktop\PP2\PP2\Week 7\Snake With Threads\Snake\bin\Debug\ScoreTable";
            string directory = Path.Combine(path, fileName);
            using (FileStream fs = new FileStream(directory, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(fs, game);
            }
        }

        static GameState Deserialize()
        {
            //Player player = new Player();
            GameState gameState = null;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(GameState));
            string fileName = string.Format("{0}.xml", player.Name);
            string path = @"C:\Users\User\Desktop\PP2\PP2\Week 7\Snake With Threads\Snake\bin\Debug\ScoreTable";
            string directory = Path.Combine(path, fileName);
            using (FileStream fs = new FileStream(directory, FileMode.Open, FileAccess.Read))
            {
                gameState = xmlSerializer.Deserialize(fs) as GameState;
            }
            return gameState;
        }

        static void Main(string[] args)
        {
            GameState game = new GameState();
            player.SetName();
            game.Run();            
            while (true)
            {
                player.Draw();
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                if (consoleKeyInfo.Key == ConsoleKey.F2)
                {
                    Serialize(game);
                }
                else if (consoleKeyInfo.Key == ConsoleKey.F3)
                {
                    game.Stop();
                    game = Deserialize();
                    game.Run();
                }
                else
                {
                    game.ProcessKeyEvent(consoleKeyInfo);
                }
            }
        }

        
    }
}