using AutofacIServices;
using System;

namespace AutofacServices
{
    public class TestDService : ITestDService
    {
        public void Show()
        {
            Console.WriteLine("TestDService");
        }
    }
}
