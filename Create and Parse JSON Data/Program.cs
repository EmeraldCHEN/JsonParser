using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

namespace Create_and_Parse_JSON_Data
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Degree { get; set; }
        public List<string> Hobbies { get; set; }
        public override string ToString()
        {
            return string.Format("Student Information:\n\tId:{0}, \n\tName:{1}, Degree: {2}\n\t"
                                + "Hobbies:{3}", Id, Name, Degree, string.Join(",", Hobbies.ToArray()));
        }

        class Program // doesn't matter if inner/nested class or not
        {
            public static void Main(string[] args)
            {
                Student student = new Student() // can NOT have ';' at the end... must pay attention to detail
                {
                    Id = 1,
                    Name = "Baly",
                    Degree = "MBA",
                    Hobbies = new List<string>()
                    {
                        "Reading",
                        "Playing games"
                    }
                };

                string studentInfoJson = JsonConvert.SerializeObject(student);
                File.WriteAllText(path: @"student.json", contents: studentInfoJson);
               // Console.WriteLine("Stored!");

               // studentInfoJson = string.Empty;
                studentInfoJson = File.ReadAllText(@"student.json");

                var dictonary = JsonConvert.DeserializeObject<IDictionary>(studentInfoJson);
                foreach (DictionaryEntry entry in dictonary)
                {
                    Console.WriteLine(value:entry.Key + ":" + entry.Value); 
                }
                Console.ReadLine();
            }
        }
    }
}
// Retrieved from:https://www.youtube.com/watch?v=NX3Um9E-AY0
// Source Code: https://docsend.com/view/h7ezhf5

