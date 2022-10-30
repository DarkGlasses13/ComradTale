using System.Collections.Generic;
using UnityEngine;

namespace Database
{
    public class ItemDatabase
    {
        private List<ItemData> _items = new();
        private readonly char _cellSeparator = ',';
        private readonly char _inCellSeparator = ';';

        public ItemDatabase()
        {
            ProcessData(Resources.Load<TextAsset>("Database/ItemsSheet"));
        }

        private void ProcessData(TextAsset data)
        {
            int titleIndex = 0;
            int descriptionIndex = 1;
            int priceIndex = 2;
            int stackIndex = 3;
            string[] rows = data.text.Split('\n');
            int dataRawIndex = 1;

            for (int i = dataRawIndex; i < rows.Length; i++)
            {
                string[] cells = rows[i].Split(_cellSeparator);

                string title = cells[titleIndex];
                string description = cells[descriptionIndex];
                int price = int.Parse(cells[priceIndex]);
                int stack = int.Parse(cells[stackIndex]);
                // floatParse(cells[floatValueIndex], Globalization.NumberStyle.Any, Globalization.CultureInfo.GetCultureInfo("en-US"), out floatValue)

                _items.Add(new ItemData(i, title, description, price, stack));
            }
        }
    }
}