namespace MGU.Console.Interfaces.Input
{
    public interface ICursorInformation
    {
        int TopRow { get; }
        int BottomRow { get; }
        int FirstColumn { get; }
        int LastColumn { get; }
        int FirstColumnOfRow { get; }
        int LastColumnOfRow { get; }

        bool AtTopRow{ get; }
        bool AtBottomRow{ get; }
        bool AtFirstColumn{ get; }
        bool AtLastColumn{ get; }
        bool AtStartOfRow{ get; }
        bool AtEndOfRow{ get; }

        ICursorInformation Reset(IReadOnlyInputBuffer buffer, int topRow);
    }
}