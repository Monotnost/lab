using System;
using System.Collections.Generic;
using System.Text;

namespace Lab_8
{
    [Serializable]
    class Student
    {
        public int number = 0;
        public string[] Name = new string[2];
        public int[][] Labs;

        static public void Print(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                Console.WriteLine("{0} {1}", students[i].Name[0], students[i].Name[1]);
            }
        }

        static public void Print(Student[] students, int ID)
        {
            Console.WriteLine("{0} {1}:", students[ID].Name[0], students[ID].Name[1]);

            for (int i = 0; i < students[ID].Labs.Length; i++)
            {
                bool flag = true;
                for (int j = 0; j < students[ID].Labs[i].Length; j++)
                {
                    if (students[ID].Labs[i][j] <= 3)
                    {
                        flag = false;
                    }
                }
                if (flag)
                {
                    Console.WriteLine("Lab number {0}", i);
                }
            }
        }

        static public void Print(Student students)
        {
            for (int i = 0; i < students.Labs.Length; i++)
            {
                string buffer = "Lab number " + (i + 1).ToString() + ": ";
                for (int j = 0; j < students.Labs[i].Length; j++)
                {
                    buffer += students.Labs[i][j].ToString() + " ";
                }
                Console.WriteLine(buffer);
            }
        }
    }
}
