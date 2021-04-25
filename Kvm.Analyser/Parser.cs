using System.Collections.Generic;
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

                dic.Add(m[..index], m[(index + 1)..]);
            }

            return dic;
        }

        public string Parse(string kvm, string prop)
            => Parse(kvm, ParseKey(prop));


        public string Parse(string kvm, Dictionary<string, string> prop)
        {
            StringBuilder sb = new();
            var m = Lexer.Parse(kvm);
            foreach (var i in m)
            {
                switch (i.Type)
                {
                    case TokenType.Unknown:
                    case TokenType.Block:
                        sb.Append(i.Data);
                        break;
                    case TokenType.Control:
                        lock (prop)
                        {
                            sb.Append(((ControlToken) i).Parse(prop));
                        }

                        break;
                }
            }

            return sb.ToString();
        }
    }
}