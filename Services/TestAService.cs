using AutofacIServices;
using System;

namespace AutofacServices
{
    public class TestAService : ITestAService
    {
        public void Show()
        {
            Console.WriteLine("TestAService");
        }
    }
}
