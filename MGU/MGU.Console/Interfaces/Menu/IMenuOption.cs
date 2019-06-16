namespace MGU.Console.Interfaces.Menu
{
    using Utilities.Menu;

    public interface IMenuOption : IMenuOption<IMenuItem>
    {
    }

    public interface IMenuOption<out T>
    {
        MenuOptionKey Key { get; }
        T Item { get; }
    }
}