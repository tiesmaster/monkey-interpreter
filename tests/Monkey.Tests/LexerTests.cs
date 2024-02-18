// Ignore Spelling: Lexer

using Monkey.Lex;

namespace Monkey.Tests;

public class LexerTests
{
    [Fact]
    public void TestNextToken()
    {
        // arrange
        var input = """
            let five = 5;
            let ten = 10;

            let add = fn(x, y) {
              x + y;
            };

            let result = add(five, ten);
            !-/*5;
            5 < 10 > 5;

            if (5 < 10) {
                return true;
            } else {
                return false;
            }

            10 == 10;
            10 != 9;
            """;

        Token[] expectedTokens = [
            new (Tokens.Let, "let" ),
            new (Tokens.Ident, "five" ),
            new (Tokens.Assign, "=" ),
            new (Tokens.Int, "5" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.Let, "let" ),
            new (Tokens.Ident, "ten" ),
            new (Tokens.Assign, "=" ),
            new (Tokens.Int, "10" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.Let, "let" ),
            new (Tokens.Ident, "add" ),
            new (Tokens.Assign, "=" ),
            new (Tokens.Function, "fn" ),
            new (Tokens.LParen, "(" ),
            new (Tokens.Ident, "x" ),
            new (Tokens.Comma, "," ),
            new (Tokens.Ident, "y" ),
            new (Tokens.RParen, ")" ),
            new (Tokens.LBrace, "{" ),
            new (Tokens.Ident, "x" ),
            new (Tokens.Plus, "+" ),
            new (Tokens.Ident, "y" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.RBrace, "}" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.Let, "let" ),
            new (Tokens.Ident, "result" ),
            new (Tokens.Assign, "=" ),
            new (Tokens.Ident, "add" ),
            new (Tokens.LParen, "(" ),
            new (Tokens.Ident, "five" ),
            new (Tokens.Comma, "," ),
            new (Tokens.Ident, "ten" ),
            new (Tokens.RParen, ")" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.Bang, "!" ),
            new (Tokens.Minus, "-" ),
            new (Tokens.Slash, "/" ),
            new (Tokens.Asterisk, "*" ),
            new (Tokens.Int, "5" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.Int, "5" ),
            new (Tokens.Lt, "<" ),
            new (Tokens.Int, "10" ),
            new (Tokens.Gt, ">" ),
            new (Tokens.Int, "5" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.If, "if" ),
            new (Tokens.LParen, "(" ),
            new (Tokens.Int, "5" ),
            new (Tokens.Lt, "<" ),
            new (Tokens.Int, "10" ),
            new (Tokens.RParen, ")" ),
            new (Tokens.LBrace, "{" ),
            new (Tokens.Return, "return" ),
            new (Tokens.True, "true" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.RBrace, "}" ),
            new (Tokens.Else, "else" ),
            new (Tokens.LBrace, "{" ),
            new (Tokens.Return, "return" ),
            new (Tokens.False, "false" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.RBrace, "}" ),
            new (Tokens.Int, "10" ),
            new (Tokens.Eq, "==" ),
            new (Tokens.Int, "10" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.Int, "10" ),
            new (Tokens.NotEq, "!=" ),
            new (Tokens.Int, "9" ),
            new (Tokens.Semicolon, ";" ),
            new (Tokens.Eof, "" ),
            ];

        var lexer = new Lexer(input);

        // act && assert
        foreach (var expectedToken in expectedTokens)
        {
            var token = lexer.NextToken();

            token.Should().BeEquivalentTo(expectedToken);

            //token.Type.Should().Be(expectedToken.ExpectedType);
            //token.Literal.Should().Be(expectedToken.ExpectedLiteral);
        }
    }

    //private record ExpectedToken(string ExpectedType, string ExpectedLiteral);
}