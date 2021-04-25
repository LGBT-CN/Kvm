using System;
using System.Collections.Generic;

namespace Kvm.Analyser.Tokens
{
    public class ControlToken : IToken
    {
        private string _data;

        public string Data
        {
            get => _data ?? "";
            set => _data = value.Trim();
        }

        public TokenType Type => TokenType.Control;

        private void Parse()
        {
            throw new NotSupportedException();
        }

        public string Parse(Dictionary<string, string> prop)
        {
            if (prop.ContainsKey(Data))
                return prop[Data];
            Shared.Log.W("Cannot found prop: " + Data);
            return string.Empty;
        }
    }
}