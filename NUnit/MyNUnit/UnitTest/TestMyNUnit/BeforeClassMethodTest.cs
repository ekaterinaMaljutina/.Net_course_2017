using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class BeforeClassMethodTest
    {
        private static readonly Dictionary<string, string> _expected = 
            new Dictionary<string, string>();


        static BeforeClassMethodTest()
        {
            _expected.Add("TestMethod", Utils.SUCCESS);
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/BeforeClassMethodTest.dll";
            Utils.LoadTest(pathToDLL, _expected);
        }
    }
}

