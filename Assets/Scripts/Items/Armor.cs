using UnityEngine;

namespace Scripts.Items
{
    [CreateAssetMenu(menuName = "Item/Armor", fileName = "Armor")]
    public class Armor : ItemData
    {
        [SerializeField] private float _protection;

        public override ItemTypes Type => ItemTypes.Armor;
        public float Protection => _protection;
    }
}
