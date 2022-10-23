using System;

namespace Items
{
    [Serializable]
    public class ItemData
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Price { get; private set; }
    }
}
