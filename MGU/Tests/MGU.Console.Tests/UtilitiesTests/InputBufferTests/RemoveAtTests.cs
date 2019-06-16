namespace MGU.Console.Tests.UtilitiesTests.InputBufferTests
{
    using System.Collections.Generic;
    using System.Reflection;
    using Interfaces.Input;
    using NUnit.Framework;
    using Utilities.Input;

    [TestFixture]
    public class RemoveAtTests
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
        public void ThrowsExceptionIfRemovingAtIndexLessThanFirstColumn()
        {
            void RemoveAtIndexLessThanFirstColumn()
            {
                var inputBuffer = new InputBuffer("Test: ");
                inputBuffer.RemoveAt(0, inputBuffer.FirstColumnIndex - 1);
            }
            Assert.That(RemoveAtIndexLessThanFirstColumn, Throws.InvalidOperationException);
        }

        [Test]
        public void ThrowsExceptionIfRemovingAtIndexLessThanTopRowIndex()
        {
            void RemoveAtIndexLessThanTopRowIndex()
            {
                var inputBuffer = new InputBuffer("Test:\n");
                inputBuffer.RemoveAt(0, 0);
            }
            Assert.That(RemoveAtIndexLessThanTopRowIndex, Throws.InvalidOperationException);
        }

        #endregion

        #region RemovingNewLineCharOnTheLastRowIsIgnored

        [Test]
        public void RemovingNewLineCharOnTheLastRowIsIgnored_1()
        {
            var inputBuffer = new InputBuffer("");
            var rowBeforeRemove = inputBuffer[0];
            inputBuffer.RemoveAt(0, 0);
            Assert.That(inputBuffer[0], Is.EquivalentTo(rowBeforeRemove));
        }

        [Test]
        public void RemovingNewLineCharOnTheLastRowIsIgnored_2()
        {
            var inputBuffer = new InputBuffer("Test: ");
            var rowBeforeRemove = inputBuffer[0];
            inputBuffer.RemoveAt(0, inputBuffer.FirstColumnIndex);
            Assert.That(inputBuffer[0], Is.EquivalentTo(rowBeforeRemove));
        }

        [Test]
        public void RemovingNewLineCharOnTheLastRowIsIgnored_3()
        {
            var rows = this.CreateRows(new[] { 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            var rowBeforeRemove = inputBuffer[0];
            inputBuffer.RemoveAt(0, inputBuffer.FirstColumnIndex + 4);
            Assert.That(inputBuffer[0], Is.EquivalentTo(rowBeforeRemove));
        }

        [Test]
        public void RemovingNewLineCharOnTheLastRowIsIgnored_4()
        {
            var rows = this.CreateRows(new[] { 0, 0 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            var rowBeforeRemove = inputBuffer[1];
            inputBuffer.RemoveAt(1, 0);
            Assert.That(inputBuffer[1], Is.EquivalentTo(rowBeforeRemove));
        }

        [Test]
        public void RemovingNewLineCharOnTheLastRowIsIgnored_5()
        {
            var rows = this.CreateRows(new[] { 0, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            var rowBeforeRemove = inputBuffer[1];
            inputBuffer.RemoveAt(1, 4);
            Assert.That(inputBuffer[1], Is.EquivalentTo(rowBeforeRemove));
        }

        #endregion

        #region WhenRemovingTheNewLineCharTheNextRowIsRemoved
        
        [Test]
        public void WhenRemovingTheNewLineCharTheNextRowIsRemoved_1()
        {
            var rows = this.CreateRows(new[] { 4, 0 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            var previousRowCount = inputBuffer.RowCount;
            inputBuffer.RemoveAt(0, 4);
            Assert.That(inputBuffer[0], Is.EquivalentTo("AAAA\n"));
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount - 1));
        }

        [Test]
        public void WhenRemovingTheNewLineCharTheNextRowIsRemoved_2()
        {
            var rows = this.CreateRows(new[] { 0, 0 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            var previousRowCount = inputBuffer.RowCount;
            inputBuffer.RemoveAt(0, inputBuffer.FirstColumnIndex);
            Assert.That(inputBuffer[0], Is.EquivalentTo("Test: \n"));
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount - 1));
        }

        [Test]
        public void WhenRemovingTheNewLineCharTheNextRowIsRemoved_3()
        {
            var rows = this.CreateRows(new[] { 4, 0 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            var previousRowCount = inputBuffer.RowCount;
            inputBuffer.RemoveAt(0, inputBuffer.FirstColumnIndex + 4);
            Assert.That(inputBuffer[0], Is.EquivalentTo("Test: AAAA\n"));
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount - 1));
        }

        [Test]
        public void WhenRemovingTheNewLineCharTheNextRowIsRemoved_4()
        {
            var rows = this.CreateRows(new[] { 0, 4, 0 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            var previousRowCount = inputBuffer.RowCount;
            inputBuffer.RemoveAt(1, 4);
            Assert.That(inputBuffer[1], Is.EquivalentTo("BBBB\n"));
            Assert.That(inputBuffer.RowCount, Is.EqualTo(previousRowCount - 1));
        }

        #endregion

        #region WhenRemovingTheNewLineCharTheCharsFromTheNextLineIsMovedUp

        [Test]
        public void WhenRemovingTheNewLineCharTheCharsFromTheNextLineIsMovedUp_1()
        {
            var rows = this.CreateRows(new[] { 0, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.RemoveAt(0, 0);
            Assert.That(inputBuffer[0], Is.EquivalentTo("BBBB\n"));
        }

        [Test]
        public void WhenRemovingTheNewLineCharTheCharsFromTheNextLineIsMovedUp_2()
        {
            var rows = this.CreateRows(new[] { 0, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.RemoveAt(0, inputBuffer.FirstColumnIndex);
            Assert.That(inputBuffer[0], Is.EquivalentTo("Test: BBBB\n"));
        }

        [Test]
        public void WhenRemovingTheNewLineCharTheCharsFromTheNextLineIsMovedUp_3()
        {
            var rows = this.CreateRows(new[] { 4, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("Test: ", rows);
            inputBuffer.RemoveAt(0, inputBuffer.FirstColumnIndex + 4);
            Assert.That(inputBuffer[0], Is.EquivalentTo("Test: AAAABBBB\n"));
        }

        [Test]
        public void WhenRemovingTheNewLineCharTheCharsFromTheNextLineIsMovedUp_4()
        {
            var rows = this.CreateRows(new[] { 0, 0, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.RemoveAt(1, 0);
            Assert.That(inputBuffer[1], Is.EquivalentTo("CCCC\n"));
        }

        [Test]
        public void WhenRemovingTheNewLineCharTheCharsFromTheNextLineIsMovedUp_5()
        {
            var rows = this.CreateRows(new[] { 0, 4, 4 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.RemoveAt(1, 4);
            Assert.That(inputBuffer[1], Is.EquivalentTo("BBBBCCCC\n"));
        }

        #endregion

        #region CharIsRemovedCorrectly

        [Test]
        public void CharIsRemovedCorrectly_1()
        {
            var rows = this.CreateRows(new[] { 1 });
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.RemoveAt(0, 0);
            Assert.That(inputBuffer[0], Is.EquivalentTo("\n"));
        }

        [Test]
        public void CharIsRemovedCorrectly_2()
        {
            var rows = this.CreateRows(new[] { 0 });
            rows[0] = new List<char>("ABC\n");
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.RemoveAt(0, 1);
            Assert.That(inputBuffer[0], Is.EquivalentTo("AC\n"));
        }

        [Test]
        public void CharIsRemovedCorrectly_3()
        {
            var rows = this.CreateRows(new[] { 4, 0 });
            rows[1] = new List<char>("ABC\n");
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.RemoveAt(1, 0);
            Assert.That(inputBuffer.RowCount, Is.EqualTo(2));
            Assert.That(inputBuffer[0], Is.EquivalentTo("AAAA\n"));
            Assert.That(inputBuffer[1], Is.EquivalentTo("BC\n"));
        }

        [Test]
        public void CharIsRemovedCorrectly_4()
        {
            var rows = this.CreateRows(new[] { 4, 0 });
            rows[1] = new List<char>("ABC\n");
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.RemoveAt(1, 1);
            Assert.That(inputBuffer.RowCount, Is.EqualTo(2));
            Assert.That(inputBuffer[0], Is.EquivalentTo("AAAA\n"));
            Assert.That(inputBuffer[1], Is.EquivalentTo("AC\n"));
        }

        [Test]
        public void CharIsRemovedCorrectly_5()
        {
            var rows = this.CreateRows(new[] { 4, 0 });
            rows[1] = new List<char>("ABC\n");
            var inputBuffer = this.CreateNewInputBufferContaining("", rows);
            inputBuffer.RemoveAt(1, 2);
            Assert.That(inputBuffer.RowCount, Is.EqualTo(2));
            Assert.That(inputBuffer[0], Is.EquivalentTo("AAAA\n"));
            Assert.That(inputBuffer[1], Is.EquivalentTo("AB\n"));
        }

        #endregion
    }
}