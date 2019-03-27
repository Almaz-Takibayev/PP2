using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    [Serializable]
    public class ScoreLevel
    {
        int score;
        int level;
        

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

        public int Level
        {
            get
            {
                return level;
            }
            set
            {
                level = value;
            }
        }

        

        public ScoreLevel()
        {
            score = 0;
            level = 1;
            
        }


        public void Draw()
        {
            Console.SetCursorPosition(0, 41);
            Console.Write("Score: {0}", score);
            Console.SetCursorPosition(19, 41);
            Console.Write("Level {0}", level);
        }
    }
}
