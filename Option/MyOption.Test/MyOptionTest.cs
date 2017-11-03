using NUnit.Framework;
using System;
using MyOption.OptionImpl;
using MyOption.MyException;

namespace MyOption.Test
{
    public class MyOptionTest
    {
        [Test]
        public void CreateStringOptionTest()
        {
            const string s = "string";
            var option = Option.Some(s);

            Assert.IsTrue(option.IsSome);

            Assert.AreEqual(s, option.Value);
        }

        [Test]
        public void InitValueTest()
        {
            const int intValue = 1;
            var value = Option.Some(intValue);
            Assert.IsTrue(value.IsSome);
            Assert.AreEqual(intValue, value.Value);
        }

        [Test]
        public void InitNoneValue()
        {
            var value = Option.None<int>();
            Assert.IsFalse(value.IsSome);
            Assert.Throws<NotValueException>(() =>
            {
                var unused = value.Value;
            });
        }

        [Test]
        public void MapIntTest()
        {
            const int intValue = 2;
            var value = Option.Some(intValue);
            Assert.AreEqual(intValue, value.Value);

            Func<int, int> func = x => x * 2;

            value = value.Map(func);

            Assert.AreEqual(func(intValue), value.Value);
        }

        [Test]
        public void MapNoneTest()
        {
            Assert.AreEqual(Option<int>.None, Option<int>.None.Map(x => x * 2));
        }

        [Test]
        public void MapStringTest()
        {
            const string str = "aaabbbcccdg";
            var value = Option.Some(str);
            Assert.AreEqual(str, value.Value);

            Func<string, string> funcStr = x => x.Substring(x.IndexOf('b'));

            Func<string, int> func = x => funcStr(x).Length;

            var intOption = value.Map(func);

            Assert.AreEqual(func(funcStr(str)), intOption.Value);
        }

        [Test]
        public void NullValueExcTest()
        {
            Assert.Throws<NullValueException>(() => Option.Some<object>(null));
        }

        [Test]
        public void FlattenSameTest()
        {
            const int intValue = 2;
            var valueOpt = Option.Some(Option.Some(intValue));

            var value = Option<int>.Flatten(valueOpt);

            Assert.AreEqual(intValue, value.Value);
        }

        [Test]
        public void FlattenNoneTest()
        {
            var valueNone = Option<Option<string>>.None;
            var flatNone = Option<string>.Flatten(valueNone);
            Assert.IsTrue(flatNone.IsNone);
        }


        [Test]
        public void SomeEqualsSomeTest()
        {
            Assert.AreEqual(Option.Some(2).Map(x => x * 2), Option.Some(4));
        }

        [Test]
        public void SomeNotEqualsSomeTest()
        {
            Assert.AreNotEqual(Option<int>.Some(2).Map(x => x * 2), Option<int>.Some(3));
        }

        [Test]
        public void SomeEqualNoneTest()
        {
            Assert.AreEqual(Option<int>.None, Option<int>.None);
        }

        [Test]
        public void SomeNotEqualsNoneTest()
        {
            Assert.AreNotEqual(Option<int>.None, Option<int>.Some(4));
        }

        [Test]
        public void HashCodeTest()
        {
            Assert.IsTrue(Option<int>.Some(2).Map(x => x * 2).GetHashCode() ==
                          Option<int>.Some(4).GetHashCode());
        }

        [Test]
        public void NoneMapEqualsTest()
        {
            Assert.AreEqual(Option<int>.None, Option<int>.None.Map(x => x * 2));
        }

        [Test]
        public void MapAndFlateenTest()
        {
            var option = Option.Some(2);
            var optionInOption = Option<Option<int>>
                .Some(option)
                .Map(option1 => option1.Map(i => i * 2));
            Assert.AreEqual(option.Map(i => i * 2), Option<int>.Flatten(optionInOption));
        }

        [Test]
        public void MapNoneAndFlattenTest()
        {
            var optionNone = Option<int>.None;
            var optionInOption = Option<Option<int>>.Some(optionNone)
                .Map(option => option.Map(i => i * 2));
            Assert.AreEqual(optionNone, Option<int>.Flatten(optionInOption));
        }

        [Test]
        public void FlattenAndMapTest()
        {
            Assert.AreEqual(Option<int>.Some(10),
                Option<int>
                    .Flatten(Option<Option<int>>.Some(Option<int>.Some(5)))
                    .Map(i => i * 2));
        }
    }
}