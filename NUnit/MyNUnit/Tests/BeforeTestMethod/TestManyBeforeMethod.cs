using System;
using MyUnit.CustomAttributes.Utils;

namespace BeforeTestMethod
{
    public class TestManyBeforeMethod
    {
        private static string VALUE_BEFORE = "before run";

        private string _value = null;

        [Before]
        public void BeforeTest() {
            Assert.Equal(null, _value);
            _value = VALUE_BEFORE;
        }

        [Test]
        public void TestMethodOne() {
            Assert.Equal(VALUE_BEFORE, _value);
            _value = null;
        }

        [Test]
        public void TestMethodTwo() {
            Assert.Equal(VALUE_BEFORE, _value);
            _value = null;
        }


    }
}

