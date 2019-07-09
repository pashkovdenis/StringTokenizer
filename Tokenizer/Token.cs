using System;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer
{
    public readonly struct Token
    {
        public Token(string word, TokenType type) => (WordOrSymbol, Type) = (word.Trim(), type);
        public string WordOrSymbol { get; }
        public TokenType Type { get; }
        public override string ToString() => $"{WordOrSymbol} - {Enum.GetName(Type.GetType(), Type)}";
    } 
}
