using System;
using MyUnit.CustomAttributes.Utils;

namespace BeforeClassMethodTest
{
    public class TestBeforeClassMethod
    {
        private Object _value = null;

        [BeforeClass]
        public void BeforeClassMethod()
        {
            _value = new Test();
        }

        [Before]
        public void BeforeMethod()
        {
            if (_value == null)
            {
                _value = new Random();
            }
        }

        [Test]
        public void testMethod()
        {
            Assert.isTrue((_value as Test) != null);
        }
    }
}

