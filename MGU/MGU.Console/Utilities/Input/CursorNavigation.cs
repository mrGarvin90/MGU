namespace MGU.Console.Utilities.Input
{
    using Core.Extensions.If;
    using Interfaces;
    using Interfaces.Input;

    public class CursorNavigation : ICursorNavigation
    {
        private ICursorInformation _information;
        private readonly IConsoleInformation _consoleInformation;

        private int CursorTop
        {
            get => this._consoleInformation.CursorTop;
            set => this._consoleInformation.CursorTop = value;
        }

        private int CursorLeft
        {
            get => this._consoleInformation.CursorLeft;
            set
            {
                if (value < 0)
                {
                    this._consoleInformation.CursorLeft = this._consoleInformation.BufferWidth - 1;
                    this._consoleInformation.CursorTop--;
                }
                else if (value >= this._consoleInformation.BufferWidth)
                {
                    this._consoleInformation.CursorLeft = 0;
                    this._consoleInformation.CursorTop++;
                }
                else
                    this._consoleInformation.CursorLeft = value;
            }
        }

        public CursorNavigation(ICursorInformation information, IConsoleInformation consoleInformation)
        {
            this._information = information.If().Null.Throw().Null(nameof(information));
            this._consoleInformation = consoleInformation.If().Null.Throw().Null(nameof(consoleInformation));
        }

        public void MoveLeft()
        {
            if (this._information.AtFirstColumn)
                return;
            this.CursorLeft--;
            if (this.CursorLeft > this._information.LastColumnOfRow)
                this.CursorLeft = this._information.LastColumnOfRow;
        }

        public void MoveRight()
        {
            if (this._information.AtLastColumn)
                return;
            this.CursorLeft++;
            if (!this._information.AtBottomRow && this.CursorLeft > this._information.LastColumnOfRow)
            {
                this.CursorTop++;
                this.CursorLeft = 0;
            }
        }

        public void MoveUp()
        {
            if (this._information.AtTopRow)
                return;
            this.CursorTop--;
            if (this._information.AtTopRow && this.CursorLeft < this._information.FirstColumn)
                this.CursorLeft = this._information.FirstColumn;
            else if (this.CursorLeft > this._information.LastColumnOfRow)
                this.CursorLeft = this._information.LastColumnOfRow;
        }

        public void MoveDown()
        {
            if (this._information.AtBottomRow)
                return;
            this.CursorTop++;
            if (this._information.AtBottomRow && this.CursorLeft > this._information.LastColumn)
                this.CursorLeft = this._information.LastColumn;
            else if (this.CursorLeft > this._information.LastColumnOfRow)
                this.CursorLeft = this._information.LastColumnOfRow;
        }

        public void MoveToStartOfRow()
        {
            this.CursorLeft = this._information.FirstColumnOfRow;
        }

        public void MoveToEndOfRow()
        {
            this.CursorLeft = this._information.LastColumnOfRow;
        }

        public void MoveToTopRow()
        {
            if (this._information.AtTopRow)
                return;
            this.CursorTop = this._information.TopRow;
            if (this.CursorLeft < this._information.FirstColumn)
                this.CursorLeft = this._information.FirstColumn;
        }

        public void MoveToBottomRow()
        {
            if (this._information.AtBottomRow)
                return;
            this.CursorTop = this._information.BottomRow;
            if (this.CursorLeft > this._information.LastColumn)
                this.CursorLeft = this._information.LastColumn;
        }

        public ICursorNavigation Rest(ICursorInformation information)
        {
            this._information = information.If().Null.Throw().Null(nameof(information));

            return this;
        }
    }
}