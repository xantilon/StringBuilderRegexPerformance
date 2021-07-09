using BenchmarkDotNet.Running;

namespace StringBuilderRegexPerformance
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<StringReplace>();
        }
    }
}
