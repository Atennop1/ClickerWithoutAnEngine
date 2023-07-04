namespace ClickerWithoutAnEngine.Tools.Exceptions
{
    [Serializable]
    public sealed class CannotDeleteSaveException : Exception
    {
        public CannotDeleteSaveException(string message, string pathName) 
            : base($"Hasn't save for {message} with path: {pathName}. You can't delete save!") { }
    }
}