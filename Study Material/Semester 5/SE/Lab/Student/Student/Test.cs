//---------------------------------------------
// Test.cs (c) 2018 by Hamza Farooq
//---------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    class Test
    {
        static void Main(string[] args)
        {
            /// <summary>
            /// Prompt for credentials of first Student Object
            /// </summary>
            Console.WriteLine("Enter Credentials for first Student");
            /// <summary>
            /// Instantiate Student class
            /// </summary>
            Student s1 = new Student();

            /// <summary>
            /// Prompt for credentials of second Student Object
            /// </summary>
            Console.WriteLine("");
            Console.WriteLine("Enter Credentials for second Student");

            /// <summary>
            /// Instantiate Student class
            /// </summary>
            Student s2 = new Student("Hamza Farooq", "2016-CS-122");

            /// <summary>
            /// Display attributes of both Student objects on console window
            /// </summary>
            s1.ToString();
            s2.ToString();

            /// <summary>
            /// Wait for Enter press
            /// </summary>
            Console.ReadLine();

        }
    }
}
