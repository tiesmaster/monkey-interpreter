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
                tok = new(Tokens.Assign, "=");
                break;
            default:
                tok = new(Tokens.Illegal, "ILLEGAL");
                break;
        }

        ReadChar();

        return tok;
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