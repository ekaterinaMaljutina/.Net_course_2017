using System;
using System.IO;
using System.Linq;
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
            var files = Directory.GetFiles (args[0], "*.*", SearchOption.TopDirectoryOnly)
                .Where (s => s.EndsWith (".dll") || s.EndsWith (".exe"));
            foreach (string file in files) {
                loadAssembly.ExecuteTest (file);
            }
        }

        private static LoadAssembly NewMethod ()
        {
            return new LoadAssembly ();
        }
    }
}
