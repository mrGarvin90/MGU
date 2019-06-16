namespace MGU.Console.Interfaces.Input
{
    using System.Collections.Generic;

    public interface IReadOnlyInputBuffer : IEnumerable<IEnumerable<char>>
    {
        IEnumerable<char> this[int rowIndex] { get; }
        char this[int rowIndex, int columnIndex] { get; }
        int TopRowIndex { get; }
        int FirstColumnIndex { get; }
        int RowCount { get; }
        int InputCharCount { get; }
        bool ContainsInput { get; }
        string Prompt { get; }
        string InputToString();
    }
}