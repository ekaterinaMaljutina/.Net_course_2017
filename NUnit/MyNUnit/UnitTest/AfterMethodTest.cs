using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class AfterMethodTest
    {
        private static readonly Dictionary<string, tuple> _expected = 
            new Dictionary<string, tuple>();


        static AfterMethodTest()
        {
            _expected.Add("Test", new tuple(Utils.SUCCESS, ""));
            _expected.Add("TestMethodOne", new tuple(Utils.SUCCESS, ""));
            _expected.Add("TestMethodTwo", new tuple(Utils.SUCCESS, ""));
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/AfterTestMethod.dll";
            Utils.LoadTest(pathToDLL, _expected);

        }
    }
}

