//---------------------------------------------
// Student.cs (c) 2018 by Hamza Farooq
//---------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    /// <summary>
    /// Student class creates Student type objects
    /// </summary>
    public class Student
    {
        /// <summary>
        /// Name of student. Contains words only.
        /// </summary>
        private string studentName;

        /// <summary>
        /// Registration number of student in proper format. e.g 2016-CS-122.
        /// </summary>
        private string registrationNumber;

        /// <summary>
        /// DateTime object that contains Date of birth of student.
        /// </summary>
        private DateTime dateOfBirth;

        /// <summary>
        /// CGPA of student with double precision
        /// </summary>
        private double cGPA;

        /// <summary>
        /// 13-digit CNIC of Student.
        /// </summary>
        private string cNIC;

        /// <summary>
        /// Hobbies of student.
        /// </summary>
        private string[] hobbies;

        /// <summary>
        /// Null constructor of Student class
        /// </summary>
        public Student()
        {
            /// <summary>
            /// Method call for getting input from console window
            /// </summary>
            Input();
        }

        /// <summary>
        /// Parameterized Null constructor of Student class
        /// </summary>
        /// <param name= "Name"> Name of Student.</param>>
        /// <param Registration= "Name"> Registration No. of Student.</param>>
        public Student(string Name, string Registration)
        {
            StudentName = Name;
            RegistrationNumber = Registration;
            /// <summary>
            /// Method call for getting input from console window
            /// </summary>
            Input();
        }

        /// <summary>
        /// Mutator method for StudentName
        /// </summary>
        public string StudentName
        {
            get { return studentName; }
            set
            {
                if (validateName(value))
                {
                    studentName = value;
                }
            }
        }

        /// <summary>
        /// Mutator method for RegistrationNumber
        /// </summary>
        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (validateRegistration(value))
                {
                    registrationNumber = value;
                }
            }
        }

        /// <summary>
        /// Mutator method for DateOfBirth
        /// </summary>
        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        /// <summary>
        /// Mutator method for CGPA
        /// </summary>
        public double CGPA
        {
            get { return cGPA; }
            set
            {
                if(validateCGPA(value))
                {
                    cGPA = value;
                }
            }
        }

        /// <summary>
        /// Mutator method for CNIC
        /// </summary>
        public string CNIC
        {
            get { return cNIC; }
            set
            {
                if(validateCNIC(value))
                {
                    cNIC = value;
                }
            }
        }

        /// <summary>
        /// Mutator method for Hobbies
        /// </summary>
        public string[] Hobbies
        {
            get { return hobbies; }
            set
            {
                hobbies = value;
            }
        }

        /// <summary>
        /// Validates Name of Student for provided conditions
        /// </summary>
        /// <param name= "studentName">Input Name of Student</param>>
        /// <returns>True if valid and false otherwise</returns>
        public bool validateName(string studentName)
        {
            char prevChr = 'a';
            if(studentName.Length != 0)
            {
                if(studentName[0] == ' ' || studentName[studentName.Length - 1] == ' ')
                {
                    Console.WriteLine("Invalid Format!");
                    return false;
                }
                for (int i = 0; i < studentName.Length; i++)
                {
                    if(i > 0)
                    {
                        if(prevChr == ' ' && studentName[i] == ' ')
                        {
                            Console.WriteLine("Invalid! Consecutive spaces ");
                            return false;
                        }

                    }
                    if (!((int)studentName[i] >= 65 && (int)studentName[i] <= 90) && !((int)studentName[i] >= 97 && (int)studentName[i] <= 122) && !((int)studentName[i] == 32))
                    {
                        Console.WriteLine("Invalid Format!");
                        return false;
                    }
                    prevChr = studentName[i];
                }
            }
            else
            {
                Console.WriteLine("Invalid Format!");
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// Validates Registration No. of Student for provided conditions
        /// </summary>
        /// <param name= "registrationNumber">Input Registration No. of Student</param>>
        /// <returns>True if valid and false otherwise</returns>
        public bool validateRegistration(string registrationNumber)
        {
            if(registrationNumber.Length <= 11 && registrationNumber.Length >= 9)
            {
                bool lastDigits = true;
                for (int i = 8; i < registrationNumber.Length; i++)
                {
                    if (!isInt(registrationNumber[i]))
                    {
                        lastDigits = false;
                    }
                }
                if (
                    (registrationNumber[0] == '2') &&
                    (registrationNumber[1] == '0') &&
                    (registrationNumber[2] == '1') &&
                    (
                       (registrationNumber[3] == '5') ||
                       (registrationNumber[3] == '6') ||
                       (registrationNumber[3] == '7')
                    ) &&
                    (registrationNumber[4] == '-') &&
                    (registrationNumber[5] == 'C') &&
                    (
                       (registrationNumber[6] == 'S') ||
                       (registrationNumber[6] == 'E')
                    ) &&
                    (registrationNumber[7] == '-') &&
                    lastDigits
                   )
                {
                    return true;
                }
            }
            
            Console.WriteLine("Invalid 'RegistrationNumber' Format!");
            return false;
        }

        /// <summary>
        /// Validates if input character is a numeral.
        /// </summary>
        /// <param name= "chr">Input Character</param>>
        /// <returns>True if character is a numeral and false otherwise</returns>
        public bool isInt(char chr)
        {
            if((int)chr >= 48 && (int)chr <= 57)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Validates if Input Date is a valid date.
        /// </summary>
        /// <param name= "date">Input date</param>>
        /// <returns>True if input date is valid and false otherwise</returns>
        public bool validateDate(string date)
        {

            string year = "";
            string month = "";
            string day = "";

            if (date.Length == 8)
            {
                year = date.Substring(0, 4);
                month = date.Substring(4, 2);
                day = date.Substring(6, 2);
            }

            if (
                !(
                  (year.Length == 4) &&
                  isInt(year[0]) &&
                  isInt(year[1]) &&
                  isInt(year[2]) &&
                  isInt(year[3])
                ) 
              )
            {
                Console.WriteLine("Invalid 'Year' in Date format!");
                return false;
            }

            if(month.Length <= 2)
            {
                for(int i = 0; i < month.Length; i++)
                {
                    if(!(isInt(month[i])))
                    {
                        Console.WriteLine("Invalid 'Month' in Date format!");
                        return false;
                    }
                }
                if (!(Int32.Parse(month) <= 12 && Int32.Parse(month) > 0))
                {
                    Console.WriteLine("Invalid 'Month' in Date format!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid 'Month' in Date format!");
                return false;
            }

            if(day.Length <= 2)
            {
                for (int i = 0; i < day.Length; i++)
                {
                    if (!(isInt(day[i])))
                    {
                        Console.WriteLine("Invalid 'day' in Date format!");
                        return false;
                    }
                }
                if (!(Int32.Parse(day) <= 31 && Int32.Parse(day) > 0))
                {
                    Console.WriteLine("Invalid 'day' in Date format!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid 'day' in Date format!");
                return false;
            }


            DateTime d1 = new DateTime(1990, 12, 31);
            DateTime d2 = new DateTime(2005, 1, 1);
            DateTime inputDate = new DateTime(Int32.Parse(year), Int32.Parse(month), Int32.Parse(day));

            if(inputDate < d1)
            {
                Console.WriteLine("Too Large Age");
                return false;
            }
            else if (inputDate > d2)
            {
                Console.WriteLine("Too Small Age");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Validates if input CGPA is a Valid.
        /// </summary>
        /// <param name= "cGPA">Input CGPA</param>>
        /// <returns>True if valid and false otherwise</returns>
        public bool validateCGPA(double cGPA)
        {
            if(!(cGPA >= 0 && cGPA <= 4))
            {
                Console.WriteLine("Invalid 'CGPA' ");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates if input CGPA is a Valid in string Input.
        /// </summary>
        /// <param name= "cGPA">Input CGPA as string</param>>
        /// <returns>True if valid and false otherwise</returns>
        public bool validateCGPAString(string cGPA)
        {
            int decimalPointCount = 0;

            if(cGPA.Length > 0)
            {
                for(int i = 0; i < cGPA.Length; i++)
                {
                    if (cGPA[i] == '.')
                    {
                        decimalPointCount++;
                    }
                    else if (!(isInt(cGPA[i])))
                    {
                        Console.WriteLine("Invalid Characters in 'CGPA' ");
                        return false;
                    }
                    if(decimalPointCount > 1)
                    {
                        Console.WriteLine("Invalid Decimal Points in 'CGPA' ");
                        return false;
                    }
                }
                if(!(validateCGPA(Convert.ToDouble(cGPA))))
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Invalid 'CGPA' ");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates if input CNIC is a Valid NIC number.
        /// </summary>
        /// <param name= "cNIC">Input NIC number</param>>
        /// <returns>True if valid and false otherwise</returns>
        public bool validateCNIC(string cNIC)
        {
            if(cNIC.Length == 13)
            {
                for(int i = 0; i < cNIC.Length; i++)
                {
                    if(!(isInt(cNIC[i])))
                    {
                        Console.WriteLine("Invalid Characters in 'CNIC' ");
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid 'CNIC' ");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates if input Hobby is a Valid Word.
        /// </summary>
        /// <param name= "hobby">Input hobby string</param>>
        /// <returns>True if valid and false otherwise</returns>
        public bool validateHobby(string hobby)
        {
            if(hobby.Length > 0)
            {
                for (int i = 0; i < hobby.Length; i++)
                {
                    if (!(isChar(hobby[i])))
                    {
                        Console.WriteLine("Invalid characters in 'Hobby' ");
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid length of 'Hobby' ");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates if hobbies in string array are all valid words.
        /// </summary>
        /// <param name= "Hobbies">Input string array of Hobbies</param>>
        /// <returns>True if valid and false otherwise</returns>
        public bool validateHobbies(string[] Hobbies)
        {
            if(Hobbies.Length > 0)
            {
                for(int i = 0; i < Hobbies.Length; i++)
                {
                    if(!(validateHobby(Hobbies[i])))
                    {
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid length of 'Hobbies' ");
                return false;
            }
            return true;
        }

        /// <summary>
        /// Validates if input character is an alphabet.
        /// </summary>
        /// <param name= "chr">Input character</param>>
        /// <returns>True if valid and false otherwise</returns>
        public bool isChar(char chr)
        {
            if (!((int)chr >= 65 && (int)chr <= 90) && !((int)chr >= 97 && (int)chr <= 122) && !((int)chr == 32))
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Slices the space seperated Input string.
        /// </summary>
        /// <param name= "str">Input string</param>>
        /// <returns>Array of strings</returns>
        public string[] sliceString(string str)
        {
            int prevIdx = 0;
            int currentWord = 0;
            int wordsCount = countWords(str);
            string[] result = new string[wordsCount];

            for (int i = 0; i < str.Length; i++)
            {
                if(str[i] == ' ')
                {
                    result[currentWord] = str.Substring(prevIdx, i - prevIdx);
                    currentWord++;
                    prevIdx = i + 1;
                }
            }
            result[currentWord] = str.Substring(prevIdx, str.Length - prevIdx);

            return result;
        }

        /// <summary>
        /// Counts space seperated words in input string
        /// </summary>
        /// <param name= "str">Input string</param>>
        /// <returns>Integer that is Number of words</returns>
        public int countWords(string str)
        {
            if(str.Length > 0)
            {
                int wordsCount = 1;
                for (int i = 0; i < str.Length; i++)
                {
                    if(str[i] == ' ')
                    {
                        wordsCount++;
                    }
                }
                return wordsCount;
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Gets user input from console window.
        /// </summary>
        public void Input()
        {
            string[] placeHolders = { "Please Re-enter: ", "Enter Student Name: ", "Enter Registration Number (201X-CX-XXX): ", "Enter Date Of Birth (YYYYMMDD): ", "Enter CGPA (0 to 4): ", "Enter CNIC: ", "Enter Hobbies (Seperated by spaces): " };
            string input;

            if(StudentName == default(string))
            {
                Console.Write(placeHolders[1]);
                input = Console.ReadLine();
                while (!(validateName(input)))
                {
                    Console.Write(placeHolders[0]);
                    Console.Write(placeHolders[1]);
                    input = Console.ReadLine();
                }
                StudentName = input;
            }
            
            if(RegistrationNumber == default(string))
            {
                Console.Write(placeHolders[2]);
                input = Console.ReadLine();
                while (!(validateRegistration(input)))
                {
                    Console.Write(placeHolders[0]);
                    Console.Write(placeHolders[2]);
                    input = Console.ReadLine();
                }
                RegistrationNumber = input;

            }

            Console.Write(placeHolders[3]);
            input = Console.ReadLine();
            while (!(validateDate(input)))
            {
                Console.Write(placeHolders[0]);
                Console.Write(placeHolders[3]);
                input = Console.ReadLine();
            }
            DateTime d = new DateTime(Int32.Parse(input.Substring(0, 4)), Int32.Parse(input.Substring(4, 2)), Int32.Parse(input.Substring(6, 2)));
            DateOfBirth = d;

            Console.Write(placeHolders[4]);
            input = Console.ReadLine();
            while (!(validateCGPAString(input)))
            {
                Console.Write(placeHolders[0]);
                Console.Write(placeHolders[4]);
                input = Console.ReadLine();
            }
            CGPA = Convert.ToDouble(input);

            Console.Write(placeHolders[5]);
            input = Console.ReadLine();
            while (!(validateCNIC(input)))
            {
                Console.Write(placeHolders[0]);
                Console.Write(placeHolders[5]);
                input = Console.ReadLine();
            }
            CNIC = input;

            Console.Write(placeHolders[6]);
            input = Console.ReadLine();
            while(!(validateName(input)))
            {
                Console.Write(placeHolders[0]);
                Console.Write(placeHolders[6]);
                input = Console.ReadLine();
            }
            Hobbies = sliceString(input);
        }

        /// <summary>
        /// Calculates Student Age from Now.
        /// </summary>
        /// <returns>string of properly formatted Date</returns>
        public string GetAge()
        {
            string result = "Age is ";
            int days;
            TimeSpan AgeSpan = DateTime.Today.Subtract(DateOfBirth);
            days = AgeSpan.Days;


            result += (int)(days / 365);
            result += " years ";
            days -= (int)(days / 365) * 365;

            result += (int)(days / 31);
            result += " months ";
            days -= (int)(days / 31) * 31;

            result += days;
            result += " days";

            return result;
        }

        /// <summary>
        /// Calculates Status of Student based on CGPA.
        /// </summary>
        /// <returns>String of Status</returns>
        public string  GetStatus()
        {
            string result = "Unknown";

            if (CGPA < 2) result = "Suspended";
            else if (CGPA > 2 && CGPA < 2.5) result = "Below Average";
            else if (CGPA > 2.5 && CGPA < 3.3) result = "Average";
            else if (CGPA > 3.3 && CGPA < 3.5) result = "Below Good";
            else if (CGPA > 3.5) result = "Excellent";

            return result;
        }

        public int NumberOfWordsInName()
        {
            return countWords(StudentName);
        }

        /// <summary>
        /// Get the Gender of Student based on last digit of CNIC.
        /// </summary>
        /// <returns>String of Student's Gender</returns>
        public string GetGender()
        {
            string result;
            if(!(CNIC[12] % 2 == 0))
            {
                result = "MALE";
            }
            else
            {
                result = "FEMALE";
            }
            return result;
        }

        /// <summary>
        /// Displays the output of student object in proper format.
        /// </summary>
        public void ToString()
        {
            Console.WriteLine("");
            Console.Write("Name: ");
            Console.Write(StudentName);
            Console.Write(" (Contain ");
            Console.Write(NumberOfWordsInName());
            Console.WriteLine(" word(s))");

            Console.Write("Registration Number: ");
            Console.WriteLine(RegistrationNumber);

            Console.Write("CGPA: ");
            Console.Write(CGPA);
            Console.Write(" ");
            Console.WriteLine(GetStatus());

            Console.Write("Date Of Birth: ");
            Console.Write(DateOfBirth.ToString("MMMM dd, yyyy "));
            Console.Write(" (");
            Console.Write(GetAge());
            Console.WriteLine(")");

            Console.Write("CNIC: ");
            Console.WriteLine(CNIC);

            Console.Write("Gender: ");
            Console.WriteLine(GetGender());

            Console.Write("Hobbies: ");
            for(int i = 0; i < Hobbies.Length - 1; i++)
            {
                Console.Write(Hobbies[i]);
                Console.Write(", ");
            }
            Console.WriteLine(Hobbies[Hobbies.Length - 1]);
        }

        /// <summary>
        /// Displays only initialized data members of student object in proper format.
        /// </summary>
        public void displayInitialized()
        {
            Console.WriteLine("");
            if (StudentName != default(string))
            {
                Console.Write("Name: ");
                Console.Write(StudentName);
                Console.Write(" (Contain ");
                Console.Write(NumberOfWordsInName());
                Console.WriteLine(" words)");
            }

            if(RegistrationNumber != default(string))
            {
                Console.Write("Registration Number: ");
                Console.WriteLine(RegistrationNumber);
            }

            if(CGPA > 0)
            {
                Console.Write("CGPA: ");
                Console.Write(CGPA);
                Console.Write(" ");
                Console.WriteLine(GetStatus());
            }

            if(DateOfBirth > DateTime.MinValue)
            {
                Console.Write("Date Of Birth: ");
                Console.Write(DateOfBirth.ToString("MMMM dd, yyyy "));
                Console.Write(" (");
                Console.Write(GetAge());
                Console.WriteLine(")");
            }

            if(CNIC != default(string))
            {
                Console.Write("CNIC: ");
                Console.WriteLine(CNIC);

                Console.Write("Gender: ");
                Console.WriteLine(GetGender());
            }

            if(Hobbies != default(string[]))
            {
                Console.Write("Hobbies: ");
                for (int i = 0; i < Hobbies.Length - 1; i++)
                {
                    Console.Write(Hobbies[i]);
                    Console.Write(", ");
                }
                Console.WriteLine(Hobbies[Hobbies.Length - 1]);
            }
        }
    }
}
