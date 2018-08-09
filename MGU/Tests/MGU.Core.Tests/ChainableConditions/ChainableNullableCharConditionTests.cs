#pragma warning disable SA1500 // Braces for multi-line statements must not share line
namespace MGU.Core.Tests.ChainableConditions
{
    using System.Collections.Generic;
    using Core.Extensions.If;
    using Xunit;

    public class ChainableNullableCharConditionTests
    {
        private static readonly IEnumerable<char?> ControlChars =
            new char?[] {'\u0000', '\u0001', '\u0002', '\u0003', '\u0004', '\u0005', '\u0006', '\u0007', '\u0008', '\u0009', '\u000A', '\u000B', '\u000C', '\u000D', '\u000E',
                   '\u000F', '\u0010', '\u0011', '\u0012', '\u0013', '\u0014', '\u0015', '\u0016', '\u0017', '\u0018', '\u0019', '\u001A', '\u001B', '\u001C', '\u001D',
                   '\u001E', '\u001F', '\u007F', '\u0080', '\u0081', '\u0082', '\u0083', '\u0084', '\u0085', '\u0086', '\u0087', '\u0088', '\u0089', '\u008A', '\u008B',
                   '\u008C', '\u008D', '\u008E', '\u008F', '\u0090', '\u0091', '\u0092', '\u0093', '\u0094', '\u0095', '\u0096', '\u0097', '\u0098', '\u0099', '\u009A',
                   '\u009B', '\u009C', '\u009D', '\u009E', '\u009F'};

        private static readonly IEnumerable<char?> Digits = new char?[] {'0', '1', '2', '3', '4', '5', '6', '7', '8', '9'};

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Control_Char()
        {
            foreach (char? source in ControlChars)
            {
                Assert.True(source.If().Control.Result);
            }
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Control_Char()
        {
            char? source = '0';
            Assert.False(source.If().Control.Result);
            source = 'a';
            Assert.False(source.If().Control.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Control_Char()
        {
            char? source = '0';
            Assert.True(source.If().Not.Control.Result);
            source = 'a';
            Assert.True(source.If().Not.Control.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Control_Char()
        {
            foreach (char? source in ControlChars)
            {
                Assert.False(source.If().Not.Control.Result);
            }
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Digit_Char()
        {
            foreach (char? source in Digits)
            {
                Assert.True(source.If().Digit.Result);
            }
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Digit_Char()
        {
            char? source = 'a';
            Assert.False(source.If().Digit.Result);
            source = '\u0000';
            Assert.False(source.If().Digit.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Digit_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Not.Digit.Result);
            source = '\u0000';
            Assert.True(source.If().Not.Digit.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Digit_Char()
        {
            foreach (char? source in Digits)
            {
                Assert.False(source.If().Not.Digit.Result);
            }
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_High_Surrogate()
        {
            char? source = '\uD800';
            Assert.True(source.If().HighSurrogate.Result);
            source = '\uDBFF';
            Assert.True(source.If().HighSurrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_High_Surrogate()
        {
            char? source = 'a';
            Assert.False(source.If().HighSurrogate.Result);
            source = '\u0000';
            Assert.False(source.If().HighSurrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_High_Surrogate()
        {
            char? source = 'a';
            Assert.True(source.If().Not.HighSurrogate.Result);
            source = '\u0000';
            Assert.True(source.If().Not.HighSurrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_High_Surrogate()
        {
            char? source = '\uD800';
            Assert.False(source.If().Not.HighSurrogate.Result);
            source = '\uDBFF';
            Assert.False(source.If().Not.HighSurrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Letter_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Letter.Result);
            source = 'A';
            Assert.True(source.If().Letter.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Letter_Char()
        {
            char? source = '\u0000';
            Assert.False(source.If().Letter.Result);
            source = '0';
            Assert.False(source.If().Letter.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Letter_Char()
        {
            char? source = '\u0000';
            Assert.True(source.If().Not.Letter.Result);
            source = '0';
            Assert.True(source.If().Not.Letter.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Letter_Char()
        {
            char? source = 'a';
            Assert.False(source.If().Not.Letter.Result);
            source = 'A';
            Assert.False(source.If().Not.Letter.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Lowercase_Letter_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Lower.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Lowercase_Letter_Char()
        {
            char? source = 'A';
            Assert.False(source.If().Lower.Result);
            source = '0';
            Assert.False(source.If().Lower.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Lowercase_Letter_Char()
        {
            char? source = 'A';
            Assert.True(source.If().Not.Lower.Result);
            source = '0';
            Assert.True(source.If().Not.Lower.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Lowercase_Letter_Char()
        {
            char? source = 'a';
            Assert.False(source.If().Not.Lower.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Low_Surrogate()
        {
            char? source = '\uDC00';
            Assert.True(source.If().LowSurrogate.Result);
            source = '\uDFFF';
            Assert.True(source.If().LowSurrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Low_Surrogate()
        {
            char? source = 'a';
            Assert.False(source.If().LowSurrogate.Result);
            source = '\u0000';
            Assert.False(source.If().LowSurrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Low_Surrogate()
        {
            char? source = 'a';
            Assert.True(source.If().Not.LowSurrogate.Result);
            source = '\u0000';
            Assert.True(source.If().Not.LowSurrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Low_Surrogate()
        {
            char? source = '\uDC00';
            Assert.False(source.If().Not.LowSurrogate.Result);
            source = '\uDFFF';
            Assert.False(source.If().Not.LowSurrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Number_Char()
        {
            char? sourceLetterNumber = '\u16EE';
            Assert.True(sourceLetterNumber.If().Number.Result);

            foreach (char? sourceDigit in Digits)
            {
                Assert.True(sourceDigit.If().Number.Result);
            }
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Number_Char()
        {
            char? source = 'a';
            Assert.False(source.If().Number.Result);
            source = '\u0000';
            Assert.False(source.If().Number.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Number_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Not.Number.Result);
            source = '\u0000';
            Assert.True(source.If().Not.Number.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Number_Char()
        {
            char? sourceLetterNumber = '\u16EE';
            Assert.False(sourceLetterNumber.If().Not.Number.Result);

            foreach (char? source in Digits)
            {
                Assert.False(source.If().Not.Number.Result);
            }
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Punctuation_Char()
        {
            char? source = '.';
            Assert.True(source.If().Punctuation.Result);
            source = ',';
            Assert.True(source.If().Punctuation.Result);
            source = '!';
            Assert.True(source.If().Punctuation.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Punctuation_Char()
        {
            char? source = 'a';
            Assert.False(source.If().Punctuation.Result);
            source = '0';
            Assert.False(source.If().Punctuation.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Punctuation_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Not.Punctuation.Result);
            source = '0';
            Assert.True(source.If().Not.Punctuation.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Punctuation_Char()
        {
            char? source = '.';
            Assert.False(source.If().Not.Punctuation.Result);
            source = ',';
            Assert.False(source.If().Not.Punctuation.Result);
            source = '!';
            Assert.False(source.If().Not.Punctuation.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Separator_Char()
        {
            char? source = '\u0020';
            Assert.True(source.If().Separator.Result);
            source = '\u2029';
            Assert.True(source.If().Separator.Result);
            source = '\u3000';
            Assert.True(source.If().Separator.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Separator_Char()
        {
            char? source = 'a';
            Assert.False(source.If().Separator.Result);
            source = '0';
            Assert.False(source.If().Separator.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Separator_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Not.Separator.Result);
            source = '0';
            Assert.True(source.If().Not.Separator.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Separator_Char()
        {
            char? source = '\u0020';
            Assert.False(source.If().Not.Separator.Result);
            source = '\u2029';
            Assert.False(source.If().Not.Separator.Result);
            source = '\u3000';
            Assert.False(source.If().Not.Separator.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Surrogate_Char()
        {
            var str = "\U00010F00";
            char? source = str[0];
            Assert.True(source.If().Surrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Surrogate_Char()
        {
            char? source = 'a';
            Assert.False(source.If().Surrogate.Result);
            source = '0';
            Assert.False(source.If().Surrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Surrogate_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Not.Surrogate.Result);
            source = '0';
            Assert.True(source.If().Not.Surrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Surrogate_Char()
        {
            var str = "\U00010F00";
            char? source = str[0];
            Assert.False(source.If().Not.Surrogate.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Symbol_Char()
        {
            char? source = '+';
            Assert.True(source.If().Symbol.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Symbol_Char()
        {
            char? source = 'a';
            Assert.False(source.If().Symbol.Result);
            source = '0';
            Assert.False(source.If().Symbol.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Symbol_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Not.Symbol.Result);
            source = '0';
            Assert.True(source.If().Not.Symbol.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Symbol_Char()
        {
            char? source = '+';
            Assert.False(source.If().Not.Symbol.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Uppercase_Letter_Char()
        {
            char? source = 'A';
            Assert.True(source.If().Upper.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_Uppercase_Letter_Char()
        {
            char? source = 'a';
            Assert.False(source.If().Upper.Result);
            source = '0';
            Assert.False(source.If().Upper.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_Uppercase_Letter_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Not.Upper.Result);
            source = '0';
            Assert.True(source.If().Not.Upper.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Uppercase_Letter_Char()
        {
            char? source = 'A';
            Assert.False(source.If().Not.Upper.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_White_Space_Char()
        {
            char? source = ' ';
            Assert.True(source.If().WhiteSpace.Result);
            source = '\n';
            Assert.True(source.If().WhiteSpace.Result);
            source = '\t';
            Assert.True(source.If().WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_White_Space_Char()
        {
            char? source = 'a';
            Assert.False(source.If().WhiteSpace.Result);
            source = '0';
            Assert.False(source.If().WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_White_Space_Char()
        {
            char? source = 'a';
            Assert.True(source.If().Not.WhiteSpace.Result);
            source = '0';
            Assert.True(source.If().Not.WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_White_Space_Char()
        {
            char? source = ' ';
            Assert.False(source.If().Not.WhiteSpace.Result);
            source = '\n';
            Assert.False(source.If().Not.WhiteSpace.Result);
            source = '\t';
            Assert.False(source.If().Not.WhiteSpace.Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_In_Other()
        {
            const string other = "Text with S in.";

            char? source = 'S';
            Assert.True(source.If().In(other).Result);

            source = 's';
            Assert.True(source.If().In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Not_In_Other()
        {
            const string other = "Text with S in.";

            char? source = 's';
            Assert.True(source.If().Not.In(other).Result);

            source = 'b';
            Assert.True(source.If().Not.In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Not_In_Other()
        {
            const string other = "Text with S in.";

            char? source = 's';
            Assert.False(source.If().In(other).Result);

            source = 'b';
            Assert.False(source.If().In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_In_Other()
        {
            const string other = "Text with S in.";

            char? source = 'S';
            Assert.False(source.If().Not.In(other).Result);

            source = 's';
            Assert.False(source.If().Not.In(other, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_Is_Null()
        {
            const string str = "str";

            char? source = null;
            Assert.False(source.If().In(str).Result);
            Assert.False(source.If().In(str, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_Is_Null()
        {
            const string str = "str";

            char? source = null;
            Assert.True(source.If().Not.In(str).Result);
            Assert.True(source.If().Not.In(str, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_String_Is_Null()
        {
            const string str = null;

            var source = 'S';
            Assert.False(source.If().In(str).Result);

            source = 's';
            Assert.False(source.If().In(str, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_String_Is_Null()
        {
            const string str = null;

            var source = 'S';
            Assert.True(source.If().Not.In(str).Result);

            source = 's';
            Assert.True(source.If().Not.In(str, true).Result);
        }

        [Fact]
        public void Result_Should_Be_False_When_Source_And_String_Is_Null()
        {
            const string str = null;

            char? source = null;
            Assert.False(source.If().In(str).Result);
            Assert.False(source.If().In(str, true).Result);
        }

        [Fact]
        public void Result_Should_Be_True_When_Source_And_String_Is_Null()
        {
            const string str = null;

            char? source = null;
            Assert.True(source.If().Not.In(str).Result);
            Assert.True(source.If().Not.In(str, true).Result);
        }

        [Fact]
        public void Result_Should_False_When_Source_Is_Null_And_Null_Was_Checked()
        {
            char? source = null;

            Assert.False(source.If().Not.Null.And.Control.Result);
            Assert.False(source.If().Not.Null.And.Digit.Result);
            Assert.False(source.If().Not.Null.And.HighSurrogate.Result);
            Assert.False(source.If().Not.Null.And.Letter.Result);
            Assert.False(source.If().Not.Null.And.Lower.Result);
            Assert.False(source.If().Not.Null.And.LowSurrogate.Result);
            Assert.False(source.If().Not.Null.And.Number.Result);
            Assert.False(source.If().Not.Null.And.Punctuation.Result);
            Assert.False(source.If().Not.Null.And.Separator.Result);
            Assert.False(source.If().Not.Null.And.Surrogate.Result);
            Assert.False(source.If().Not.Null.And.Symbol.Result);
            Assert.False(source.If().Not.Null.And.Upper.Result);
            Assert.False(source.If().Not.Null.And.WhiteSpace.Result);

            Assert.False(source.If().Not.Null.And.Not.Control.Result);
            Assert.False(source.If().Not.Null.And.Not.Digit.Result);
            Assert.False(source.If().Not.Null.And.Not.HighSurrogate.Result);
            Assert.False(source.If().Not.Null.And.Not.Letter.Result);
            Assert.False(source.If().Not.Null.And.Not.Lower.Result);
            Assert.False(source.If().Not.Null.And.Not.LowSurrogate.Result);
            Assert.False(source.If().Not.Null.And.Not.Number.Result);
            Assert.False(source.If().Not.Null.And.Not.Punctuation.Result);
            Assert.False(source.If().Not.Null.And.Not.Separator.Result);
            Assert.False(source.If().Not.Null.And.Not.Surrogate.Result);
            Assert.False(source.If().Not.Null.And.Not.Symbol.Result);
            Assert.False(source.If().Not.Null.And.Not.Upper.Result);
            Assert.False(source.If().Not.Null.And.Not.WhiteSpace.Result);
        }
    }
}