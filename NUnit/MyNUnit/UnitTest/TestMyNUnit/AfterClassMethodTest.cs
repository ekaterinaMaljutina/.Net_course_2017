using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class AfterClassMethodTest
    {
        private static readonly Dictionary<string, string> _expected = 
            new Dictionary<string, string>();


        static AfterClassMethodTest()
        {
            _expected.Add("TestMethod", Utils.SUCCESS); 
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/AfterClassMethodTest.dll";
            Utils.LoadTest(pathToDLL, _expected);
        }
    }
}