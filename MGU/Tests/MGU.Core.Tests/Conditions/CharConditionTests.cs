#pragma warning disable SA1500 // Braces for multi-line statements must not share line
namespace MGU.Core.Tests.Conditions
{
    using System.Collections.Generic;
    using Core.Extensions.Is;
    using Xunit;

    public class CharConditionTests
    {
        private static readonly IEnumerable<char> ControlChars =
            new[] { '\u0000', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\u0007', '\u0008', '\u0009', '\u000A', '\u000B', '\u000C', '\u000D', '\u000E',
                    '\u000F', '\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019', '\u001A', '\u001B', '\u001C', '\u001D',
                    '\u001E', '\u001F', '\u007F', '\u0080', '\u0081', '\u0082', '\u0083', '\u0084', '\u0085', '\u0086', '\u0087', '\u0088', '\u0089', '\u008A', '\u008B',
                    '\u008C', '\u008D', '\u008E', '\u008F', '\u0090', '\u0091', '\u0092', '\u0093', '\u0094', '\u0095', '\u0096', '\u0097', '\u0098', '\u0099', '\u009A',
                    '\u009B', '\u009C', '\u009D', '\u009E', '\u009F' };

        private static readonly IEnumerable<char> Digits = new[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        [Fact]
        public void Should_Return_True_When_Source_Is_Control_Char()
        {
            foreach (var source in ControlChars)
            {
                Assert.True(source.Is().Control);
            }
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Control_Char()
        {
            var source = '0';
            Assert.False(source.Is().Control);
            source = 'a';
            Assert.False(source.Is().Control);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Control_Char()
        {
            var source = '0';
            Assert.True(source.Is().Not.Control);
            source = 'a';
            Assert.True(source.Is().Not.Control);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Control_Char()
        {
            foreach (var source in ControlChars)
            {
                Assert.False(source.Is().Not.Control);
            }
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Digit_Char()
        {
            foreach (var source in Digits)
            {
                Assert.True(source.Is().Digit);
            }
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Digit_Char()
        {
            var source = 'a';
            Assert.False(source.Is().Digit);
            source = '\u0000';
            Assert.False(source.Is().Digit);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Digit_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Not.Digit);
            source = '\u0000';
            Assert.True(source.Is().Not.Digit);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Digit_Char()
        {
            foreach (var source in Digits)
            {
                Assert.False(source.Is().Not.Digit);
            }
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_High_Surrogate()
        {
            var source = '\uD800';
            Assert.True(source.Is().HighSurrogate);
            source = '\uDBFF';
            Assert.True(source.Is().HighSurrogate);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_High_Surrogate()
        {
            var source = 'a';
            Assert.False(source.Is().HighSurrogate);
            source = '\u0000';
            Assert.False(source.Is().HighSurrogate);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_High_Surrogate()
        {
            var source = 'a';
            Assert.True(source.Is().Not.HighSurrogate);
            source = '\u0000';
            Assert.True(source.Is().Not.HighSurrogate);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_High_Surrogate()
        {
            var source = '\uD800';
            Assert.False(source.Is().Not.HighSurrogate);
            source = '\uDBFF';
            Assert.False(source.Is().Not.HighSurrogate);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Letter_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Letter);
            source = 'A';
            Assert.True(source.Is().Letter);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Letter_Char()
        {
            var source = '\u0000';
            Assert.False(source.Is().Letter);
            source = '0';
            Assert.False(source.Is().Letter);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Letter_Char()
        {
            var source = '\u0000';
            Assert.True(source.Is().Not.Letter);
            source = '0';
            Assert.True(source.Is().Not.Letter);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Letter_Char()
        {
            var source = 'a';
            Assert.False(source.Is().Not.Letter);
            source = 'A';
            Assert.False(source.Is().Not.Letter);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Letter_Or_Digit_Char()
        {
            var sourceLetter = 'a';
            Assert.True(sourceLetter.Is().LetterOrDigit);
            sourceLetter = 'A';
            Assert.True(sourceLetter.Is().LetterOrDigit);

            foreach (var sourceDigit in Digits)
            {
                Assert.True(sourceDigit.Is().LetterOrDigit);
            }
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Letter_Or_Digit_Char()
        {
            var source = '\u0000';
            Assert.False(source.Is().LetterOrDigit);
            source = '+';
            Assert.False(source.Is().LetterOrDigit);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Letter_Or_Digit_Char()
        {
            var source = '\u0000';
            Assert.True(source.Is().Not.LetterOrDigit);
            source = '+';
            Assert.True(source.Is().Not.LetterOrDigit);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Letter_Or_Digit_Char()
        {
            var sourceLetter = 'a';
            Assert.False(sourceLetter.Is().Not.LetterOrDigit);
            sourceLetter = 'A';
            Assert.False(sourceLetter.Is().Not.LetterOrDigit);

            foreach (var sourceDigit in Digits)
            {
                Assert.False(sourceDigit.Is().Not.LetterOrDigit);
            }
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Lowercase_Letter_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Lower);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Lowercase_Letter_Char()
        {
            var source = 'A';
            Assert.False(source.Is().Lower);
            source = '0';
            Assert.False(source.Is().Lower);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Lowercase_Letter_Char()
        {
            var source = 'A';
            Assert.True(source.Is().Not.Lower);
            source = '0';
            Assert.True(source.Is().Not.Lower);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Lowercase_Letter_Char()
        {
            var source = 'a';
            Assert.False(source.Is().Not.Lower);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Low_Surrogate()
        {
            var source = '\uDC00';
            Assert.True(source.Is().LowSurrogate);
            source = '\uDFFF';
            Assert.True(source.Is().LowSurrogate);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Low_Surrogate()
        {
            var source = 'a';
            Assert.False(source.Is().LowSurrogate);
            source = '\u0000';
            Assert.False(source.Is().LowSurrogate);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Low_Surrogate()
        {
            var source = 'a';
            Assert.True(source.Is().Not.LowSurrogate);
            source = '\u0000';
            Assert.True(source.Is().Not.LowSurrogate);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Low_Surrogate()
        {
            var source = '\uDC00';
            Assert.False(source.Is().Not.LowSurrogate);
            source = '\uDFFF';
            Assert.False(source.Is().Not.LowSurrogate);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Number_Char()
        {
            var sourceLetterNumber = '\u16EE';
            Assert.True(sourceLetterNumber.Is().Number);

            foreach (var sourceDigit in Digits)
            {
                Assert.True(sourceDigit.Is().Number);
            }
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Number_Char()
        {
            var source = 'a';
            Assert.False(source.Is().Number);
            source = '\u0000';
            Assert.False(source.Is().Number);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Number_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Not.Number);
            source = '\u0000';
            Assert.True(source.Is().Not.Number);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Number_Char()
        {
            var sourceLetterNumber = '\u16EE';
            Assert.False(sourceLetterNumber.Is().Not.Number);

            foreach (var source in Digits)
            {
                Assert.False(source.Is().Not.Number);
            }
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Punctuation_Char()
        {
            var source = '.';
            Assert.True(source.Is().Punctuation);
            source = ',';
            Assert.True(source.Is().Punctuation);
            source = '!';
            Assert.True(source.Is().Punctuation);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Punctuation_Char()
        {
            var source = 'a';
            Assert.False(source.Is().Punctuation);
            source = '0';
            Assert.False(source.Is().Punctuation);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Punctuation_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Not.Punctuation);
            source = '0';
            Assert.True(source.Is().Not.Punctuation);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Punctuation_Char()
        {
            var source = '.';
            Assert.False(source.Is().Not.Punctuation);
            source = ',';
            Assert.False(source.Is().Not.Punctuation);
            source = '!';
            Assert.False(source.Is().Not.Punctuation);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Separator_Char()
        {
            var source = '\u0020';
            Assert.True(source.Is().Separator);
            source = '\u2029';
            Assert.True(source.Is().Separator);
            source = '\u3000';
            Assert.True(source.Is().Separator);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Separator_Char()
        {
            var source = 'a';
            Assert.False(source.Is().Separator);
            source = '0';
            Assert.False(source.Is().Separator);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Separator_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Not.Separator);
            source = '0';
            Assert.True(source.Is().Not.Separator);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Separator_Char()
        {
            var source = '\u0020';
            Assert.False(source.Is().Not.Separator);
            source = '\u2029';
            Assert.False(source.Is().Not.Separator);
            source = '\u3000';
            Assert.False(source.Is().Not.Separator);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Surrogate_Char()
        {
            var str = "\U00010F00";
            var source = str[0];
            Assert.True(source.Is().Surrogate);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Surrogate_Char()
        {
            var source = 'a';
            Assert.False(source.Is().Surrogate);
            source = '0';
            Assert.False(source.Is().Surrogate);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Surrogate_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Not.Surrogate);
            source = '0';
            Assert.True(source.Is().Not.Surrogate);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Surrogate_Char()
        {
            var str = "\U00010F00";
            var source = str[0];
            Assert.False(source.Is().Not.Surrogate);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Symbol_Char()
        {
            var source = '+';
            Assert.True(source.Is().Symbol);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Symbol_Char()
        {
            var source = 'a';
            Assert.False(source.Is().Symbol);
            source = '0';
            Assert.False(source.Is().Symbol);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Symbol_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Not.Symbol);
            source = '0';
            Assert.True(source.Is().Not.Symbol);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Symbol_Char()
        {
            var source = '+';
            Assert.False(source.Is().Not.Symbol);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Uppercase_Letter_Char()
        {
            var source = 'A';
            Assert.True(source.Is().Upper);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_Uppercase_Letter_Char()
        {
            var source = 'a';
            Assert.False(source.Is().Upper);
            source = '0';
            Assert.False(source.Is().Upper);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_Uppercase_Letter_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Not.Upper);
            source = '0';
            Assert.True(source.Is().Not.Upper);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Uppercase_Letter_Char()
        {
            var source = 'A';
            Assert.False(source.Is().Not.Upper);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_White_Space_Char()
        {
            var source = ' ';
            Assert.True(source.Is().WhiteSpace);
            source = '\n';
            Assert.True(source.Is().WhiteSpace);
            source = '\t';
            Assert.True(source.Is().WhiteSpace);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_White_Space_Char()
        {
            var source = 'a';
            Assert.False(source.Is().WhiteSpace);
            source = '0';
            Assert.False(source.Is().WhiteSpace);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_White_Space_Char()
        {
            var source = 'a';
            Assert.True(source.Is().Not.WhiteSpace);
            source = '0';
            Assert.True(source.Is().Not.WhiteSpace);
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_White_Space_Char()
        {
            var source = ' ';
            Assert.False(source.Is().Not.WhiteSpace);
            source = '\n';
            Assert.False(source.Is().Not.WhiteSpace);
            source = '\t';
            Assert.False(source.Is().Not.WhiteSpace);
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_In_String()
        {
            const string str = "Text with S in.";

            var source = 'S';
            Assert.True(source.Is().In(str));

            source = 's';
            Assert.True(source.Is().In(str, true));
        }

        [Fact]
        public void Should_Return_True_When_Source_Is_Not_In_String()
        {
            const string str = "Text with S in.";

            var source = 's';
            Assert.True(source.Is().Not.In(str));

            source = 'b';
            Assert.True(source.Is().Not.In(str, true));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_Not_In_String()
        {
            const string str = "Text with S in.";

            var source = 's';
            Assert.False(source.Is().In(str));

            source = 'b';
            Assert.False(source.Is().In(str, true));
        }

        [Fact]
        public void Should_Return_False_When_Source_Is_In_String()
        {
            const string str = "Text with S in.";

            var source = 'S';
            Assert.False(source.Is().Not.In(str));

            source = 's';
            Assert.False(source.Is().Not.In(str, true));
        }

        [Fact]
        public void Should_Return_False_When_String_Is_Null()
        {
            const string str = null;

            var source = 'S';
            Assert.False(source.Is().In(str));

            source = 's';
            Assert.False(source.Is().In(str, true));
        }

        [Fact]
        public void Should_Return_True_When_String_Is_Null()
        {
            const string str = null;

            var source = 'S';
            Assert.True(source.Is().Not.In(str));

            source = 's';
            Assert.True(source.Is().Not.In(str, true));
        }
    }
}