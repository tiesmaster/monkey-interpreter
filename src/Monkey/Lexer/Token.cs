namespace Monkey.Lexer;

public record Token(
    string Type,
    string Literal);

public static class Tokens
{
    public const string Illegal = "ILLEGAL";
    public const string Eof = "EOF";
}