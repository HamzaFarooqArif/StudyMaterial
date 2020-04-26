using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static int fact(int n)
        {
            if (n == 0)
                return 1;
            else
                return n * fact(n - 1);
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("p1.in");
            int c = Int32.Parse(sr.ReadLine());
            for (int i = 0; i < c; i++)
            {
                int n = Int32.Parse(sr.ReadLine());
                Console.WriteLine(fact(n));
            }
            sr.Close();
        }
    }
}
