namespace ClickerWithoutAnEngine.Tools.Paths
{
    public sealed class Path : IPath
    {
        public string Name { get; }
        private readonly string _savesFolder = AppDomain.CurrentDomain.BaseDirectory + "Game-Saves";

        public Path(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            if (!Directory.Exists(_savesFolder)) 
                Directory.CreateDirectory(_savesFolder);

            Name = System.IO.Path.Combine(_savesFolder, name);
        }
    }
}