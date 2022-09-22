using UnityEngine;

namespace Scripts.Items
{
    public abstract class ItemData : ScriptableObject
    {
        [SerializeField] private string _title;
        [SerializeField, TextArea(5, 100)] private string _description;
        [SerializeField] private int _price;
        [SerializeField] private Mesh _mesh;

        public abstract ItemTypes Type { get; }
        public Mesh Mesh => _mesh;
        public string Title => _title;
        public string Description => _description;
        public int Price => _price;
    }
}
