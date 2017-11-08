using System;
using MyUnit.CustomAttributes.Utils;

namespace AfterClassMethodTest
{
    public class TestAfterClassMethod
    {

        private Object _value = null;

        [BeforeClass]
        public void BeforeClassMethod() {
            Assert.Equal(null, _value);
            _value = new Test();
        }

        [Before]
        public void BeforeMethod() {
            if (_value == null)
            {
                _value = new Random();
            }
        }

        [Test]
        public void TestMethod() {
            Assert.isTrue( (_value as Test) != null);
            _value = new Random();
        }

        [After] 
        public void AfterTest() {
            Assert.isTrue( (_value as Random) != null);
            _value = new Test();
        }

        [AfterClass]
        public void AfterClassMethod() {
            Assert.isTrue( (_value as Test) != null);
        }


    }

}

