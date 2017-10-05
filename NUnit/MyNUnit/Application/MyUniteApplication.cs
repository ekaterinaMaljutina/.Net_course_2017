using System;
using System.IO;
using MyUnit.CustomAttributes;


namespace MyUnit.Application
{
    class MyUniteApplication
    {
        static void Main (string[] args)
        {
            var loadAssembly = NewMethod ();
            if (args.Length < 1) {
                Console.WriteLine (" not path to folder");
                return;
            }
            foreach (string file in Directory.GetFiles(@args[0], "*.dll")) {
                loadAssembly.ExecuteTest (file);
            }
        }

        private static LoadAssembly NewMethod ()
        {
            return new LoadAssembly ();
        }
    }
}
