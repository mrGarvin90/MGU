namespace MGU.Console.Interfaces.Menu
{
    public interface IMenu : INonInvokableMenu, IInvokable
    {
        void InvokeAsRootMenu();
    }
}