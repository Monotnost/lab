using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Lab_8
{
    class Functions
    {
        static public int GetNumberOfStudents(string path)
        {
            int lenght = 0;
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    sr.ReadLine();
                    lenght++;
                }
            }
            return lenght;
        }

        static public Student[] ReadBase(string labs_path, string student_path)
        {
            Student[] students = new Student[Functions.GetNumberOfStudents(student_path)];
            using (StreamReader sr = File.OpenText(student_path))
            {
                while (!sr.EndOfStream)
                {
                    for (int i = 0; i < students.Length; i++)
                    {
                        students[i] = new Student();
                        students[i].Name = sr.ReadLine().Split(',');
                        students[i].number = i + 1;
                    }
                }
            }
            using (StreamReader sr = File.OpenText(labs_path))
            {
                int lenght = Int32.Parse(sr.ReadLine());
                string[] buffer = sr.ReadLine().Split(',');
                for (int i = 0; i < students.Length; i++)
                {
                    students[i].Labs = new int[lenght][];
                    for (int j = 0; j < students[i].Labs.Length; j++)
                    {
                        students[i].Labs[j] = new int[Int32.Parse(buffer[j])];
                    }
                }
            }
            return students;
        }

        static public bool Identity(Student[] students, int[] ID)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if (students[i].number == ID[0] && students[i].Labs.Length >= ID[1] && students[i].Labs[ID[1]].Length >= ID[2])
                {
                    return true;
                }
            }
            return false;
        }

        static public Student[] Input(Student[] students)
        {
            int[] ID = new int[3];
            Console.WriteLine("Input the number of student:");
            ID[0] = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Input the number of lab:");
            ID[1] = Int32.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("Input the number of task:");
            ID[2] = Int32.Parse(Console.ReadLine());
            if (Identity(students, ID))
            {
                Console.WriteLine("Input the grade:");
                students[ID[0] - 1].Labs[ID[1]][ID[2] - 1] = Int32.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("This student/lab/task doesn't exist");
            }
            return students;
        }

        static public void SaveBinary(Student[] students, string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
            for (int i = 0; i < students.Length; i++)
            {
                BinaryFormatter formater = new BinaryFormatter();
                formater.Serialize(fs, students[i]);
            }
            fs.Close();
        }

        static public Student[] Read(string path_binary, string path)
        {
            Student[] students = new Student[Functions.GetNumberOfStudents(path)];
            FileStream fs = new FileStream(path_binary, FileMode.OpenOrCreate);
            for (int i = 0; i < students.Length; i++)
            {
                BinaryFormatter formater = new BinaryFormatter();
                students[i] = (Student)formater.Deserialize(fs);
            }
            fs.Close();
            return students;
        }

        static public Student[] ChangeStructure(Student[] students)
        {
            Student[] buffer = new Student[students.Length];
            for (int i = 0; i < students.Length; i++)
            {
                buffer[i] = new Student();
                buffer[i].Name = students[i].Name;
                buffer[i].number = students[i].number;
                buffer[i].Labs = new int[students[i].Labs.Length][];
                for (int j = 0; j < buffer[i].Labs.Length; j++)
                {
                    buffer[i].Labs[j] = new int[students[i].Labs[j].Length + 1];
                    for (int c = 0; c < students[i].Labs[j].Length; c++)
                    {
                        buffer[i].Labs[j][c] = students[i].Labs[j][c];
                    }
                    buffer[i].Labs[j][students[i].Labs[j].Length] = 0;
                }
            }
            return buffer;
        }
    }
}
