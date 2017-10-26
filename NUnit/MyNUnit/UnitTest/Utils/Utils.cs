using System;

using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using Attributes.CustomAttributes;
using NUnit.Framework;

namespace UnitTest
{
    using tuple = Tuple<string, string>;

    public static class Utils
    {
        public static readonly string SUCCESS = "SUCCESS";
        public static readonly string FAIL = "FAIL";
        public static readonly string IGNORE = "IGNORE";
       
        private static readonly Regex _regex = new Regex(
                                                   @"Test: ([\d|\w|\s|\.]+)\s+\b(SUCCESS|FAIL|IGNORE)\b\s+([\w|\d|\s|\:\.]*)", RegexOptions.IgnoreCase);

        public static void LoadTest(string pathToDLL, Dictionary<string, string> expected)
        {
            var consoleOut = Console.Out;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);

                var loadAssembly = new LoadAssembly();
                loadAssembly.ExecuteTest(pathToDLL);

                Dictionary<string, string> result;

                Console.SetOut(consoleOut);

                parseLog(sw.ToString(), out result);
                Check(result, expected);
            }
        }

        private static void parseLog(string input, out Dictionary<string, string> dict)
        {
            var lines = input.Split('\n');
            var result = new Dictionary<string, string>();
            foreach (var line in lines)
            {
                var match = _regex.Match(line);
                if (match.Success)
                {
                    if (match.Groups.Count < 4)
                    {
                        throw new ApplicationException(" match error groups ");
                    }
                    var nameMethod = match.Groups[1].Value;
                    var status = match.Groups[2].Value;
                    var info = match.Groups[3].Value;
                    result.Add(nameMethod, status);
//                    Console.WriteLine(@"nameMethod {0}, status {1}, info {2}", nameMethod, status, info);
                } 
            }
            dict = result;
        }

        private static void Check(Dictionary<string, string> result, Dictionary<string, string> expected)
        {   
            Assert.AreEqual(expected.Count, result.Count);
            foreach (var kvp in result)
            {
                var nameMethod = kvp.Key.Split('.').Last().Replace(" ", String.Empty);

                Assert.IsTrue(expected.ContainsKey(nameMethod));
                Assert.AreEqual(expected[nameMethod], kvp.Value);
            }
        }
    }
}

