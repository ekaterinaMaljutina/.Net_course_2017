using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class BeforeMethodTest
    {
       
        private static readonly Dictionary<string, string> _expected = 
            new Dictionary<string, string>();


        static BeforeMethodTest()
        {
            _expected.Add("TestMethodOne", Utils.SUCCESS);
            _expected.Add("TestMethodTwo", Utils.SUCCESS);
            _expected.Add("Test", Utils.SUCCESS);           
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/BeforeTestMethod.dll";
            Utils.LoadTest(pathToDLL, _expected);
        }
    }
}

