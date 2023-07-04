namespace ClickerWithoutAnEngine.Tools.Exceptions
{
    [Serializable]
    public sealed class HasNotSaveException : Exception
    {
        public HasNotSaveException(string message, string pathName) 
            : base($"Hasn't save for {message} with path: {pathName}") { }
    }
}