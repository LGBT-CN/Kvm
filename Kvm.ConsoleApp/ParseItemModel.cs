using System.IO;
using Kvm.Analyser;

namespace Kvm.ConsoleApp
{
    public class ParseItemModel
    {
        public string ModelPath { get; init; }
        public string PropPath { get; init; }
        public string OutPath { get; init; }

        public void Parse()
        {
            var model = File.ReadAllText(ModelPath);
            var prop = File.ReadAllText(PropPath);
            var m = Parser.Parse(model, prop);
            File.WriteAllText(OutPath, m);
        }
    }
}