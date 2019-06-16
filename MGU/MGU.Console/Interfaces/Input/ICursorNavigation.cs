namespace MGU.Console.Interfaces.Input
{
    public interface ICursorNavigation
    {
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
        void MoveToStartOfRow();
        void MoveToEndOfRow();
        void MoveToTopRow();
        void MoveToBottomRow();

        ICursorNavigation Rest(ICursorInformation information);
    }
}