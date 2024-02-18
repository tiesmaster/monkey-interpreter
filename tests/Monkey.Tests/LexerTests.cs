using Monkey.Lex;

namespace Monkey.Tests;

public class LexerTests
{
    [Fact]
    public void TestNextToken()
    {
        // arrange
        var input = "=+(){},;";
        ExpectedToken[] expectedTokens = [
            new (Tokens.Illegal, "=" ),
            ];

        var lexer = new Lexer(input);

        // act && assert
        foreach (var expectedToken in expectedTokens)
        {
            var token = lexer.NextToken();

            token.Type.Should().Be(expectedToken.ExpectedType);
            token.Literal.Should().Be(expectedToken.ExpectedLiteral);
        }
    }

    private record ExpectedToken(string ExpectedType, string ExpectedLiteral);
}