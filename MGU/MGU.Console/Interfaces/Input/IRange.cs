namespace MGU.Console.Interfaces.Input
{
    public interface IRange
    {
        string ErrorMessage { get; }
        bool WithinRange(object obj);
        string MinValueToString();
        string MaxValueToString();
    }
}