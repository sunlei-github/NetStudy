using AutofacIServices;
using System;

namespace AutofacServices
{
    public class TestBService : ITestBService
    {
        public void Show()
        {
            Console.WriteLine("TestBService");
        }
    }
}
