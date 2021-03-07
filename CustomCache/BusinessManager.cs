using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CustomCache
{
    /// <summary>
    /// 模拟业务场景
    /// </summary>
    public class BusinessManager
    {

        /// <summary>
        /// 缓存时的key 的处理  业务的方法名称 结合参数 如果参数名称改变 则更新缓存 不同的业务有不同的缓存
        /// </summary>
        public void GetAllDbStudents()
        {
            DbHelper dbHelper = new DbHelper();

            string key = "Test_Key";
            CacheManager<List<Student>> cacheManager = new CacheManager<List<Student>>();
            for (int i = 0; i < 5; i++)
            {
                List<Student> entities = null;
                if (cacheManager.ExistKey(key))
                {
                    entities = cacheManager.GetCache(key);
                    Console.WriteLine($"缓存中获取的数据,获取的数据数量{entities.Count}");
                }
                else
                {
                    entities = dbHelper.GetStudents();
                    cacheManager.AddCache(key, entities, 0.5);
                    Console.WriteLine($"实际获取的数据,获取的数据数量{entities.Count}");
                }
            }
        }

        public void UpdateDbStudent()
        {
            CacheManager<Student> cacheManager = new CacheManager<Student>();
            Student student = new Student
            {
                Id = 10,
                Name = "Test"
            };

            string key = "student_key";
            cacheManager.AddCache(key, student, 1);
            cacheManager.GetExpiredTime(key);

            Student newStudent = new Student
            {
                Id = 11,
                Name = "Test11"
            };
            cacheManager.UpdateCache(key, newStudent, 10);
            cacheManager.GetExpiredTime(key);
        }

        /// <summary>
        /// 严重性	代码	说明	项目	文件	行	禁止显示状态
        ///错误 MSB3021 无法将文件“obj\Debug\netcoreapp3.1\CustomCache.dll”复制到“bin\Debug\netcoreapp3.1\CustomCache.dll”。对路径“bin\Debug\netcoreapp3.1\CustomCache.dll”的访问被拒绝。	CustomCache C:\Program Files(x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\Microsoft.Common.CurrentVersion.targets	4382	
        /// </summary>
        public void TaskDbStudentCache()
        {
            Student student = new Student
            {
                Id = 10,
                Name = "Test"
            };

            List<Task> tasks = new List<Task>();
            CacheManager<Student> cacheManager = new CacheManager<Student>();
            for (int i = 0; i < 20; i++)
            {
                int currentIndex = i;
                Task task = Task.Run(() =>
                 {
                     int threadCurrentId = Thread.CurrentThread.ManagedThreadId;

                     string key = $"index{currentIndex}-ThreadId{threadCurrentId}-Key";
                     cacheManager.AddCache(key, student, null);
                 });

                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            var result = cacheManager.ShowKeys();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
    }
}