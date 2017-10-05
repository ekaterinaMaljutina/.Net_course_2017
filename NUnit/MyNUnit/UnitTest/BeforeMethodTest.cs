using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public class BeforeMethodTest
    {
       
        private static readonly Dictionary<string, tuple> _expected = 
            new Dictionary<string, tuple>();


        static BeforeMethodTest()
        {
            _expected.Add("TestMethodOne", new tuple(Utils.SUCCESS, ""));
            _expected.Add("TestMethodTwo", new tuple(Utils.SUCCESS, ""));
            _expected.Add("Test", new tuple(Utils.SUCCESS, ""));
           
        }

        [Test]
        public void TestMethodTest()
        {
            String pathToDLL = @"../../../Tests/DLL/BeforeTestMethod.dll";
            Utils.LoadTest(pathToDLL, _expected);

        }
    }
}

