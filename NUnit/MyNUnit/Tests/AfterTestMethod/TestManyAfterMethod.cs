using System;
using Attributes.Annotation;
using Attributes.MyAssert;

namespace AfterTestMethod
{
    using Assert = MyAssert;

    public class TestManyAfterMethod
    {
        private static readonly string VALUE_BEFORE = "before run";
        private static readonly string VALUE_AFTER = "after run";

        private string _value = VALUE_AFTER;

        [Before]
        public void BeforeTest()
        {
            Assert.Equal(VALUE_AFTER, _value);
            _value = VALUE_BEFORE;
        }

        [Test]
        public void TestMethodOne()
        {
            Assert.Equal(VALUE_BEFORE, _value);
            _value = null;
        }

        [Test]
        public void TestMethodTwo()
        {
            Assert.Equal(VALUE_BEFORE, _value);
            _value = null;
        }

        [After]
        public void AfterTest()
        {
            Assert.Equal(null, _value);
            _value = VALUE_AFTER;
        }
    }
}

