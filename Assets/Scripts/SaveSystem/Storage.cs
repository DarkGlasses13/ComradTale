using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using SaveSystem.Surrogates;
using UnityEngine;

namespace SaveSystem
{
    public class Storage
    {
        private BinaryFormatter _formatter;

        public string DirectoryPath { get; private set; } = Application.persistentDataPath + "/Saves";
        public string FilePath { get; private set; }

        public Storage()
        {
            if (Directory.Exists(DirectoryPath) == false)
            {
                Directory.CreateDirectory(DirectoryPath);
            }

            FilePath = $"{DirectoryPath}/gameSave.save";
            _formatter = new BinaryFormatter();
            SurrogateSelector surrogateSelector = new();
            surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), new Vector3Surrogate());
            surrogateSelector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), new QuaternionSurrogate());
            _formatter.SurrogateSelector = surrogateSelector;
        }

        public void Save(object data)
        {
            FileStream fileStream = File.Create(FilePath);
            _formatter.Serialize(fileStream, data);
            fileStream.Close();
        }

        public object Load(object dataByDefault)
        {
            if (File.Exists(FilePath))
            {
                FileStream fileStream = File.Open(FilePath, FileMode.Open);
                var saveData = _formatter.Deserialize(fileStream);
                fileStream.Close();
                return saveData;
            }

            if (dataByDefault != null)
            {
                ResetByDefault(dataByDefault);
                return dataByDefault;
            }

            throw new Exception("Failed to load game data");
        }

        public void ResetByDefault(object dataByDefault) => Save(dataByDefault);
    }
}
