using System;
using MyUnit.CustomAttributes.Utils;

namespace AfterTestMethod
{
    public class TestManyAfterMethod
    {
        private static readonly string VALUE_BEFORE = "before run";
        private static readonly string VALUE_AFTER = "after run";

        private string value = VALUE_AFTER;

        [Before]
        public void BeforeTest() {
            Assert.Equal(VALUE_AFTER, value);
            value = VALUE_BEFORE;
        }

        [Test]
        public void TestMethodOne() {
            Assert.Equal(VALUE_BEFORE, value);
            value = null;
        }

        [Test]
        public void TestMethodTwo() {
            Assert.Equal(VALUE_BEFORE, value);
            value = null;
        }

        [After]
        public void AfterTest() {
            Assert.Equal(null, value);
            value = VALUE_AFTER;
        }
    }
}

