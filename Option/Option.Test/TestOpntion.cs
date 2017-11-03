using NUnit.Framework;
using System;
using MyOption;

namespace TestOption
{
    public class TestOption
    {

        [Test]
        public void CreateStringOptionTest()
        {
            var s = "string";
            var option = Option.Some(s);

            Assert.IsTrue(option.IsSome);
		
            Assert.AreEqual(s, option.Value);
        }

        [Test]
        public void InitValueTest()
        {
            var intValue = 1;
            var value = Option.Some(intValue);
            Assert.IsTrue(value.IsSome);
            Assert.AreEqual(intValue, value.Value);
        }

        [Test]
        [ExpectedException("MyOption.NotValueException")]
        public void InitNoneValue()
        {
            var value = Option.None<int>();
            Assert.IsFalse(value.IsSome);
            var val = value.Value;
        }

        [Test]
        public void MapIntTest()
        {
            var intValue = 2;
            var value = Option.Some(intValue);
            Assert.AreEqual(intValue, value.Value);

            Func<int, int> func = x => x * 2;

            value = value.Map(func);

            Assert.AreEqual(func(intValue), value.Value);
        }

        [Test]
        public void MapNoneTest()
        {
            Assert.AreEqual(Option<int>.None(), Option<int>.None().Map(x => x * 2));
        }

        [Test]
        public void MapStringTest()
        {
            var str = "aaabbbcccdg";
            var value = Option.Some(str);
            Assert.AreEqual(str, value.Value);

            Func<string, string> funcStr = x => x.Substring(x.IndexOf('b'));

            Func<string, int> func = x => funcStr(x).Length;

            var intOption = value.Map<int>(func);

            Assert.AreEqual(func(funcStr(str)), intOption.Value);
        }

        [Test]
        [ExpectedException("MyOption.NullValueException")]
        public void NullValueExcTest()
        {
            Option.Some<Object>(null);
        }

        [Test]
        public void FlattenSameTest()
        {
            var intValue = 2;
            var valueOpt = Option.Some(Option.Some(intValue));

            var value = Option<int>.Flatten(valueOpt);

            Assert.AreEqual(intValue, value.Value);
        }

        [Test]
        public void FlattenNoneTest()
        {

            var valueNone = Option<Option<string>>.None();
            var flatNone = Option<string>.Flatten(valueNone);
            Assert.IsTrue(flatNone.IsNone);
        }
      
    }
}

