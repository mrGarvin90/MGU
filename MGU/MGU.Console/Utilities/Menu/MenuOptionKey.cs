namespace MGU.Console.Utilities.Menu
{
    public enum MenuOptionKey
    {
        Zero,
        One,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
        I,
        J,
        K,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z
    }

    public static class MenuOptionKeyExtensions
    {
        public static string ToCleanString(this MenuOptionKey key)
        {
            var keyNumber = (int)key;
            return keyNumber <= 9 ? keyNumber.ToString() : key.ToString();
        }
    }
}