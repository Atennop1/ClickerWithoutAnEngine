namespace ClickerWithoutAnEngine.Tools
{
    public interface ISavesStorage
    {
        bool HasSaves();
        void DeleteAllSaves();
    }
}