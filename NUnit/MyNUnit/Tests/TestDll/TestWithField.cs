using System;
using MyUnit.CustomAttributes.Utils;

namespace Tests
{
	partial class Value
	{
		public string val { get; }

		public Value(string val)
		{
			this.val = val;
		}
	}

	public class Test2
	{
        
		private static readonly string _valueString = "aaa";

		private static Value _value { set; get; }

		[Test(Ignore = " simple ignore")]
		public void simpleIgnoreTest()
		{
			Assert.isTrue(false);
		}

		[BeforeClass]
		public void beforeClassVarIsNullTest()
		{
			Assert.Equal(_value, null);
		}

		[Before]
		public void beforeSetVarValueTest()
		{
			_value = new Value(_valueString);
			Console.WriteLine(" run before method");
			Assert.isFalse(_value == null);
			Assert.Equal(_valueString, _value.val);
		}

		[Test]
		public void checkLoadedInBeforetestVarTest()
		{
			Assert.isTrue(_value != null);
			Assert.Equal(_valueString, _value.val);
		}

		[After]
		public void aftherTest()
		{
			Console.WriteLine(" run after method");
			_value = null;
		}

		[AfterClass]
		public void afterClassCheckInNullVarTest()
		{
			Assert.Equal(_value, null);
		}
	}
}