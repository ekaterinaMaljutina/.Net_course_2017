using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class OtherTest
    {
        private static readonly Dictionary<string, string> _expected = 
            new Dictionary<string, string>();


        static OtherTest()
        {
            _expected.Add("SimpleIgnoreTest", Utils.IGNORE);
            _expected.Add("CheckLoadedInBeforetestVarTest", Utils.SUCCESS);
            _expected.Add("Test_success", Utils.SUCCESS);
            _expected.Add("IgnoreTest", Utils.IGNORE);
            _expected.Add("ExpectedTest", Utils.SUCCESS);
            _expected.Add("Test_fail", Utils.FAIL);
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/TestDll.dll";
            Utils.LoadTest(pathToDLL, _expected);    
        }
    }
}

