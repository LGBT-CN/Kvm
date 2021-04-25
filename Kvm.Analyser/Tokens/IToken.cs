namespace Kvm.Analyser.Tokens
{
    public interface IToken
    {
        public string Data { get; set; }

        public TokenType Type => TokenType.Unknown;
    }
}
