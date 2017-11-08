using System;
using MyUnit.CustomAttributes.Utils;

namespace Tests
{
	
	public class PerformTest
	{
		[BeforeClass]
		public void Before_Class()
		{
			Console.WriteLine(@" 		before class 1 ...");
		}

		[BeforeClass]
		public void Before_1_Class()
		{
			Console.WriteLine(@" 		before class 2 ...");
		}


		[AfterClass]
		public void After_1_Class()
		{
			Console.WriteLine(@" 		ather class 1 ...");
		}

		[AfterClass]
		public void After_2_Class()
		{
			Console.WriteLine(@" 		ather class 2 ...");
		}


		[Before]
		public void Before_Test()
		{
			Console.WriteLine(@" 		before test  1 .... ");
		}


		[Before]
		public void Before_2_Test()
		{
			Console.WriteLine(@" 		before test  2 .... ");
		}


		[After]
		public void After_Test()
		{
			Console.WriteLine(@" 		aftre test .... ");
		}


		[After]
		public void After_2_Test()
		{
			Console.WriteLine(@" 		aftre test 2 .... ");
		}

		[Test]
		public void Test_success()
		{
			var a = 2;
			var b = 2;
			Assert.isFalse(a != b);
		}

		[Test(Ignore = " ignore test")]
		public void IgnoreTest()
		{
			Console.WriteLine(@" 		opps... ignore test");
		}

		[Test(Expected = "NullReferenceException")]
		public void ExpectedTest()
		{
			throw new NullReferenceException();
		}

		[Test]
		public void Test_fail()
		{
			var a = 2;
			var b = 3;
			Assert.isFalse(a != b);
		}
	}
}
