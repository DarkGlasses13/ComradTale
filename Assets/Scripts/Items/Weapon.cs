using UnityEngine;

namespace Scripts.Items
{
    public class Weapon : ItemData
    {
        [SerializeField] private float _damage;

        public override ItemTypes Type => ItemTypes.Weapon;
        public float Damage => _damage;
    }
}
