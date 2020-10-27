using System;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Lab_8
{
    
    class Program
    {
        static public void Menu(string labs_path, string student_path, string path_binary)
        {
            Student[] students = new Student[Functions.GetNumberOfStudents(student_path)];
            students = Functions.ReadBase(labs_path, student_path);
            bool flag = true;
            int ID = 0;
            string choose;
            Console.WriteLine("Choose availeble task. Please use only numbers to choose task:");
            Console.WriteLine("1. Input lab grade.");
            Console.WriteLine("2. Print list of students.");
            Console.WriteLine("3. Print list of lab for 1 student.");
            Console.WriteLine("4. Print table for 1 student.");
            Console.WriteLine("5. Save into bin file");
            Console.WriteLine("6. Read from bin file");
            Console.WriteLine("7. Add collum");
            Console.WriteLine("8. Exit");
            while (flag)
            {
                choose = Console.ReadLine();
                switch (choose)
                {
                    case "1":
                        students = Functions.Input(students);
                        break;
                    case "2":
                        Student.Print(students);
                        break;
                    case "3":
                        Console.WriteLine("Input the number of student:");
                        ID = Int32.Parse(Console.ReadLine());
                        Student.Print(students, ID - 1);
                        break;
                    case "4":
                        Console.WriteLine("Input the number of student:");
                        ID = Int32.Parse(Console.ReadLine());
                        Student.Print(students[ID - 1]);
                        break;
                    case "5":
                        Functions.SaveBinary(students, path_binary);
                        break;
                    case "6":
                        students = Functions.Read(path_binary, student_path);
                        break;
                    case "7":
                        students = Functions.ChangeStructure(students);
                        break;
                    case "8":
                        flag = false;
                        break;

                    default:
                        Console.WriteLine("Wrong Input. Please Try Again");
                        break;
                }
            }
        }

        static void Main(string[] args)
        {
            string labs_path = "Lab.txt";
            string student_path = "Students.txt";
            string path_binary = "Laboratory.bin";
            Menu(labs_path, student_path, path_binary);
        }
    }
}
