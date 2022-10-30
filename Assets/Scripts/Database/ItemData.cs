using System;

namespace Database
{
    [Serializable]
    public class ItemData
    {
        public int Id;
        public string Title;
        public string Description;
        public int Price;
        public int Stack;

        public ItemData(int id, string title, string description, int price, int stack)
        {
            Id = id;
            Title = title;
            Description = description;
            Price = price;
            Stack = stack;
        }
    }
}
