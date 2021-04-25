using System.Collections.Generic;
using System.IO;
using System.Text;
using Kvm.Analyser.Tokens;

namespace Kvm.Analyser
{
    public class Parser
    {
        public static (string, string) SplitByFirstLine(string str)
        {
            int index = str.IndexOf('\n');
            if (index < 0)
                return (str, null);
            return (str[..index], str[(index + 1) ..]);
        }

        public static Dictionary<string, string> ParseKey(string str)
        {
            var s = str.Split('\n');
            Dictionary<string, string> dic = new();
            foreach (var ss in s)
            {
                var m = ss.Trim();
                if (string.IsNullOrEmpty(m))
                    continue;
                if (m.StartsWith("#"))
                    continue;
                var index = m.IndexOf('=');
                if (index < 0)
                {
                    Shared.Log.W($"Cannot parse info: {ss}");
                    continue;
                }

                dic.Add(m[..index].Trim(), m[(index + 1)..].Trim());
            }

            Shared.Log.S("Parse prop successfully!");

            return dic;
        }

        public static string Parse(string str)
        {
            var m = SplitByFirstLine(str);
            if (string.IsNullOrWhiteSpace(m.Item2))
                return Parse(str, "");
            if (!m.Item1.StartsWith("#using"))
                return Parse(str, "");
            var i = File.ReadAllText(str[6..].Trim());
            return Parse(m.Item2, i);
        }

        public static string Parse(string kvm, string prop)
            => Parse(kvm, ParseKey(prop));


        public static string Parse(string kvm, Dictionary<string, string> prop)
        {
            StringBuilder sb = new();
            var m = Lexer.Parse(kvm);
            foreach (var i in m)
            {
                sb.Append(i.Type switch
                {
                    TokenType.Unknown or TokenType.Block => i.Data,
                    TokenType.Control => ((ControlToken) i).Parse(prop),
                    _ => ""
                });
            }

            return sb.ToString();
        }
    }
}