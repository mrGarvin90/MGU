namespace MGU.Console.Utilities.Input
{
    using System;
    using System.Linq;
    using Core.Extensions.If;
    using Interfaces;
    using Interfaces.Input;

    public class CursorInformation : ICursorInformation
    {
        private IReadOnlyInputBuffer _buffer;
        private readonly IConsoleInformation _consoleInformation;

        public int TopRow { get; private set; }

        public int BottomRow
        {
            get
            {
                var bottomRow = this.TopRow;
                for (var rowIndex = this._buffer.TopRowIndex; rowIndex < this._buffer.RowCount; rowIndex++)
                    bottomRow += this.CalculateSubRowCount(this._buffer[rowIndex].Count());
                return bottomRow - 1;
            }
        }
        public int FirstColumn { get; private set; }

        public int LastColumn
        {
            get
            {
                var charCountOfBottomRow = this._buffer[this._buffer.RowCount - 1].Count() - 1;
                var lastColumn = charCountOfBottomRow % this._consoleInformation.BufferWidth;
                return lastColumn;
            }
        }
        public int FirstColumnOfRow => this.AtTopRow ? this.FirstColumn : 0;
        public int LastColumnOfRow
        {
            get
            {
                if (this.AtBottomRow)
                    return this.LastColumn;
                if (this.AtBottomSubRow())
                    return this._buffer[this._consoleInformation.CursorTop - this.TopRow].Count() - 1;
                return this._consoleInformation.BufferWidth;
            }
        }

        public CursorInformation(IReadOnlyInputBuffer buffer, int topRow, IConsoleInformation consoleInformation)
        {
            this.ValidateInparameters(buffer, topRow);

            this._buffer = buffer;
            this.TopRow = topRow;
            this.FirstColumn = this._buffer.FirstColumnIndex;
            this._consoleInformation = consoleInformation.If().Null.Throw().Null(nameof(consoleInformation));
        }

        private void ValidateInparameters(IReadOnlyInputBuffer buffer, int topRow)
        {
            buffer.If().Null.Throw().Null(nameof(buffer));
            topRow.If().LessThan(0).Throw().OutOfRange(nameof(topRow), topRow, "Cannot be less than 0");
        }

        public bool AtTopRow => this._consoleInformation.CursorTop == this.TopRow;

        public bool AtBottomRow => this._consoleInformation.CursorTop == this.BottomRow;

        public bool AtFirstColumn => this.AtTopRow && this._consoleInformation.CursorLeft == this.FirstColumn;

        public bool AtLastColumn => this.AtBottomRow && this._consoleInformation.CursorLeft == this.LastColumn;

        public bool AtStartOfRow => this._consoleInformation.CursorLeft == this.FirstColumnOfRow;

        public bool AtEndOfRow => this._consoleInformation.CursorLeft == this.LastColumnOfRow;

        public ICursorInformation Reset(IReadOnlyInputBuffer buffer, int topRow)
        {
            this.ValidateInparameters(buffer, topRow);

            this._buffer = buffer;
            this.TopRow = topRow;
            this.FirstColumn = this._buffer.FirstColumnIndex;

            return this;
        }

        private bool AtBottomSubRow()
        {
            var minCursorTop = this.TopRow;
            var cursorTop = this._consoleInformation.CursorTop;
            for (var bufferRowIndex = 0; bufferRowIndex < this._buffer.RowCount; bufferRowIndex++)
            {
                var subRowCount = this.CalculateSubRowCount(this._buffer[bufferRowIndex].Count());
                var maxCursorTop = minCursorTop + subRowCount;
                if (minCursorTop <= cursorTop && cursorTop < maxCursorTop)
                {
                    var subRowIndex = cursorTop - minCursorTop;
                    return subRowIndex == subRowCount - 1;
                }
                minCursorTop = maxCursorTop;
            }
            throw new OperationCanceledException("Could not calculate sub row index.");
        }

        private int CalculateSubRowCount(int charCount)
        {
            var numberOfSubRows = charCount / this._consoleInformation.BufferWidth;
            if (numberOfSubRows == 0)
                return 1;
            if (charCount % this._consoleInformation.BufferWidth == 0)
                return numberOfSubRows;
            return numberOfSubRows + 1;
        }
    }
}