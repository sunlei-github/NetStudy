using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzServer
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomQuartz.Init().GetAwaiter().GetResult();

            Console.ReadLine();
        }
    }
}
