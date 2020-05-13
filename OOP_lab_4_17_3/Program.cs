using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace OOP_lab_4_17_3
{
    class Program
    {
        public static Weather[] weather = new Weather[100000000];
        public static bool[] delete = new bool[100000000];

        static void Main(string[] args)
        {
            Work.Key();
        }
    }
}
