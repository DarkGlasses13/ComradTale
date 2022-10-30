using Input;
using UnityEngine;

namespace SaveSystem
{
    public class SaveDataProvider
    {
        public GameData GameData;
        private Storage _storage;

        public SaveDataProvider(Storage storage)
        {
            _storage = storage;
            GameData defaultGameData = new GameData();
            GameData = (GameData)_storage.Load(defaultGameData);
            Controls controls = new();
            controls.Enable();
            controls.Storage.Save.performed += callbackContext => _storage.Save(GameData);
            controls.Storage.Load.performed += callbackContext => _storage.Load(defaultGameData);
            Application.quitting += () => _storage.Save(GameData);
        }
    }
}
