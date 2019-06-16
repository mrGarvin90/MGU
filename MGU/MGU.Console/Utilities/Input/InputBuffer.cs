namespace MGU.Console.Utilities.Input
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Core.Extensions.If;
    using Interfaces.Input;

    public class InputBuffer : IInputBuffer
    {
        private readonly List<List<char>> _rows = new List<List<char>>();
        public IEnumerable<char> this[int rowIndex] => this._rows[rowIndex];
        public char this[int rowIndex, int columnIndex] => this._rows[rowIndex][columnIndex];
        public int TopRowIndex { get; private set; }
        public int FirstColumnIndex { get; private set; }
        public int RowCount => this._rows.Count;

        public int InputCharCount
        {
            get
            {
                var charCount = this._rows[this.TopRowIndex].Count - this.FirstColumnIndex;
                if ((this.TopRowIndex == 0 && this.RowCount == 1) || (this.TopRowIndex == 1 && this.RowCount == 2))
                    return charCount - 1;
                for (var rowIndex = this.TopRowIndex + 1; rowIndex < this.RowCount - 1; rowIndex++)
                    charCount += this._rows[rowIndex].Count;
                var lastRowCharCount = this._rows[this.RowCount - 1].Count;
                charCount += lastRowCharCount > 1 ? lastRowCharCount - 1 : lastRowCharCount;
                return charCount;
            }
        }

        public bool ContainsInput => this.InputCharCount > 0;

        public string Prompt { get; private set; }

        public InputBuffer(string prompt)
        {
            this.SetProperties(prompt);
        }

        private void SetProperties(string prompt)
        {
            ValidatePrompt();

            this.Prompt = prompt;
            this._rows.Add(new List<char>(prompt));
            if (prompt.LastOrDefault() == '\n')
            {
                this._rows.Add(new List<char> { '\n' });
                this.TopRowIndex = 1;
                this.FirstColumnIndex = 0;
            }
            else
            {
                this._rows[0].Add('\n');
                this.TopRowIndex = 0;
                this.FirstColumnIndex = prompt.Length;
            }

            void ValidatePrompt()
            {
                prompt
                    .If().Null.Throw().Null(nameof(prompt))
                    .If().Contains("\0").Throw().Argument("Cannot contain null char.", nameof(prompt))
                    .If().Contains("\r").Throw().Argument("Cannot contain return char.", nameof(prompt))
                    .If().Contains("\t").Throw().Argument("Cannot contain tab char.", nameof(prompt));

                var newLineCharCount = prompt.Count(c => c == '\n')
                    .If().GreaterThan(1).Throw().Argument("Can only contain one new line char.", nameof(prompt));

                if (newLineCharCount == 1 && prompt.Last() != '\n')
                    throw new ArgumentException("A new line char must be the last char.", nameof(prompt));
            }
        }

        public void Insert(int rowIndex, int columnIndex, char character)
        {
            ValidateCharacter();
            ValidateRowIndex();
            ValidateColumnIndex();

            if (character == '\n')
                InsertRow();
            else
                this._rows[rowIndex].Insert(columnIndex, character);

            void ValidateCharacter()
            {
                switch (character)
                {
                    case '\0':
                        throw new InvalidOperationException("Cannot insert null char ('\\0').");
                    case '\r':
                        throw new InvalidOperationException("Cannot insert return char ('\\r').");
                    case '\t':
                        throw new InvalidOperationException("Cannot insert tab char ('\\t').");
                }
            }

            void ValidateRowIndex()
            {
                if (rowIndex < this.TopRowIndex)
                    throw new InvalidOperationException($"Cannot insert at index less than {nameof(this.TopRowIndex)}.");
            }

            void ValidateColumnIndex()
            {
                if (rowIndex == 0 && columnIndex < this.FirstColumnIndex)
                    throw new InvalidOperationException($"Cannot insert at index less than {nameof(this.FirstColumnIndex)}.");
                if (this._rows[rowIndex].Count == 0 || columnIndex != this._rows[rowIndex].Count)
                    return;
                if (this._rows[rowIndex][this._rows[rowIndex].Count - 1] == '\n')
                    throw new InvalidOperationException("Cannot insert a char after a new line char.");
            }

            void InsertRow()
            {
                if (columnIndex == this._rows[rowIndex].Count - 1)
                    this._rows.Insert(rowIndex + 1, new List<char>(new string('\n', 1)));
                else
                {
                    var count = this._rows[rowIndex].Count - columnIndex;
                    var trailingChars = this._rows[rowIndex].GetRange(columnIndex, count);
                    this._rows.Insert(rowIndex + 1, new List<char>(trailingChars));
                    this._rows[rowIndex].RemoveRange(columnIndex, count - 1);
                }
            }
        }

        public void RemoveAt(int rowIndex, int columnIndex)
        {
            if (AtLastRow() && AtLastColumnOfRow())
                return;
            ValidateRowIndex();
            if (AtLastColumnOfRow())
                RemoveRow();
            else
            {
                ValidateColumnIndex();
                this._rows[rowIndex].RemoveAt(columnIndex);
            }

            bool AtLastRow() => rowIndex == this._rows.Count - 1;

            bool AtLastColumnOfRow() => columnIndex == this._rows[rowIndex].Count - 1;

            void ValidateRowIndex()
            {
                if (rowIndex < this.TopRowIndex)
                    throw new InvalidOperationException($"Cannot remove at index less than {nameof(this.TopRowIndex)}.");
            }

            void ValidateColumnIndex()
            {
                if (rowIndex == 0 && columnIndex < this.FirstColumnIndex)
                    throw new InvalidOperationException($"Cannot remove at index less than {nameof(this.FirstColumnIndex)}.");
            }

            void RemoveRow()
            {
                var nextRowIndex = rowIndex + 1;
                var nextRow = this._rows[nextRowIndex];
                var count = nextRow.Count - 1;
                var charsToMove = nextRow.GetRange(0, count);
                this._rows[rowIndex].InsertRange(this._rows[rowIndex].Count - 1, charsToMove);
                this._rows.RemoveAt(nextRowIndex);
            }
        }

        public IInputBuffer Reset(string newPrompt)
        {
            this._rows.Clear();
            this.SetProperties(newPrompt);
            return this;
        }

        public string InputToString()
        {
            var stringBuilder = new StringBuilder();
            var lastIndex = this.RowCount - 1;
            string rowAsString;
            int charCount;
            var columnIndex = this.FirstColumnIndex;
            for (var i = this.TopRowIndex; i < lastIndex; i++)
            {
                charCount = this._rows[i].Count - columnIndex;
                rowAsString = this._rows[i].EnumerableRangeToString(columnIndex, charCount);
                stringBuilder.Append(rowAsString);
                columnIndex = 0;
            }
            charCount = this._rows[lastIndex].Count - columnIndex - 1;
            rowAsString = this._rows[lastIndex].EnumerableRangeToString(columnIndex, charCount);
            stringBuilder.Append(rowAsString);
            return stringBuilder.ToString();
        }

        public override string ToString()
        {
            var stringBuilder = new StringBuilder();
            foreach (var row in this._rows)
                stringBuilder.Append(row.EnumerableToString());
            return stringBuilder.ToString();
        }

        public IEnumerator<IEnumerable<char>> GetEnumerator()
        {
            return this._rows.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}