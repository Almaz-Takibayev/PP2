using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
namespace FarManager
{
    enum FSIMode
    {
        DIrectoryInfo = 1,
        File = 2
    }

    class Layer
    {
        public DirectoryInfo[] DirectoryContent
        {
            get;
            set;
        }

        public FileInfo[] FileContent
        {
            get;
            set;
        }

        public int SelectedIndex
        {
            get;
            set;
        }

        void SelectedColor(int it)
        {
            if (it == SelectedIndex)
            {
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Black;
            }
        }

        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            for(int i=0; i<DirectoryContent.Length; i++)
            {
                SelectedColor(i);
                Console.WriteLine((i + 1) + ". " + DirectoryContent[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            for(int i=0; i<FileContent.Length; i++)
            {
                SelectedColor(DirectoryContent.Length + i);
                Console.WriteLine((DirectoryContent.Length + 1 + i) + ". " + FileContent[i].Name);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }

    class Program
    {
        static bool PathExists(string path, int mode)
        {
            if((mode == 1 && new DirectoryInfo(path).Exists) || (mode == 2 && new FileInfo(path).Exists))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        static void Main(string[] args)
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Week2");
            if (!dir.Exists)
            {
                Console.WriteLine("Directory doesn't exist");
                return;
            }


            Layer l = new Layer
            {
                DirectoryContent = dir.GetDirectories(),
                FileContent = dir.GetFiles(),
                SelectedIndex = 0
            };


            Stack<Layer> history = new Stack<Layer>();
            history.Push(l);
            bool esc = false;
            FSIMode mode = FSIMode.DIrectoryInfo;
            while (!esc)
            {
                if (mode == FSIMode.DIrectoryInfo)
                {
                    history.Peek().Print();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey();
                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if(history.Peek().SelectedIndex > 0)
                        {
                            history.Peek().SelectedIndex--;
                        }
                        else
                        {
                            history.Peek().SelectedIndex = history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length - 1;
                        }
                        break;



                    case ConsoleKey.DownArrow:
                        if((history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length - 1)> history.Peek().SelectedIndex)
                        {
                            history.Peek().SelectedIndex++;
                        }
                        else
                        {
                            history.Peek().SelectedIndex = 0;
                        }
                        break;



                    case ConsoleKey.Enter:
                        if((history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length) == 0)
                        {
                            break;
                        }

                        int index = history.Peek().SelectedIndex;
                        if (index < history.Peek().DirectoryContent.Length)
                        {
                            DirectoryInfo di = history.Peek().DirectoryContent[index];
                            history.Push(new Layer
                            {
                                DirectoryContent = di.GetDirectories(),
                                FileContent = di.GetFiles(),
                                SelectedIndex = 0
                            });
                        }
                        else
                        {
                            mode = FSIMode.File;
                            using(FileStream fs = new FileStream(history.Peek().FileContent[index - history.Peek().DirectoryContent.Length].FullName, FileMode.Open, FileAccess.Read))
                            {
                                using (StreamReader sr = new StreamReader(fs))
                                {
                                    Console.BackgroundColor = ConsoleColor.White;
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.Clear();
                                    Console.WriteLine(sr.ReadToEnd());
                                }
                            }
                        }
                        break;



                    case ConsoleKey.Backspace:
                        if(mode == FSIMode.DIrectoryInfo)
                        {
                            if(history.Count > 1)
                            {
                                history.Pop();
                            }
                        }
                        else
                        {
                            mode = FSIMode.DIrectoryInfo;
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                        break;



                    case ConsoleKey.Escape:
                        esc = true;
                        break;



                    case ConsoleKey.Delete:
                        if(mode != FSIMode.DIrectoryInfo || (history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length) == 0)
                        {
                            break;
                        }

                        index = history.Peek().SelectedIndex;
                        int item = index;
                        if(index < history.Peek().DirectoryContent.Length)
                        {
                            history.Peek().DirectoryContent[index].Delete(true);
                        }
                        else
                        {
                            history.Peek().FileContent[index - history.Peek().DirectoryContent.Length].Delete();
                        }

                        int numOfFSI = history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length - 2;
                        history.Pop();
                        if (history.Count == 0)
                        {
                            Layer l1 = new Layer
                            {
                                DirectoryContent = dir.GetDirectories(),
                                FileContent = dir.GetFiles(),
                                SelectedIndex = Math.Min(Math.Max(numOfFSI, 0), item)
                            };
                            history.Push(l1);
                        }
                        else
                        {
                            index = history.Peek().SelectedIndex;
                            DirectoryInfo d = history.Peek().DirectoryContent[index];
                            Layer l1 = new Layer
                            {
                                DirectoryContent = d.GetDirectories(),
                                FileContent = d.GetFiles(),
                                SelectedIndex = Math.Min(Math.Max(numOfFSI, 0), item)
                            };
                            history.Push(l1);
                        }
                        break;



                    case ConsoleKey.F2:
                        if((history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length) == 0)
                        {
                            break;
                        }

                        index = history.Peek().SelectedIndex;
                        string name, fullname;
                        int selectedMode;
                        if(index < history.Peek().DirectoryContent.Length)
                        {
                            name = history.Peek().DirectoryContent[index].Name;
                            fullname = history.Peek().DirectoryContent[index].FullName;
                            selectedMode = 1;
                        }
                        else
                        {
                            name = history.Peek().FileContent[index - history.Peek().DirectoryContent.Length].Name;
                            fullname = history.Peek().FileContent[index - history.Peek().DirectoryContent.Length].FullName;
                            selectedMode = 2;
                        }

                        fullname = fullname.Remove(fullname.Length - name.Length);
                        Console.WriteLine("Please enter the new name, to rename {0}:", name);
                        Console.WriteLine(fullname);
                        string newname = Console.ReadLine();

                        while(newname.Length==0 || PathExists(fullname + newname, selectedMode))
                        {
                            Console.WriteLine("This directory was created, Enter the new one");
                            newname = Console.ReadLine();
                        }

                        Console.WriteLine(selectedMode);
                        if (selectedMode == 1)
                        {
                            new DirectoryInfo(history.Peek().DirectoryContent[index].FullName).MoveTo(fullname + newname);
                        }
                        else
                        {
                            new FileInfo(history.Peek().FileContent[index - history.Peek().DirectoryContent.Length].FullName).MoveTo(fullname + newname);
                        }

                        index = history.Peek().SelectedIndex;
                        item = index;
                        numOfFSI = history.Peek().DirectoryContent.Length + history.Peek().FileContent.Length - 1;
                        history.Pop();

                        if (history.Count == 0)
                        {
                            Layer l1 = new Layer
                            {
                                DirectoryContent = dir.GetDirectories(),
                                FileContent = dir.GetFiles(),
                                SelectedIndex = Math.Min(Math.Max(numOfFSI, 0), item)
                            };
                            history.Push(l1);
                        }
                        else
                        {
                            index = history.Peek().SelectedIndex;
                            DirectoryInfo d1 = history.Peek().DirectoryContent[index];
                            Layer l1 = new Layer
                            {
                                DirectoryContent = d1.GetDirectories(),
                                FileContent = d1.GetFiles(),
                                SelectedIndex = Math.Min(Math.Max(numOfFSI, 0), item)
                            };
                            history.Push(l1);
                        }
                break;
                }
            }
        }
    }
}