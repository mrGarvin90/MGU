namespace MGU.Console.Tests.Mocks
{
    using System;
    using Interfaces;

    public class ConsoleInformationMock : IConsoleInformation
    {
        #region Mock private fields

        private int _cursorLeft;
        private int _cursorTop;

        #endregion

        public int BufferWidth { get; }

        public int CursorLeft
        {
            get => this._cursorLeft;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Cannot be less than 0.");
                if (value >= this.BufferWidth)
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"Cannot be equal to or greater than {nameof(this.BufferWidth)}.");
                this._cursorLeft = value;
            }
        }

        public int CursorTop
        {
            get => this._cursorTop;
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Cannot be less than 0.");
                this._cursorTop = value;
            }
        }

        public ConsoleInformationMock(int bufferWidth)
        {
            this.BufferWidth = bufferWidth;
        }
    }
}