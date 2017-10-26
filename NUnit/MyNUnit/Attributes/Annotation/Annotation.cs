using System;

namespace Attributes.Annotation
{
    [AttributeUsage (AttributeTargets.Method)]
    public class Test: Attribute
    {
        public string Expected { get; set; }

        public bool Ignore { get; set; }
    }

    [AttributeUsage (AttributeTargets.Method)]
    public class Before: Attribute
    {
    }

    [AttributeUsage (AttributeTargets.Method)]
    public class After: Attribute
    {
    }

    [AttributeUsage (AttributeTargets.Method)]
    public class BeforeClass: Attribute
    {
    }

    [AttributeUsage (AttributeTargets.Method)]
    public class AfterClass: Attribute
    {
    }
}

