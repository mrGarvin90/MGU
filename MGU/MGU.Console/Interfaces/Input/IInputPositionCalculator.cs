namespace MGU.Console.Interfaces.Input
{
    public interface IInputPositionCalculator
    {
        (int bufferRowIndex, int bufferColumnIndex) CalculatePositionInInputBuffer(int cursorTop, int cursorLeft);
        (int cursorTop, int cursorLeft) CalculatePositionInConsole(int bufferRowIndex, int bufferColumnIndex);
        IInputPositionCalculator Reset(IReadOnlyInputBuffer buffer, int startCursorTop);
    }
}