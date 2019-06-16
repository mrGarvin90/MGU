namespace MGU.Console.Tests.UtilitiesTests.InputBufferTests
{
    using System.Collections.Generic;
    using System.Reflection;
    using Interfaces.Input;
    using NUnit.Framework;
    using Utilities.Input;

    [TestFixture]
    public class InsertTests
    {
        private IInputBuffer CreateNewInputBufferContaining(string init, List<List<char>> rows)
        {
            var inputBuffer = new InputBuffer(init);
            rows[0].InsertRange(0, init);
            var rowsFieldInfo = inputBuffer.GetType().GetField("_rows", BindingFlags.NonPublic | BindingFlags.Instance);
            rowsFieldInfo.SetValue(inputBuffer, rows);
            return inputBuffer;
        }

        private readonly char[] _testCharacters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O' };

        private List<List<char>> CreateRows(IReadOnlyList<int> columnCounts)
        {
            var rows = new List<List<char>>();
            for (var i = 0; i < columnCounts.Count; i++)
                rows.Add(new List<char>(new string(this._testCharacters[i], columnCounts[i]) + "\n"));
            return rows;
        }

        #region ThrowsExceptionIf

        [Test]
        public void ThrowsExceptionIfNullCharIsInserted()
        {
            void InsertNullChar() => new InputBuffer("").Insert(0, 0, '\0');
            Assert.That(InsertNullChar, Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowsExceptionIfReturnCharIsInserted()
        {
            void InsertReturnChar() => new InputBuffer("").Insert(0, 0, '\r');
            Assert.That(InsertReturnChar, Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowsExceptionIfTabCharIsInserted()
        {
            void InsertTabChar() => new InputBuffer("").Insert(0, 0, '\t');
            Assert.That(InsertTabChar, Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowsExceptionIfInsertingAfterANewLineChar_1()
        {
            void InsertAfterNewLineChar()
            {
                var inputBuffer = new InputBuffer("\n");
                inputBuffer.Insert(0, 1, 'A');
            }
            Assert.That(InsertAfterNewLineChar, Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowsExceptionIfInsertingAfterANewLineChar_2()
        {
            void InsertAfterNewLineChar()
            {
                var rows = this.CreateRows(new[] { 6, 5, 4, 3 });
                var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
                inputBuffer.Insert(2, 5, 'A');
            }
            Assert.That(InsertAfterNewLineChar, Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowsExceptionIfInsertingAtIndexLessThanFirstColumnIndex()
        {
            void InsertAtIndexLessThanFirstColumnIndex()
            {
                var inputBuffer = new InputBuffer("Test: ");
                inputBuffer.Insert(0, inputBuffer.FirstColumnIndex - 1, 'A');
            }
            Assert.That(InsertAtIndexLessThanFirstColumnIndex, Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowsExceptionIfInsertingAtIndexLessThanTopRowIndex_1()
        {
            void InsertAtIndexLessThanTopRowIndex()
            {
                var inputBuffer = new InputBuffer("Test:\n");
                inputBuffer.Insert(0, 0, 'A');
            }
            Assert.That(InsertAtIndexLessThanTopRowIndex, Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowsExceptionIfInsertingAtIndexLessThanTopRowIndex_2()
        {
            void InsertAtIndexLessThanTopRowIndex()
            {
                var inputBuffer = new InputBuffer("Test:\n");
                inputBuffer.Insert(0, 2, 'A');
            }
            Assert.That(InsertAtIndexLessThanTopRowIndex, Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowsExceptionIfInsertingAtIndexLessThanTopRowIndex_3()
        {
            void InsertAtIndexLessThanTopRowIndex()
            {
                var inputBuffer = new InputBuffer("Test:\n");
                inputBuffer.Insert(0, 5, 'A');
            }
            Assert.That(InsertAtIndexLessThanTopRowIndex, Throws.InvalidOperationException);
        }

        #endregion

        #region AddsANewRowWhenInsertingANewLineChar

        [Test]
        public void AddsANewRowWhenInsertingANewLineChar_1()
        {
            var inputBuffer = new InputBuffer("");
            var previousRowCount = inputBuffer.RowCount;
            inputBuffer.Insert(0, 0, '\n');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount + 1));
        }

        [Test]
        public void AddsANewRowWhenInsertingANewLineChar_2()
        {
            var inputBuffer = new InputBuffer("");
            var previousRowCount = inputBuffer.RowCount;
            var columnIndex = 4;
            for (var index = 0; index < columnIndex; index++)
                inputBuffer.Insert(0, index, 'A');
            inputBuffer.Insert(0, columnIndex, '\n');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount + 1));
        }

        [Test]
        public void AddsANewRowWhenInsertingANewLineChar_3()
        {
            var inputBuffer = new InputBuffer("");
            var previousRowCount = inputBuffer.RowCount;
            for (var index = 0; index < 4; index++)
                inputBuffer.Insert(0, index, 'A');
            inputBuffer.Insert(0, 2, '\n');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount + 1));
        }

        [Test]
        public void AddsANewRowWhenInsertingANewLineChar_4()
        {
            var inputBuffer = new InputBuffer("Test: ");
            var previousRowCount = inputBuffer.RowCount;
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex, '\n');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount + 1));
        }

        [Test]
        public void AddsANewRowWhenInsertingANewLineChar_5()
        {
            var inputBuffer = new InputBuffer("Test: ");
            var previousRowCount = inputBuffer.RowCount;
            var columnIndex = inputBuffer.FirstColumnIndex + 4;
            for (var index = inputBuffer.FirstColumnIndex; index < columnIndex; index++)
                inputBuffer.Insert(0, index, 'A');
            inputBuffer.Insert(0, columnIndex, '\n');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount + 1));
        }

        [Test]
        public void AddsANewRowWhenInsertingANewLineChar_6()
        {
            var inputBuffer = new InputBuffer("Test: ");
            var previousRowCount = inputBuffer.RowCount;
            for (var index = inputBuffer.FirstColumnIndex; index < inputBuffer.FirstColumnIndex + 4; index++)
                inputBuffer.Insert(0, index, 'A');
            inputBuffer.Insert(0, 7, '\n');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount + 1));
        }

        [Test]
        public void AddsANewRowWhenInsertingANewLineChar_7()
        {
            var rows = this.CreateRows(new[] { 6, 5, 4, 3 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            var previousRowCount = inputBuffer.RowCount;
            inputBuffer.Insert(2, 0, '\n');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount + 1));
        }

        [Test]
        public void AddsANewRowWhenInsertingANewLineChar_8()
        {
            var rows = this.CreateRows(new[] { 6, 5, 4, 3 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            var previousRowCount = inputBuffer.RowCount;
            inputBuffer.Insert(2, 2, '\n');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount + 1));
        }

        [Test]
        public void AddsANewRowWhenInsertingANewLineChar_9()
        {
            var rows = this.CreateRows(new[] { 6, 5, 4, 3 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            var previousRowCount = inputBuffer.RowCount;
            inputBuffer.Insert(2, 4, '\n');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount + 1));
        }

        #endregion

        #region InsertsRowContainingANewLineCharWhenInsertingANewLineCharAtTheEndOfARow

        [Test]
        public void InsertsRowContainingANewLineCharWhenInsertingANewLineCharAtTheEndOfARow_1()
        {
            var inputBuffer = new InputBuffer("");
            inputBuffer.Insert(0, 0, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('\n', 1)));
        }

        [Test]
        public void InsertsRowContainingANewLineCharWhenInsertingANewLineCharAtTheEndOfARow_2()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 4, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('\n', 1)));
        }

        [Test]
        public void InsertsRowContainingANewLineCharWhenInsertingANewLineCharAtTheEndOfARow_3()
        {
            var inputBuffer = new InputBuffer("Test: ");
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('\n', 1)));
        }

        [Test]
        public void InsertsRowContainingANewLineCharWhenInsertingANewLineCharAtTheEndOfARow_4()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex + 4, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('\n', 1)));
        }

        [Test]
        public void InsertsRowContainingANewLineCharWhenInsertingANewLineCharAtTheEndOfARow_5()
        {
            var rows = this.CreateRows(new[] { 6, 5, 4, 3 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex + 6, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('\n', 1)));
        }

        [Test]
        public void InsertsRowContainingANewLineCharWhenInsertingANewLineCharAtTheEndOfARow_6()
        {
            var rows = this.CreateRows(new[] { 6, 5, 4, 3 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.Insert(1, 5, '\n');
            Assert.That(inputBuffer[2], Is.EquivalentTo(new string('\n', 1)));
        }

        #endregion

        #region WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_1()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 0, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('A', 4) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_2()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 1, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('A', 3) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_3()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 2, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('A', 2) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_4()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 3, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('A', 1) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_5()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('A', 4) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_6()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex + 1, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('A', 3) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_7()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex + 2, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('A', 2) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_8()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex + 3, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('A', 1) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_9()
        {
            var rows = this.CreateRows(new[] { 3, 4, 5 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(1, 0, '\n');
            Assert.That(inputBuffer[2], Is.EquivalentTo(new string('B', 4) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_10()
        {
            var rows = this.CreateRows(new[] { 3, 4, 5 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(1, 1, '\n');
            Assert.That(inputBuffer[2], Is.EquivalentTo(new string('B', 3) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_11()
        {
            var rows = this.CreateRows(new[] { 3, 4, 5 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(1, 2, '\n');
            Assert.That(inputBuffer[2], Is.EquivalentTo(new string('B', 2) + "\n"));
        }

        [Test]
        public void
            WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_ANewRowIsInsertedAndTheTrailingCharsIsAddedToTheNewRow_12()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 3, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo(new string('A', 1) + "\n"));
        }

        #endregion

        #region WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_TheTrailingCharsIsRemoved

        [Test]
        public void WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_TheTrailingCharsIsRemoved_1()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 0, '\n');
            Assert.That(inputBuffer[0], Is.EquivalentTo("\n"));
        }

        [Test]
        public void WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_TheTrailingCharsIsRemoved_2()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 1, '\n');
            Assert.That(inputBuffer[0], Is.EquivalentTo("A\n"));
        }

        [Test]
        public void WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_TheTrailingCharsIsRemoved_3()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex, '\n');
            Assert.That(inputBuffer[0], Is.EquivalentTo("Test: \n"));
        }

        [Test]
        public void WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_TheTrailingCharsIsRemoved_4()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex + 1, '\n');
            Assert.That(inputBuffer[0], Is.EquivalentTo("Test: A\n"));
        }

        [Test]
        public void WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_TheTrailingCharsIsRemoved_5()
        {
            var rows = this.CreateRows(new[] { 4, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(1, 0, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo("\n"));
        }

        [Test]
        public void WhenInsertingANewLineCharAtIndexLessThanLastColumnIndex_TheTrailingCharsIsRemoved_6()
        {
            var rows = this.CreateRows(new[] { 4, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(1, 1, '\n');
            Assert.That(inputBuffer[1], Is.EquivalentTo("B\n"));
        }

        #endregion

        #region CharIsInsertedCorrectly

        [Test]
        public void CharIsInsertedCorrectly_1()
        {
            var inputBuffer = new InputBuffer("");
            inputBuffer.Insert(0, 0, 'A');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(1));
            Assert.That(inputBuffer[0], Is.EquivalentTo("A\n"));
        }

        [Test]
        public void CharIsInsertedCorrectly_2()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 0, 'B');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(1));
            Assert.That(inputBuffer[0], Is.EquivalentTo("BAAAA\n"));
        }

        [Test]
        public void CharIsInsertedCorrectly_3()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(0, 4, 'B');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(1));
            Assert.That(inputBuffer[0], Is.EquivalentTo("AAAAB\n"));
        }

        [Test]
        public void CharIsInsertedCorrectly_4()
        {
            var inputBuffer = new InputBuffer("Test: ");
            inputBuffer.Insert(0, inputBuffer.FirstColumnIndex, 'A');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(1));
            Assert.That(inputBuffer[0], Is.EquivalentTo("Test: A\n"));
        }

        [Test]
        public void CharIsInsertedCorrectly_5()
        {
            var rows = this.CreateRows(new[] { 0, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(1, 0, 'C');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(2));
            Assert.That(inputBuffer[0], Is.EquivalentTo("\n"));
            Assert.That(inputBuffer[1], Is.EquivalentTo("CBBBB\n"));
        }

        [Test]
        public void CharIsInsertedCorrectly_6()
        {
            var rows = this.CreateRows(new[] { 0, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.Insert(1, 4, 'C');
            Assert.That(inputBuffer.RowCount, Is.EqualTo(2));
            Assert.That(inputBuffer[0], Is.EquivalentTo("\n"));
            Assert.That(inputBuffer[1], Is.EquivalentTo("BBBBC\n"));
        }

        #endregion
    }
}