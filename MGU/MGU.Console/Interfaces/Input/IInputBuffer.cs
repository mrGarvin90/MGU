namespace MGU.Console.Interfaces.Input
{
    public interface IInputBuffer : IReadOnlyInputBuffer
    {
        void Insert(int rowIndex, int columnIndex, char character);
        void RemoveAt(int rowIndex, int columnIndex);
        IInputBuffer Reset(string newPrompt);
    }
}