// Ignore Spelling: Eof Ident Paren foobar Eq

using System.Text;

namespace Monkey.Lex;

public record Token(
    string Type,
    string Literal)
{
    public Token(string type, byte literal) : this(type, Encoding.ASCII.GetString([literal]))
    {
    }
}

public static class Tokens
{
    public const string Illegal = "ILLEGAL";
    public const string Eof = "EOF";

    // Identifiers + literals
    public const string Ident = "IDENT"; // add, foobar, x, y, ...
    public const string Int = "INT";   // 1343456

    // Operators
    public const string Assign = "=";
    public const string Plus = "+";
    public const string Minus = "-";
    public const string Bang = "!";
    public const string Asterisk = "*";
    public const string Slash = "/";

    public const string Lt = "<";
    public const string Gt = ">";

    public const string Eq = "==";
    public const string NotEq = "!=";

    // Delimiters
    public const string Comma = ",";
    public const string Semicolon = ";";

    public const string LParen = "(";
    public const string RParen = ")";
    public const string LBrace = "{";
    public const string RBrace = "}";

    // Keywords
    public const string Function = "FUNCTION";
    public const string Let = "LET";
    public const string True = "TRUE";
    public const string False = "FALSE";
    public const string If = "IF";
    public const string Else = "ELSE";
    public const string Return = "RETURN";
}