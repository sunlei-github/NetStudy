using DapperService.Entity;
using System;
using System.Collections.Generic;

namespace DapperService
{
    /// <summary>
    /// Dapper是一款轻量级ORM工具
    ///Dapper的速度接近与IDataReader，取列表的数据超过了DataTable，Dapper支持多数据库。
    ///诸如：Mysql、SqlLite、Mssql系列、Oracle等一系列的数据库。Dapper支持多表并联的对象。
    ///支持一对多，多对多的关系。并且没侵入性，想用就用，不想用就不用，无XML无属性，
    ///代码以前怎么写现在还怎么写。Dapper原理通过Emit反射IDataReader的序列队列，
    ///来快速的得到和产生对象，性能高，语法十分简单，并且无须迁就数据库的设计。
    ///
    /// 但是Dapper 仍然存在sql注入问题 ，需要使用参数化的sql来避免这一问题
    /// 个人看法
    /// Dapper通过扩展Ado.Net的SqlConnection类型来 提供更加便捷的api  
    /// 使得查询可以更加快速的获取对应的已经包装好的数据
    /// 用法与Ado.Net类似 相比较Dapper比EF的效率更高
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //增加
            //string sqlInsert = "INSERT INTO [dbo].[People] ([Name],[Old],[Birthday]) VALUES (@Name,@old,@Birthday)";
            //People insertPeople = new People
            //{
            //    Birthday = DateTime.Now,
            //    Name = "Tom"
            //};
            // DapperHelper.Execute(sqlInsert, insertPeople);
            //批量插入 批量更新类似
            //List<People> peoples = new List<People>
            //{
            //    new People (){ Birthday=DateTime.Now,Old=222,Name="MMMM"},
            //    new People (){ Birthday=DateTime.Now,Old=555,Name="AAA"},
            //     new People (){ Birthday=DateTime.Now,Old=8888,Name="DASDASD"},
            //};
            //DapperHelper.Execute(sqlInsert, peoples);

            //更新
            //string sqlUpdate = "update People set Name=@name , Old=@old ,Birthday=@birthday  where Id=@id";
            //People updatePeople = new People
            //{
            //    Id = 1,
            //    Old = 9999,
            //    Name="Mike"
            //};
            //DapperHelper.Execute(sqlUpdate, updatePeople);

            //删除
            //string sqlDelete = "delete People where Id=@id";
            //DapperHelper.Execute(sqlDelete, new { id = 1 });

            //查询列表
            //string sqlQueryList = "select * from People where id<@id";
            //List<People> peoples = DapperHelper.QueryList<People>(sqlQueryList, new { id = 60 });
            //分页查询
            //string sqlPage = "select * from People order by id offset (@pageIndex*1)*@pageSize rows fetch next @pageSize rows only";
            //List<People> peoples = DapperHelper.QueryList<People>(sqlPage, new { pageIndex = 2, pageSize = 10 });
            //foreach (var people in peoples)
            //{
            //    Console.WriteLine($"Id:{people.Id}");
            //}

            //查询单个或者默认数据
            //string sqlQueryFirst = "select * from People where id=@id";
            //People people = DapperHelper.QueryFirst<People>(sqlQueryFirst, new { id = 60 });
            //Console.WriteLine(people.Id);

            //存储过程
            //DapperHelper.ExecuteStoredProcedure("insetpeople", new { name = "JAAAJJJ", old = 222 });
        }
    }
}
