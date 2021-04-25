using System;
using Kvm.Analyser;

namespace Kvm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string x = @"mmm
KKK=auhsbcj
A=CBA
D=";
            var d = Parser.SplitByFirstLine(x);
            Console.WriteLine("=====1=======");
            Console.WriteLine(d.Item1);
            Console.WriteLine("=====2=======");
            Console.WriteLine(d.Item2);
            Console.WriteLine("=====3=======");
            var dix = Parser.ParseKey(x);
            foreach (var kv in dix)
            {
                Console.WriteLine($"K->{kv.Key} && V->{kv.Value}");
            }
        }
    }
}