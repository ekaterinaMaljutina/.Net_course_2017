using System;
using Attributes.Annotation;
using Attributes.MyAssert;

namespace Tests
{
    using Assert = MyAssert;

    public sealed class Value
    {
        public string Val { get; }

        public Value(string val)
        {
            this.Val = val;
        }
    }

    public class Test2
    {
        
        private static readonly string _valueString = "aaa";

        private static Value _value { set; get; }

        [Test(Ignore = true)]
        public void SimpleIgnoreTest()
        {
            Assert.IsTrue(false);
        }

        [BeforeClass]
        public void BeforeClassVarIsNullTest()
        {
            Assert.Equal(_value, null);
        }

        [Before]
        public void BeforeSetVarValueTest()
        {
            _value = new Value(_valueString);
            Console.WriteLine(" run before method");
            Assert.Equal(null, _value);
            Assert.Equal(_valueString, _value.Val);
        }

        [Test]
        public void CheckLoadedInBeforetestVarTest()
        {
            Assert.NotEqual(null, _value);
            Assert.Equal(_valueString, _value.Val);
        }

        [After]
        public void AftherTest()
        {
            Console.WriteLine(" run after method");
            _value = null;
        }

        [AfterClass]
        public void AfterClassCheckInNullVarTest()
        {
            Assert.Equal(_value, null);
        }
    }
}