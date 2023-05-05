using ClickerWithoutAnEngine.Tools.Exceptions;
using ClickerWithoutAnEngine.Tools.Paths;
using Newtonsoft.Json;

namespace ClickerWithoutAnEngine.Tools
{
    public sealed class JsonStorage<TStoreValue> : ISaveStorage<TStoreValue>
    {
        private readonly string _pathName;

        public JsonStorage(IPath path)
        {
            if (path == null)
                throw new ArgumentNullException(nameof(path));

            _pathName = path.Name;
        }

        public bool HasSave() => File.Exists(_pathName);

        public TStoreValue Load()
        {
            if (HasSave() == false)
                throw new HasNotSaveException(nameof(TStoreValue), _pathName);
            
            var saveJson = File.ReadAllText(_pathName);
            return JsonConvert.DeserializeObject<TStoreValue>(saveJson);
        }

        public void Save(TStoreValue value)
        {
            var saveJson = JsonConvert.SerializeObject(value);
            File.WriteAllText(_pathName, saveJson);
        }
        
        public void DeleteSave()
        {
            if (HasSave() == false)
                throw new CannotDeleteSaveException(nameof(TStoreValue), _pathName);
            
            File.Delete(_pathName);
        }
    }
}