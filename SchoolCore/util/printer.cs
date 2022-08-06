using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
namespace SchoolCore.util
{
    public static class Printer
    {
        public static void LineDraw(int tam = 10) {

            WriteLine("".PadLeft(tam, '='));
        }
        public static void WriteTitle(string title)
        {
            int tam = title.Length + 4;
            LineDraw(tam);
            WriteLine($"| {title} |");
            LineDraw(tam);
        }

        public static void Beep(int hz= 2000, int temp= 500, int cant=1) {
            while (cant-- >0) {
                Console.Beep(hz,temp);
           }
        }
    }
}
