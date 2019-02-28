using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Task_1
{
    public class ComplexNumber
    {
        public int a
        {
            get;
            set;
        }
        public int b
        {
            get;
            set;
        }

        public ComplexNumber() { }

        public void Print()
        {
            Console.WriteLine(string.Format("{0}+{1}i", a, b));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Serialization();
            Deserialization();
        }

        private static void Serialization()
        {
            ComplexNumber complexNumber = new ComplexNumber()
            {
                a = 5,
                b = 8
            };

            XmlSerializer xs = new XmlSerializer(typeof(ComplexNumber));

            using (FileStream fs = new FileStream("ComplexNumber.xml", FileMode.Create, FileAccess.Write))
            {
                xs.Serialize(fs, complexNumber);
            }
        }

        private static void Deserialization()
        {
            using (FileStream fs = new FileStream("ComplexNumber.xml", FileMode.Open, FileAccess.Read))
            {
                XmlSerializer xs = new XmlSerializer(typeof(ComplexNumber));
                ComplexNumber complexNumber = xs.Deserialize(fs) as ComplexNumber;
                complexNumber.Print();
            }
        }
    }
}
