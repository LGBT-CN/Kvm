namespace Kvm.Analyser.Tokens
{
    public class BlockToken : IToken
    {
        public string Data { get; set; }
        public TokenType Type => TokenType.Block;
    }
}
