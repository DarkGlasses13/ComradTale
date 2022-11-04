using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

namespace Database
{
    public class ItemDatabase
    {
        private readonly List<ItemData> _items;

        public ItemDatabase()
        {
            _items = JsonConvert.DeserializeObject<List<ItemData>>(Resources.Load<TextAsset>("Database/ItemDatabase").ToString());
        }
    }
}