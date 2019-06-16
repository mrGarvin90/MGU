namespace MGU.Console.Utilities.Input
{
    using System;
    using System.Linq;
    using Core.Extensions.If;
    using Interfaces;
    using Interfaces.Input;

    public class InputPositionCalculator : IInputPositionCalculator
    {
        private IReadOnlyInputBuffer _buffer;
        private readonly IConsoleInformation _consoleInformation;
        private int _topRow;

        public InputPositionCalculator(IReadOnlyInputBuffer buffer, int topRow, IConsoleInformation consoleInformation)
        {
            this.ValidateInparameters(buffer, topRow);

            this._buffer = buffer;
            this._topRow = topRow;
            this._consoleInformation = consoleInformation
                .If().Null.Throw().Null(nameof(consoleInformation));
        }

        private void ValidateInparameters(IReadOnlyInputBuffer buffer, int startCursorTop)
        {
            buffer.If().Null.Throw().Null(nameof(buffer));
            startCursorTop.If().LessThan(0).Throw().OutOfRange(nameof(startCursorTop), 0, "Cannot be less than 0.");
        }

        public (int bufferRowIndex, int bufferColumnIndex) CalculatePositionInInputBuffer(int cursorTop, int cursorLeft)
        {
            var (bufferrowindex, subrowindex) = this.CalculateBufferRowIndexAndSubRowIndex(cursorTop);
            var columnIndex = cursorLeft + subrowindex * this._consoleInformation.BufferWidth;
            return (bufferrowindex, columnIndex);
        }

        public (int cursorTop, int cursorLeft) CalculatePositionInConsole(int bufferRowIndex, int bufferColumnIndex)
        {
            var minCursorTop = this._topRow;
            var cursorTop = this._consoleInformation.CursorTop;
            for (var index = bufferRowIndex; index < this._buffer.RowCount; index++)
            {
                var subRowCount = this.CalculateSubRowCount(this._buffer[index].Count());
                var maxCursorTop = minCursorTop + subRowCount;
                if (minCursorTop < cursorTop && cursorTop < maxCursorTop)
                {
                    cursorTop -= minCursorTop;
                    var cursorLeft = bufferColumnIndex % this._consoleInformation.BufferWidth;
                    return (cursorTop, cursorLeft);
                }
                minCursorTop = maxCursorTop;
            }
            throw new OperationCanceledException("Could not calculate position in Console.");
        }

        public IInputPositionCalculator Reset(IReadOnlyInputBuffer buffer, int startCursorTop)
        {
            this.ValidateInparameters(buffer, startCursorTop);
            this._buffer = buffer;
            this._topRow = startCursorTop;
            return this;
        }

        private (int bufferRowIndex, int subRowIndex) CalculateBufferRowIndexAndSubRowIndex(int cursorTop)
        {
            var minCursorTop = this._topRow;
            for (var bufferRowIndex = 0; bufferRowIndex < this._buffer.RowCount; bufferRowIndex++)
            {
                var subRowCount = this.CalculateSubRowCount(this._buffer[bufferRowIndex].Count());
                var maxCursorTop = minCursorTop + subRowCount;
                if (minCursorTop <= cursorTop && cursorTop < maxCursorTop)
                {
                    var subRowIndex = cursorTop - minCursorTop;
                    return (bufferRowIndex, subRowIndex);
                }
                minCursorTop = maxCursorTop;
            }
            throw new OperationCanceledException("Could not calculate buffer row index and sub row index.");
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