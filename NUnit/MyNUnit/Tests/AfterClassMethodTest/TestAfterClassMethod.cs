using System;
using Attributes.Annotation;
using Attributes.MyAssert;

namespace AfterClassMethodTest
{
    using Assert = MyAssert;

    public class TestAfterClassMethod
    {

        private object _value = null;

        [BeforeClass]
        public void BeforeClassMethod()
        {
            Assert.Equal(null, _value);
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
        public void TestMethod()
        {
            Assert.NotEqual(null, _value as Test);
            _value = new Random();
        }

        [After] 
        public void AfterTest()
        {
            Assert.NotEqual(null, _value as Random);
            _value = new Test();
        }

        [AfterClass]
        public void AfterClassMethod()
        {
            Assert.NotEqual(null, _value as Test);
        }
    }
}

