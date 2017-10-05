using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace UnitTest
{

    using tuple = Tuple<string, string>;

    public class OnlyTestMethodTest
    {

        private static readonly Dictionary<string, tuple> _expected = 
            new Dictionary<string, tuple>();


        static OnlyTestMethodTest()
        {
            _expected.Add("simpleTestMethod", new tuple(Utils.SUCCESS, ""));
            _expected.Add("simpleSecondTestMethod", new tuple(Utils.SUCCESS, ""));
            _expected.Add("simpleIgnoreTest", new tuple(Utils.IGNORE, "Simple ingore test"));
            _expected.Add("expectedTest", new tuple(Utils.SUCCESS, ""));
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/TestMethodTest.dll";
            Utils.LoadTest(pathToDLL, _expected);

        }
    }
}

