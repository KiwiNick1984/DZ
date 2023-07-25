using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DZ_9
{
    internal class DriverNav
    {
        int _navIndex;
        int _count;
        DriveInfo[] _drivers;
        DirectoryInfo _dirInfo;
        DirectoryInfo[] _dirs;
        FileInfo[] _files;
        string _path;

        public DriverNav()
        {
            _navIndex = 0;
            _drivers = DriveInfo.GetDrives();
            _count = _drivers.Length;
            _path = _drivers[_navIndex].Name;
            Print();
        }

        void Print()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            if (_dirInfo == null ) 
            {
                for (int i = 0; i < _count; i++)
                {
                    if (i == _navIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine($"  {_drivers[i]}" + new string(' ', 8 - _drivers[i].Name.Length));
                }
            }
            else
            {
                int strLength;
                string strName;
                Console.WriteLine($"===={_path}" + new string('=', 35 - _path.Length));
                for (int i = 0; i < _count; i++)
                {
                    if (i == _navIndex)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if(i < _dirs.Length)
                    {
                        strLength = _dirs[i].Name.Length < 28 ? _dirs[i].Name.Length : 28;
                        strName = _dirs[i].Name.Length < 28 ? _dirs[i].Name : _dirs[i].Name .Substring(0, 25) + "...";
                        Console.WriteLine($"  {strName}" + new string(' ', 35 - strLength));
                    }                        
                    else
                    {
                        strLength = _files[i - _dirs.Length].Name.Length < 28 ? _files[i - _dirs.Length].Name.Length : 28;
                        strName = _files[i - _dirs.Length].Name.Length < 28 ? _files[i - _dirs.Length].Name : _files[i - _dirs.Length].Name.Substring(0, 25) + "...";
                        Console.WriteLine($"  {strName}" + new string(' ', 30 - strLength) + _files[i - _dirs.Length].Extension + ' ');
                    }

                        
                }
            }
        }

        public void Up()
        { 
            if(_navIndex == 0)
                _navIndex = _count-1;
            else
                _navIndex--;
            Print();
        }
        public void Down()
        {
            if (_navIndex == _count - 1)
                _navIndex = 0;
            else
                _navIndex++;
            Print();
        }
        public void Select()
        {
            if (_dirInfo == null)
            {
                _dirInfo = new DirectoryInfo(_drivers[_navIndex].Name);
                _path = _dirInfo.FullName;
            }
            else
            {
                if(_navIndex < _dirs.Length)
                {
                    _dirInfo = new DirectoryInfo(_dirs[_navIndex].FullName);
                    _path = _dirInfo.FullName;
                }
                else
                {
                    Console.WriteLine(_files[_navIndex - _dirs.Length].FullName);
                    Console.Clear();                    
                    PrintTxt();
                }
            }
            _dirs = _dirInfo.GetDirectories();
            _files = _dirInfo.GetFiles();
            _count = _dirs.Length + _files.Length;
            _navIndex = 0;
            Print();
        }
        public void Back()
        {            
            if (Directory.GetParent(_path) == null)
            {
                _dirInfo = null;
                _path = _drivers[_navIndex].Name;
                _count = _drivers.Length;
            }
            else
            {
                _dirInfo = new DirectoryInfo(Directory.GetParent(_path).FullName);
                _path = _dirInfo.FullName;
                _dirs = _dirInfo.GetDirectories();
                _files = _dirInfo.GetFiles();
                _count = _dirs.Length + _files.Length;
                _navIndex = 0;
            }
            Print();
        }

        private void PrintTxt()
        {            
            String line;
            if (_files[_navIndex - _dirs.Length].Extension == ".txt") 
            {
                try
                {
                    StreamReader sr = new StreamReader(_files[_navIndex - _dirs.Length].FullName);
                    line = sr.ReadLine();
                    while (line != null)
                    {
                        Console.WriteLine(line);
                        line = sr.ReadLine();
                    }
                    sr.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("КОНЕЦ ФАЙЛА");
                }
            }
            else
            {
                Console.WriteLine("Этот файл не txt");
            }
            Console.WriteLine("->>Нажмите Enter для выхода");
            Console.ReadLine();
        }
    }
}
