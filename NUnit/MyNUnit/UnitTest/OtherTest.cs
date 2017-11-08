using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class OtherTest
    {
        private static readonly Dictionary<string, tuple> _expected = 
            new Dictionary<string, tuple>();


        static OtherTest()
        {
            _expected.Add("simpleIgnoreTest", new tuple(Utils.IGNORE, " simple ignore"));
            _expected.Add("checkLoadedInBeforetestVarTest", new tuple(Utils.SUCCESS, ""));
            _expected.Add("Test_success", new tuple(Utils.SUCCESS, ""));
            _expected.Add("IgnoreTest", new tuple(Utils.IGNORE, " ignore test"));
            _expected.Add("ExpectedTest", new tuple(Utils.SUCCESS, ""));
            _expected.Add("Test_fail", new tuple(Utils.FAIL, ""));
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/TestDll.dll";
            Utils.LoadTest(pathToDLL, _expected);

        }
    }
}

