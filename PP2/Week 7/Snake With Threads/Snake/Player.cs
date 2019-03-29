using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    public class Player
    {
        string name;
        int score;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value;
            }
        }

        public Player() { }

        public Player(string name, int score)
        {
            this.name = name;
            this.score = score;

        }

        
        

        public void Draw()
        {
            Console.SetCursorPosition(35, 0);
            Console.Write(name);
        }

        public void SetName()
        {
            Console.SetCursorPosition(7, 20);
            Console.Write("Please enter your name: ");
            name = Console.ReadLine();
            Clear();
        }

        

        public void Clear()
        {
            for (int i = 7; i < 39; i++)
            {
                Console.SetCursorPosition(i, 20);
                Console.Write(' ');
            }
        } 
    }
}
