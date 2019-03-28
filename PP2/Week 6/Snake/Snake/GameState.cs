using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Snake
{

    public class GameState
    {


        public bool gameOver = false;
        Worm worm = new Worm('O');
        Food food = new Food('@');
        Wall wall;
        public Player player = new Player();
        public ScoreLevel scoreLevel = new ScoreLevel();
        public int LevelNumber { get; set; } = 0;


        public GameState()
        {
            Console.SetWindowSize(40, 42);
            Console.SetBufferSize(40, 42);
            Console.CursorVisible = false;
            player.SetName();

        }

        public void Draw()
        {
            if (!gameOver)
            {
                wall = new Wall('#', LevelNumber);
                worm.Draw();
                food.Draw();
                wall.Draw();
                //player.score.Draw();
                scoreLevel.Draw();
                player.Draw();

            }
        }

        public void ProcessKeyEvent(ConsoleKeyInfo consoleKeyInfo)
        {
            switch (consoleKeyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    if (worm.dir != Worm.Direction.Down)
                    {
                        worm.Move(0, -1);
                        worm.dir = Worm.Direction.Up;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (worm.dir != Worm.Direction.Up)
                    {
                        worm.Move(0, 1);
                        worm.dir = Worm.Direction.Down;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (worm.dir != Worm.Direction.Left)
                    {
                        worm.Move(1, 0);
                        worm.dir = Worm.Direction.Right;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (worm.dir != Worm.Direction.Right)
                    {
                        worm.Move(-1, 0);
                        worm.dir = Worm.Direction.Left;
                    }
                    break;
                case ConsoleKey.Spacebar:
                    Serialize(player);
                    break;
            }

            CheckCollision();

        }

        private void Serialize(Player player)
        {
            XmlSerializer xmlSerializer1 = new XmlSerializer(typeof(Player));
            string fileName = string.Format("{0}.xml", player.Name);
            string path = @"C:\Users\User\Desktop\PP2\PP2\Week 6\Snake\Snake\bin\Debug\ScoreTable";
            string directory = Path.Combine(path, fileName);
            using (FileStream fs = new FileStream(directory, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer1.Serialize(fs, player);
            }
        }

        private void CheckCollision()
        {
            if (worm.IsIntersected(wall.body) || worm.IsIntersected(worm.body))
            {
                gameOver = true;
                Console.Clear();
                Console.SetCursorPosition(15, 20);
                Console.Write("Game Over!");
            }
            else if (worm.IsIntersected(food.body))
            {
                //player.score.Score += 10;
                scoreLevel.Score += 25;
                player.Score = scoreLevel.Score;
                if (scoreLevel.Score == 50)
                {
                    wall.Clear();
                    LevelNumber = 1;
                    scoreLevel.Level = 2;
                    wall.Draw();
                }
                else if (scoreLevel.Score == 100)
                {
                    wall.Clear();

                    LevelNumber = 2;
                    scoreLevel.Level = 3;
                    wall = new Wall('#', LevelNumber);
                    wall.Draw();
                }
                worm.Eat(food.body);
                food.GenerateLocation(worm.body, wall.body);
            }
        }
    }
}