namespace MGU.Console.Interfaces
{
    public interface IConsoleInformation
    {
        int BufferWidth { get; }
        int CursorTop { get; set; }
        int CursorLeft { get; set; }
    }
}