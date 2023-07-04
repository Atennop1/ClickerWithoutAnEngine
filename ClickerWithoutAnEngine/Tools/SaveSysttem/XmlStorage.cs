using System.Xml.Serialization;
using ClickerWithoutAnEngine.Tools.Exceptions;
using ClickerWithoutAnEngine.Tools.Paths;

namespace ClickerWithoutAnEngine.Tools
{
    public sealed class XmlStorage<TStoreValue> : ISaveStorage<TStoreValue>
    {
        private readonly string _pathName;

        public XmlStorage(IPath path)
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

            var serializer = new XmlSerializer(typeof(TStoreValue));
            var fileText = File.ReadAllText(_pathName);
            
            using var stringReader = new StringReader(fileText);
            return (TStoreValue)serializer.Deserialize(stringReader)!;
        }

        public void Save(TStoreValue value)
        {
            var serializer = new XmlSerializer(typeof(TStoreValue));
            using var fileStream = new FileStream(_pathName, FileMode.Create);
            serializer.Serialize(fileStream, value);
        }
    }
}