// Ignore Spelling: Lexer


using System.Text;

namespace Monkey.Lex;

public class Lexer
{
    private readonly string _input;

    private int _position;
    private int _readPosition;
    private byte _ch;

    public Lexer(string input)
    {
        _input = input;

        ReadChar();
    }

    public Token NextToken()
    {
        SkipWhitespace();

        Token tok;
        switch (_ch)
        {
            case (byte)'=':
                if (PeekChar() == '=')
                {
                    var ch = _ch;
                    ReadChar();
                    var literal = Encoding.ASCII.GetString([ch, _ch]);
                    tok = new Token(Tokens.Eq, literal);
                }
                else
                {
                    tok = new(Tokens.Assign, _ch);
                }
                break;
            case (byte)'+':
                tok = new(Tokens.Plus, _ch);
                break;
            case (byte)'-':
                tok = new(Tokens.Minus, _ch);
                break;
            case (byte)'!':
                if (PeekChar() == '=')
                {
                    var ch = _ch;
                    ReadChar();
                    var literal = Encoding.ASCII.GetString([ch, _ch]);
                    tok = new Token(Tokens.NotEq, literal);
                }
                else
                {
                    tok = new(Tokens.Bang, _ch);
                }
                break;
            case (byte)'/':
                tok = new(Tokens.Slash, _ch);
                break;
            case (byte)'*':
                tok = new(Tokens.Asterisk, _ch);
                break;
            case (byte)'<':
                tok = new(Tokens.Lt, _ch);
                break;
            case (byte)'>':
                tok = new(Tokens.Gt, _ch);
                break;
            case (byte)';':
                tok = new(Tokens.Semicolon, _ch);
                break;
            case (byte)',':
                tok = new(Tokens.Comma, _ch);
                break;
            case (byte)'{':
                tok = new(Tokens.LBrace, _ch);
                break;
            case (byte)'}':
                tok = new(Tokens.RBrace, _ch);
                break;
            case (byte)'(':
                tok = new(Tokens.LParen, _ch);
                break;
            case (byte)')':
                tok = new(Tokens.RParen, _ch);
                break;
            case 0:
                tok = new(Tokens.Eof, "");
                break;
            default:
                if (IsInteger(_ch))
                {
                    var literal = ReadInteger();
                    return new(Tokens.Int, literal);
                }
                else if (IsLetter(_ch))
                {
                    var literal = ReadIdentifier();
                    return new(LookupIdentifier(literal), literal);
                }
                else
                {
                    tok = new(Tokens.Illegal, "ILLEGAL");
                }
                break;
        }

        ReadChar();
        return tok;
    }

    private void SkipWhitespace()
    {
        while (IsWhitespace(_ch))
        {
            ReadChar();
        }
    }

    private bool IsWhitespace(byte ch)
    {
        return ch == ' ' || ch == '\t' ||
            ch == '\r' || ch == '\n';
    }

    private string LookupIdentifier(string literal)
    {
        var keywords = new Dictionary<string, string>
        {
            ["fn"] = Tokens.Function,
            ["let"] = Tokens.Let,
            ["if"] = Tokens.If,
            ["else"] = Tokens.Else,
            ["return"] = Tokens.Return,
            ["true"] = Tokens.True,
            ["false"] = Tokens.False,
        };

        return keywords.TryGetValue(literal, out var tokenType)
            ? tokenType
            : Tokens.Ident;
    }

    private bool IsInteger(byte ch)
    {
        return '0' <= ch && ch <= '9';
    }

    private string ReadInteger()
    {
        var position = _position;
        while (IsInteger(_ch))
        {
            ReadChar();
        }

        return _input[position.._position];
    }

    private bool IsLetter(byte ch)
    {
        return ('a' <= ch && ch <= 'z') ||
            ('A' <= ch && ch <= 'Z') ||
            ch == '_';
    }

    private string ReadIdentifier()
    {
        var position = _position;
        while (IsLetter(_ch))
        {
            ReadChar();
        }

        return _input[position.._position];
    }

    private void ReadChar()
    {
        if (_readPosition >= _input.Length)
        {
            _ch = 0;
        }
        else
        {
            _ch = (byte)_input[_readPosition];
        }

        _position = _readPosition;
        _readPosition++;
    }

    private byte PeekChar()
    {
        if (_readPosition >= _input.Length)
        {
            return 0;
        }
        else
        {
            return (byte)_input[_readPosition];
        }
    }
}