namespace CSharp7Samples.Helpers
{
    public static class BoolExtensions
    {
        public static T ReturnIfTrue<T>(this bool b, T result)
        {
            if (b) return result;
            else return default(T);
        }
    }
}
