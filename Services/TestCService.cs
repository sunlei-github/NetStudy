using AutofacIServices;
using System;

namespace AutofacServices
{
    public class TestCService : ITestCService
    {
        public void Show()
        {
            Console.WriteLine("TestCService");
        }
    }
}
