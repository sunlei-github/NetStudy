using AutofacIServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutofacServices
{
    public class TestService : ITestService
    {
        private readonly ITestAService _testAService=null;
        public ITestCService TestCService { set; get; }
        public TestService(ITestAService testAService)
        {
            _testAService = testAService;
        }

        public void Show()
        {
            Console.WriteLine("TestService");
            _testAService.Show();
            TestCService.Show();
        }

        public string TestAop(string name, string pwd)
        {
            return name + pwd;
        }
    }
}
