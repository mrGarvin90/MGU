namespace MGU.Console.Utilities.Menu
{
    using System;
    using Core.Extensions.If;
    using Interfaces.Menu;

    public class MenuFunc : IMenuFunc
    {
        private readonly Func<PostInvokeCommand> _func;

        public string Label { get; }
        
        public MenuFunc(string label, Func<PostInvokeCommand> func)
        {
            this.Label = label
                .If().Null.Throw().Null(nameof(label))
                .If().Empty.Throw().Argument("Cannot be empty.", nameof(label));

            this._func = func.If().Null.Throw().Null(nameof(func));
        }

        public PostInvokeCommand Invoke()
            => this._func.Invoke();
    }
}