using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using MyUnit.CustomAttributes;
using NUnit.Framework;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public static class Utils
    {
        public readonly static string SUCCESS = "SUCCESS";
        public readonly static string FAIL = "FAIL";
        public readonly static string IGNORE = "IGNORE";

        public readonly static Regex _regex = new Regex(
                                                  @"Test: ([\d|\w|\s|\.]+)\s+\b(SUCCESS|FAIL|IGNORE)\b\s+([\w|\d|\s|\:]*)", RegexOptions.IgnoreCase);

        public static void parseLog(string input, out Dictionary<string,tuple> dict)
        {
            var lines = input.Split('\n');
            var result = new   Dictionary<string, Tuple<string, string>>();
            foreach (string line in lines)
            {
                var match = Utils._regex.Match(line);
                if (match.Success)
                {
                    var nameMethod = match.Groups[1].Value;
                    var status = match.Groups[2].Value;
                    var info = match.Groups[3].Value;
                    result.Add(nameMethod, new Tuple<string, string>(status, info));
                    //Console.WriteLine (@"nameMethod {0}, status {1}, info {2}", nameMethod, status, info);
                } 
            }
            dict = result;
        }

        public static void Check(Dictionary<string,tuple> result, Dictionary<string,tuple> expected)
        {
            foreach (KeyValuePair<string, tuple> kvp in result)
            {
                var nameMethod = kvp.Key.Split('.').Last().Replace(" ", String.Empty);

                Assert.IsTrue(expected.ContainsKey(nameMethod));
                Assert.AreEqual(expected[nameMethod].Item1, kvp.Value.Item1);
                if (kvp.Value.Item1 == IGNORE)
                {
                    Assert.IsTrue(kvp.Value.Item2.Contains(expected[nameMethod].Item2));
                }

            }
        }

        public static void LoadTest(string pathToDLL, Dictionary<string, tuple> expected)
        {
            var consoleOut = Console.Out;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var loadAssembly = new LoadAssembly();
                loadAssembly.ExecuteTest(pathToDLL);

                Dictionary<string, tuple> result;

                Console.SetOut(consoleOut);

                Utils.parseLog(sw.ToString(), out result);
                Utils.Check(result, expected);
            }
        }
    }
}

