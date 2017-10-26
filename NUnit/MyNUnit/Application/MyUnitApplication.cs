using System;

using System.IO;
using System.Linq;

using Attributes.CustomAttributes;

namespace MyUnit.Application
{
    class MyUnitApplication
    {
        static void Main(string[] args)
        {
            var loadAssembly = NewMethod();
            if (args.Length < 1) 
            {
                Console.WriteLine(" not path to folder");
                return;
            }
            var files = Directory.GetFiles(args [0], "*.dll", SearchOption.TopDirectoryOnly)
                .Union(Directory.GetFiles(args [0], "*.exe", SearchOption.TopDirectoryOnly));
            foreach (string file in files) 
            {
                loadAssembly.ExecuteTest(file);
            }
        }

        private static LoadAssembly NewMethod()
        {
            return new LoadAssembly();
        }
    }
}
