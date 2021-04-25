using System;
using System.IO;
using Kvm.Analyser;

namespace Kvm.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = File.ReadAllText("in\\model\\index.kvm");
            var prop = File.ReadAllText("in\\data\\zh.txt");
            var m = Parser.Parse(model, prop);
            File.WriteAllText("zh.html", m);

        }
    }
}