using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace Create_and_Parse_JSON_Data
{
   class Student
    {
        public static int Id { get; set; } // 为什么source code 不需要 static?
                                           // Why is "static" NOT needed in the source code?
        public static string Name { get; set; } // 同上。。。。
        public static string Degree { get; set; }
        public static List<string> Hobbies { get; set; }
        public override string ToString()
        {
            return string.Format("Student Information:\n\tId:{0}, \n\tName:{1}, Degree: {2}\n\t"
                                + "Hobbies:{3}", Id, Name, Degree, string.Join(",", Hobbies.ToArray()));
        }
    
        class Program //  inner/nested class
        {
            public static void Main(string[] args)
            {
                Student student = new Student();
                {
                    Id = 1; // 为什么用逗号会报错？ Why does the source code use , instead?
                    Name = "Baly"; // 同上。。。。
                    Degree = "MBA";
                    Hobbies = new List<string>()
                {
                    "Reading",
                    "Playing games"
                };
                };

                string studentInfoJson = JsonConvert.SerializeObject(student);
                File.WriteAllText(@"student.json", studentInfoJson);
                Console.WriteLine("Stored!");

                studentInfoJson = String.Empty;
                studentInfoJson = File.ReadAllText(@"student.json");

                var dictonary = JsonConvert.DeserializeObject<IDictionary>(studentInfoJson);
                foreach (DictionaryEntry entry in dictonary)
                {
                    Console.WriteLine(entry.Key + ":" + entry.Value); //为什么结果显示不出来？ o(╥﹏╥)o Not expected result shown ...
                }
                Console.ReadLine();
            }
        }
   }
}

// Source Code: https://docsend.com/view/h7ezhf5

//https://www.youtube.com/watch?v=NX3Um9E-AY0
