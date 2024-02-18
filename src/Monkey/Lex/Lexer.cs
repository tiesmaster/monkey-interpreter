// Ignore Spelling: Lexer

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
        Token tok;
        switch (_ch)
        {
            case (byte)'=':
                tok = new(Tokens.Assign, _ch);
                break;
            case (byte)'+':
                tok = new(Tokens.Plus, _ch);
                break;
            case (byte)'-':
                tok = new(Tokens.Minus, _ch);
                break;
            case (byte)'!':
                tok = new(Tokens.Bang, _ch);
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
                if (IsLetter(_ch))
                {
                    var literal = ReadIdentifier();
                    tok = new(LookupIdentifier(literal), literal);
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

    private string LookupIdentifier(string literal)
    {
        var keywords = new Dictionary<string, string>
        {
            ["fn"] = Tokens.Function,
            ["let"] = Tokens.Let,
        };

        return keywords.TryGetValue(literal, out var tokenType)
            ? tokenType
            : Tokens.Ident;
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

        return _input[position..(_readPosition - 1)];
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
}