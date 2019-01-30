using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        //я создал класс Student и ввел туда имя, ID и год обучения
        class Student
        {
            public string name;
            public string ID;
            public int year;

            //я создал конструктор Student в котором содержится имя и ID
            public Student(string name, string ID)
            {
                this.name = name;
                this.ID = ID;
            }

            //Эта функция выводит все элементы класса Student и год обучения увеличивается на 1 год
            public void Print()
            {
                Console.WriteLine(this.name + " " + this.ID + " " + (this.year+1));
            }
        }

        static void Main(string[] args)
        {
            //количество студентов
            int n = int.Parse(Console.ReadLine());
            //создаю массив Студентов
            Student[] a = new Student[n];
            //создаю в цикле массив стрингов arr и ввожу в них имя и ID. Потом добавляю их в конструктор Студент. И в конце добавляю год обучения
            for (int i=0; i<n; i++)
            {
                string[] arr = Console.ReadLine().Split();
                string name = arr[0];
                string ID = arr[1];
                a[i] = new Student(name, ID);
                a[i].year = int.Parse(arr[2]);
            }

            //вывожу массив Студентов на консоль
            for(int i=0; i<n; i++)
            {
                a[i].Print();
            }
            Console.ReadKey();
        }
    }
}
