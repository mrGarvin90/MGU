namespace MGU.Console.Tests.UtilitiesTests.InputBufferTests
{
    using NUnit.Framework;
    using Utilities.Input;

    [TestFixture]
    public class ConstructorTests
    {
        #region ThrowsExceptionIf

        [Test]
        public void ThrowsExceptionIfPromptIsNull()
        {
            Assert.That(() => new InputBuffer(null), Throws.ArgumentNullException);
        }

        [Test]
        public void ThrowsExceptionIfPromptIsContainsNullChar_1()
        {
            Assert.That(() => new InputBuffer("\0"), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptIsContainsNullChar_2()
        {
            Assert.That(() => new InputBuffer("Te\0st: "), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptIsContainsNullChar_3()
        {
            Assert.That(() => new InputBuffer("Test: \0"), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptIsContainsReturnCharChar_1()
        {
            Assert.That(() => new InputBuffer("\r"), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptIsContainsReturnCharChar_2()
        {
            Assert.That(() => new InputBuffer("Te\rst: "), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptIsContainsReturnCharChar_3()
        {
            Assert.That(() => new InputBuffer("Test: \r"), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptIsContainsTabChar_1()
        {
            Assert.That(() => new InputBuffer("\t"), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptIsContainsTabChar_2()
        {
            Assert.That(() => new InputBuffer("Te\tst: "), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptIsContainsTabChar_3()
        {
            Assert.That(() => new InputBuffer("Test: \t"), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptContainsMoreThanOneNewLineChar_1()
        {
            Assert.That(() => new InputBuffer("\n\n"), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptContainsMoreThanOneNewLineChar_2()
        {
            Assert.That(() => new InputBuffer("\nTe\nst: "), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptContainsMoreThanOneNewLineChar_3()
        {
            Assert.That(() => new InputBuffer("Te\nst: \n"), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptContainsANewLineCharAndItsNotTheLastCharacter_1()
        {
            Assert.That(() => new InputBuffer("\nTest: "), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptContainsANewLineCharAndItsNotTheLastCharacter_2()
        {
            Assert.That(() => new InputBuffer("Te\nst: "), Throws.ArgumentException);
        }

        [Test]
        public void ThrowsExceptionIfPromptContainsANewLineCharAndItsNotTheLastCharacter_3()
        {
            Assert.That(() => new InputBuffer("Test:\n "), Throws.ArgumentException);
        }

        #endregion

        #region IfPromptIsEmpty

        [Test]
        public void IfPromptIsEmpty_FirstRowContainsOnlyANewLineChar()
        {
            var inputBuffer = new InputBuffer("");
            Assert.That(inputBuffer[0], Is.EquivalentTo("\n"));
        }

        #endregion

        #region FirstRowStartsWithPrompt

        [Test]
        public void FirstRowStartsWithPrompt_1()
        {
            var inputBuffer = new InputBuffer("\n");
            Assert.That(inputBuffer[0], Is.EquivalentTo("\n"));
        }

        [Test]
        public void FirstRowStartsWithPrompt_2()
        {
            var inputBuffer = new InputBuffer("Test: ");
            Assert.That(inputBuffer[0], Is.EquivalentTo("Test: \n"));
        }

        [Test]
        public void FirstRowStartsWithPrompt_3()
        {
            var inputBuffer = new InputBuffer("Test:\n");
            Assert.That(inputBuffer[0], Is.EquivalentTo("Test:\n"));
        }

        #endregion

        #region IfPromptDoesNotEndWithANewLineChar

        [Test]
        public void IfPromptDoesNotEndWithANewLineChar_InputBufferWillOnlyContainOneRow_1()
        {
            var inputBuffer = new InputBuffer("");
            Assert.That(inputBuffer.RowCount, Is.EqualTo(1));
        }

        [Test]
        public void IfPromptDoesNotEndWithANewLineChar_InputBufferWillOnlyContainOneRow_2()
        {
            var inputBuffer = new InputBuffer("Test: ");
            Assert.That(inputBuffer.RowCount, Is.EqualTo(1));
        }

        [Test]
        public void IfPromptDoesNotEndWithANewLineChar_TopRowIndexWillBeEqualToZero_1()
        {
            var inputBuffer = new InputBuffer("");
            Assert.That(inputBuffer.TopRowIndex, Is.EqualTo(0));
        }

        [Test]
        public void IfPromptDoesNotEndWithANewLineChar_TopRowIndexWillBeEqualToZero_2()
        {
            var inputBuffer = new InputBuffer("Test: ");
            Assert.That(inputBuffer.TopRowIndex, Is.EqualTo(0));
        }

        [Test]
        public void IfPromptDoesNotEndWithANewLineChar_FirstColumnIndexWillBeEqualToTheLengthOfPrompt_1()
        {
            var inputBuffer = new InputBuffer("");
            Assert.That(inputBuffer.FirstColumnIndex, Is.EqualTo(0));
        }

        [Test]
        public void IfPromptDoesNotEndWithANewLineChar_FirstColumnIndexWillBeEqualToTheLengthOfPrompt_2()
        {
            var inputBuffer = new InputBuffer("Test: ");
            Assert.That(inputBuffer.FirstColumnIndex, Is.EqualTo(6));
        }

        [Test]
        public void IfPromptDoesNotEndWithANewLineChar_ANewLineCharWillBeAddedToTheEndOfTheFirstRow_1()
        {
            var inputBuffer = new InputBuffer("");
            Assert.That(inputBuffer[0, 0], Is.EqualTo('\n'));
        }

        [Test]
        public void IfPromptDoesNotEndWithANewLineChar_ANewLineCharWillBeAddedToTheEndOfTheFirstRow_2()
        {
            var inputBuffer = new InputBuffer("Test: ");
            Assert.That(inputBuffer[0, 6], Is.EqualTo('\n'));
        }

        #endregion

        #region IfPromptEndsWithANewLineChar

        [Test]
        public void IfPromptEndsWithANewLineChar_ANewRowWillBeAdded_1()
        {
            var inputBuffer = new InputBuffer("\n");
            Assert.That(inputBuffer.RowCount, Is.EqualTo(2));
        }

        [Test]
        public void IfPromptEndsWithANewLineChar_ANewRowWillBeAdded_2()
        {
            var inputBuffer = new InputBuffer("Test:\n");
            Assert.That(inputBuffer.RowCount, Is.EqualTo(2));
        }

        [Test]
        public void IfPromptEndsWithANewLineChar_ANewRowWillBeAddedContainingOnlyANewLineChar_1()
        {
            var inputBuffer = new InputBuffer("\n");
            Assert.That(inputBuffer[1], Is.EquivalentTo("\n"));
        }

        [Test]
        public void IfPromptEndsWithANewLineChar_ANewRowWillBeAddedContainingOnlyANewLineChar_2()
        {
            var inputBuffer = new InputBuffer("Test:\n");
            Assert.That(inputBuffer[1], Is.EquivalentTo("\n"));
        }

        [Test]
        public void IfPromptEndsWithANewLineChar_TopRowIndexWillBeEqualToOne_1()
        {
            var inputBuffer = new InputBuffer("\n");
            Assert.That(inputBuffer.TopRowIndex, Is.EqualTo(1));
        }

        [Test]
        public void IfPromptEndsWithANewLineChar_TopRowIndexWillBeEqualToOne_2()
        {
            var inputBuffer = new InputBuffer("Test:\n");
            Assert.That(inputBuffer.TopRowIndex, Is.EqualTo(1));
        }

        [Test]
        public void IfPromptEndsWithANewLineChar_FirstColumnIndexWillBeEqualToZero_1()
        {
            var inputBuffer = new InputBuffer("\n");
            Assert.That(inputBuffer.FirstColumnIndex, Is.EqualTo(0));
        }

        [Test]
        public void IfPromptEndsWithANewLineChar_FirstColumnIndexWillBeEqualToZero_2()
        {
            var inputBuffer = new InputBuffer("Test:\n");
            Assert.That(inputBuffer.FirstColumnIndex, Is.EqualTo(0));
        }

        #endregion
    }
}