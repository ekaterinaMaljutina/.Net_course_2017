using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class BeforeClassMethodTest
    {
        private static readonly Dictionary<string, tuple> _expected = 
            new Dictionary<string, tuple>();


        static BeforeClassMethodTest()
        {
            _expected.Add("testMethod", new tuple(Utils.SUCCESS, ""));
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/BeforeClassMethodTest.dll";
            Utils.LoadTest(pathToDLL, _expected);

        }
    }
}

