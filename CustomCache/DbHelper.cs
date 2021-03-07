using System;
using System.Collections.Generic;

namespace CustomCache
{
    /// <summary>
    /// 模拟数据库获取数据
    /// </summary>
    public class DbHelper
    {

        public List<Student> GetStudents()
        {
            List<Student> students = new List<Student>();
            for (long i = 0; i < 100_000; i++)
            {
                students.Add(new Student
                {
                    Id = i,
                    Name = Guid.NewGuid().ToString("N")
                });
            }

            return students;
        }
    }

    public class Student
    {
        public long Id { set; get; }

        public string Name { set; get; }
    }
}
