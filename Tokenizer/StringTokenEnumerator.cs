using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Tokenizer
{
    public sealed class StringTokenEnumerator : IEnumerable
    {
        private readonly char[] _delimetrs = new char[]{  '=', '+', '-', '/', ',', '.', '*', '~',
                                         '!', '@', '#', '$', '%', '^', '&', '(', ')',
                                         '{', '}', '[', ']', ':', ';', '<', '>', '?', '|', '\\'};
        private readonly string Data;
        private readonly int MinTokenSize;
        public StringTokenEnumerator(string data, int minTokenLength = 1)
        => (Data, MinTokenSize) = (data, minTokenLength);

        public IEnumerator<Token> GetEnumerator()
        {
            if (Data.Length > 0)
            {
                var pool = new List<char>();
                var type = GetCharType(Data[0]);

                for (int i = 0; i < Data.Length; i++)
                {
                    var charType = GetCharType(Data[i]);

                    if (i > 0 && charType != type)
                    {
                        if (pool.Count >= MinTokenSize)
                        {
                            yield return new Token(new string(pool.ToArray()), type); 
                        }
                        pool.Clear();
                    }

                    pool.Add(Data[i]);
                    type = charType;
                } 

                yield return new Token(new string(pool.ToArray()), type);
            }
        }

        internal TokenType GetCharType(char c)
        {
            var type = TokenType.Unknown;
            if (char.IsDigit(c))
            {
                type = TokenType.Number;
            }
            if (char.IsLetter(c))
            {
                type = TokenType.Word;
            }
            if (char.IsPunctuation(c) || IsSymbol(c) || char.IsSymbol(c))
            {
                type = TokenType.Symbol;
            }
            if (char.IsWhiteSpace(c))
            {
                type = TokenType.WhiteSpace;
            }
            return type;
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        internal bool IsSymbol(char c)
        {
            for (int i = 0; i < _delimetrs.Length; i++)
                if (_delimetrs[i] == c)
                    return true;
            return false;
        }

    }

}
