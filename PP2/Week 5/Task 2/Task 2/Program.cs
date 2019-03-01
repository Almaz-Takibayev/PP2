using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_2
{
    public class Mark
    {
        public int x = 0;        
        
        public int GetMark
        {
            get
            {
                return x;
            }
            set
            {
                if(value > 100)
                {
                    x = 100;
                }
                else if(value < 0)
                {
                    x = 0;
                }
                else
                {
                    x = value;
                }
            }
        }

        public Mark() { }
        
        public Mark(int _x)
        {
            x = _x;
        }

        public override string ToString()
        {
            string l = "F";
            if (x >= 95)
            {
                l = "A";
            }
            else if (x >= 90 && x <= 94)
            {
                l = "A-";
            }
            else if (x >= 85 && x <= 89)
            {
                l = "B+";
            }
            else if (x >= 80 && x <= 84)
            {
                l = "B";
            }
            else if (x >= 75 && x <= 79)
            {
                l = "B-";
            }
            else if (x >= 70 && x <= 74)
            {
                l = "C+";
            }
            else if (x >= 65 && x <= 69)
            {
                l = "C";
            }
            else if (x >= 60 && x <= 64)
            {
                l = "C-";
            }
            else if (x >= 50 && x <= 59)
            {
                l = "D";
            }
            return l;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Serialization();
            Deserialization();
        }

        public static void Serialization()
        {
            List<Mark> marks = new List<Mark>();
            for (int i = 0; i < 10; i++)
            {
                marks.Add(new Mark(46 + (5 * i)));
            }

            XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));

            using(FileStream fs = new FileStream("Marks.xml", FileMode.Create, FileAccess.Write))
            {
                xs.Serialize(fs, marks);
            }
        }

        public static void Deserialization()
        {
            using (FileStream fs = new FileStream("Marks.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(typeof(List<Mark>));
                List<Mark> marks = xs.Deserialize(fs) as List<Mark>;
                foreach(var z in marks)
                {
                    Console.WriteLine("Mark: {0}", z.ToString());
                }
            }

        }
    }
}
