using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class AfterClassMethodTest
    {
        private static readonly Dictionary<string, tuple> _expected = 
            new Dictionary<string, tuple>();


        static AfterClassMethodTest()
        {
            _expected.Add("TestMethod", new tuple(Utils.SUCCESS, "")); 
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/AfterClassMethodTest.dll";
            Utils.LoadTest(pathToDLL, _expected);

        }
    }
}