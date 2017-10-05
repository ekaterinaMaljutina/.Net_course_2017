using NUnit.Framework;
using System;
using MyUnit.MyAssert;
using MyUnit.AssertException;

namespace TestAssert
{
    [TestFixture]
    public class TestAssert
    {
        [Test]
        public void TestIsTrue()
        {     
            Assert.IsTrue(MyAssert.isTrue(true));
            Assert.IsTrue(MyAssert.isTrue(1 == 1));
            Assert.IsTrue(MyAssert.isTrue("a" == "a"));
        }

        [Test]
        public void TestIsFalse() 
        {
            Assert.IsTrue(MyAssert.isFalse(false));
            Assert.IsTrue(MyAssert.isFalse(1 == 2));
            Assert.IsTrue(MyAssert.isFalse("a" == "b"));
        }

        [Test]
        public void TestEqual() 
        {
            Assert.IsTrue(MyAssert.Equal("a", "a"));
            Assert.IsTrue(MyAssert.Equal(1, 1));
                       
        }
        [Test]
        [ExpectedException(typeof(MyAssertException))]
        public void TestEqulsWithFail()
        {
            MyAssert.Equal("b", "c");
        }

        [Test]
        public void TestNotEqual()
        {
            Assert.IsTrue(MyAssert.NotEqual("a", "b"));
            Assert.IsTrue(MyAssert.NotEqual(1, 2));
        }
    }
}

