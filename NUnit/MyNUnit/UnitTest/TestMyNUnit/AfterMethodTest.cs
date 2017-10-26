using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class AfterMethodTest
    {
        private static readonly Dictionary<string, string> _expected = 
            new Dictionary<string, string>();


        static AfterMethodTest()
        {
            _expected.Add("Test", Utils.SUCCESS);
            _expected.Add("TestMethodOne", Utils.SUCCESS);
            _expected.Add("TestMethodTwo", Utils.SUCCESS);
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/AfterTestMethod.dll";
            Utils.LoadTest(pathToDLL, _expected);
        }
    }
}

