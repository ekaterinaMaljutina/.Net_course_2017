using System;
using MyUnit.CustomAttributes.Utils;

namespace TestMethodTest
{
    public class TestMethodTest
    {
        [Test]
        public void simpleTestMethod() {
            Console.WriteLine(@"RUN method simpleTestMethod");
            Assert.isTrue(true);
        }

        [Test]
        public void simpleSecondTestMethod() {
            Console.WriteLine(@"RUN method simpleSecondTestMethod");
        }

        [Test(Ignore = " Simple ingore test")]
        public void simpleIgnoreTest() {
            Assert.isTrue(false);
            Console.WriteLine(@" RUN IGNORE test");
        }

        [Test(Expected= "ArgumentNullException")]
        public void expectedTest() {
            throw new ArgumentNullException();
        }
            
    }
}

