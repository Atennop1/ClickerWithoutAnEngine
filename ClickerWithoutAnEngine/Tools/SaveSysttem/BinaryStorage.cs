using System.Runtime.Serialization.Formatters.Binary;
using ClickerWithoutAnEngine.Tools.Exceptions;
using ClickerWithoutAnEngine.Tools.Paths;

namespace ClickerWithoutAnEngine.Tools
{
    public sealed class BinaryStorage<TStoreValue> : ISaveStorage<TStoreValue>
    {
        private readonly BinaryFormatter _formatter = new();
        private readonly string _pathName;

        public BinaryStorage(IPath path)
        {
            if (path is null)
                throw new ArgumentNullException(nameof(path));

            _pathName = path.Name;
        }
        
        public bool HasSave() 
            => File.Exists(_pathName);

        public void DeleteSave()
        {
            if (HasSave() == false)
                throw new CannotDeleteSaveException(nameof(TStoreValue), _pathName);

            File.Delete(_pathName);
        }

        public TStoreValue Load()
        {
            if (HasSave() == false)
                throw new HasNotSaveException(nameof(TStoreValue), _pathName);

            using var file = File.Open(_pathName, FileMode.Open);
            return (TStoreValue)_formatter.Deserialize(file);
        }

        public void Save(TStoreValue value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            
            using var file = File.Create(_pathName);
            _formatter.Serialize(file, value);
        }
    }
}