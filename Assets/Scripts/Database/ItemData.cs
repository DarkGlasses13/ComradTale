using System;
using System.Collections.Generic;
using System.Linq;

namespace Database
{
    [Serializable]
    public class ItemData
    {
        private List<Stat> _stats;
        public string Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public int Price { get; private set; }
        public int Stack { get; private set; }

        [Newtonsoft.Json.JsonConstructor]
        public ItemData(string title, string description, int price, int stack, List<Stat> stats)
        {
            Id = $"it_{title}";
            Title = title;
            Description = description;
            Price = price;
            Stack = stack;
            _stats = stats;
        }

        public Stat GetStat(Stats title) => _stats.SingleOrDefault(stat => stat.Title.Equals(title.ToString()));
    }
}
