using System;

namespace MyUnit.Annotation
{
    [AttributeUsage (AttributeTargets.Method)]
    public class Test:System.Attribute
    {
        public string Expected { set; get; }

        public string Ignore{ set; get; }
    }

    [AttributeUsage (AttributeTargets.Method)]
    public class Before:System.Attribute
    {

    }

    [AttributeUsage (AttributeTargets.Method)]
    public class After:System.Attribute
    {

    }

    [AttributeUsage (AttributeTargets.Method)]
    public class BeforeClass:System.Attribute
    {

    }

    [AttributeUsage (AttributeTargets.Method)]
    public class AfterClass:System.Attribute
    {

    }
}

