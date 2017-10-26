using NUnit.Framework;
using System;
using Attributes.MyAssert;
using Attributes.AssertException;

namespace TestAssert
{
    [TestFixture]
    public class TestAssert
    {
        [Test]
        public void TestIsTrue()
        {     
            Assert.IsTrue(MyAssert.IsTrue(true));
            Assert.IsTrue(MyAssert.IsTrue(1 == 1));
            Assert.IsTrue(MyAssert.IsTrue("a" == "a"));
        }

        [Test]
        public void TestIsFalse() 
        {
            Assert.IsTrue(MyAssert.IsFalse(false));
            Assert.IsTrue(MyAssert.IsFalse(1 == 2));
            Assert.IsTrue(MyAssert.IsFalse("a" == "b"));
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

