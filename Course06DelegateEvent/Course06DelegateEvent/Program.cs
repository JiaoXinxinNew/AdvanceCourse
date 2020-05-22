using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course06DelegateEvent
{
    class Program
    {
        public delegate bool FiltrateDelegate(Student student);
        static void Main(string[] args)
        {
            List<Student> StudentList = new List<Student>()
            {
                new Student
                {
                    Name="张三",
                    Id=1,
                    Age=11
                },
                new Student
                {
                    Name="李四",
                    Id=2,
                    Age=22
                },
                new Student
                {
                    Name="王五",
                    Id=2,
                    Age=33
                }
            };
            Student student = new Student();
            Program program = new Program();
            FiltrateDelegate filtrateDelegate = new FiltrateDelegate(program.FiltrateStudent);
            foreach (FiltrateDelegate item in filtrateDelegate.GetInvocationList())
            {
                item.Invoke(student);
            }
            Cat cat = new Cat();
            cat.miaoDelegateEvent += Cry;
            cat.Miao();


            System.Console.ReadKey();
        }
        public  List<Student> GetStudents(List<Student> studentList,FiltrateDelegate method)
        {
            List<Student> result = new List<Student>();
            foreach (var student in studentList)
            {
                if (method(student))
                {
                    result.Add(student);
                }
            }
            return result;
        }
        public bool FiltrateStudent(Student student) 
        {
            return student.Age > 20;
        }
        public static void Cry()
        {
            Console.WriteLine("哭一下");
        }

    }
}
