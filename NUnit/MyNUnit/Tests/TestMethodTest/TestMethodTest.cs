using System;
using Attributes.Annotation;
using Attributes.MyAssert;

namespace TestMethodTest
{
    using Assert = MyAssert;

    public class TestMethodTest
    {
        [Test]
        public void SimpleTestMethod()
        {
            Console.WriteLine(@"RUN method simpleTestMethod");
            Assert.IsTrue(true);
        }

        [Test]
        public void SimpleSecondTestMethod()
        {
            Console.WriteLine(@"RUN method simpleSecondTestMethod");
        }

        [Test(Ignore = true)]
        public void SimpleIgnoreTest()
        {
            Assert.IsTrue(false);
            Console.WriteLine(@" RUN IGNORE test");
        }

        [Test(Expected = "ArgumentNullException")]
        public void ExpectedTest()
        {
            throw new ArgumentNullException();
        }
            
    }
}

