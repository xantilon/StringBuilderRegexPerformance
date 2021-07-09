using BenchmarkDotNet.Attributes;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace StringBuilderRegexPerformance
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    public class StringReplace
    {
        public StringReplace()
        {
            while(t.Length < 10 * 1024 * 1024)
            {
                t.Append(t1);
            }            
        }

        public string TestText => t.ToString();
        private StringBuilder t = new StringBuilder(t1);
        private const string t1 =@"
<!DOCTYPE html>
<html>
<head>
    <title>test</title>
</head>
<body>
    <div>
        <p><u>unterstrichen</u></p>
        <p>
            <b>fett</b><br />
            <strong>fett</strong> <BR /><br/>
            <strong>fett</strong> <br><br>
            <strong>fett</strong> <br>
        </p>
    </div>
</body>
</html>
";

        public Dictionary<string, string> map = new Dictionary<string, string> {
                { "<u>", "" },
                { "</u>", "" },
                { "<b>", ""},
                { "</b>", ""},
                { "<br />", " " },
                { "<BR />", "" }
            };


        [Benchmark]
        public string WithString()
        {
            string t = TestText;
            foreach (var i in map)
            {
                t = t.Replace(i.Key, i.Value);
            }
            return t;
        }

        [Benchmark]
        public string WithStringBuilder()
        {
            var sb = new StringBuilder(TestText);
            foreach (var i in map)
            {
                sb.Replace(i.Key, i.Value);
            }
            return sb.ToString();
        }

        [Benchmark]
        public string WithRegex()
        {
            string pattern = $"({string.Join('|', map.Keys)})";
            Regex rgx = new Regex(pattern);
            return rgx.Replace(TestText, m => map[m.Value]);
        }
    }
}
