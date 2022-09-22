using UnityEngine;

namespace Scripts.Items
{
    [CreateAssetMenu(menuName = "Item/Valuable", fileName = "Valuable")]
    public class Valuable : ItemData
    {
        public override ItemTypes Type => ItemTypes.Valuable;
    }
}
