namespace MGU.Console.Utilities.Input
{
    using Interfaces;
    using Interfaces.Input;

    public class InputDependenciesFactory
    {
        private readonly IConsoleInformation _consoleInformation;

        public InputDependenciesFactory(IConsoleInformation consoleInformation)
        {
            this._consoleInformation = consoleInformation;
        }

        public IInputBuffer CreateInputBuffer(string prompt) => new InputBuffer(prompt);

        public ICursorInformation CreateCursorInformation(IReadOnlyInputBuffer buffer, int startCursorTop) => new CursorInformation(buffer, startCursorTop, this._consoleInformation);

        public ICursorNavigation CreateCursorNavigation(ICursorInformation information) => new CursorNavigation(information, this._consoleInformation);

        public IInputPositionCalculator CreateInputPositionCalculator(IReadOnlyInputBuffer buffer, int startCursorTop) => new InputPositionCalculator(buffer, startCursorTop, this._consoleInformation);
    }
}