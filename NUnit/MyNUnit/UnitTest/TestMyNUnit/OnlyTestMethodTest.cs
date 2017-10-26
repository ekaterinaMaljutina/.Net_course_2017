using NUnit.Framework;
using System;
using System.Collections.Generic;


namespace UnitTest
{

    using tuple = Tuple<string, string>;

    public class OnlyTestMethodTest
    {

        private static readonly Dictionary<string, string> _expected = 
            new Dictionary<string, string>();


        static OnlyTestMethodTest()
        {
            _expected.Add("SimpleTestMethod", Utils.SUCCESS);
            _expected.Add("SimpleSecondTestMethod", Utils.SUCCESS);
            _expected.Add("SimpleIgnoreTest", Utils.IGNORE);
            _expected.Add("ExpectedTest", Utils.SUCCESS);
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/TestMethodTest.dll";
            Utils.LoadTest(pathToDLL, _expected);
        }
    }
}

