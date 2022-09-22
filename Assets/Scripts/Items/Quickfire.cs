using UnityEngine;

namespace Scripts.Items
{
    [CreateAssetMenu(menuName = "Item/Weapon/Quickfire", fileName = "Quickfire")]
    public class Quickfire : Firearm
    {
        [SerializeField, Range(0, 100)] private float _fireRate;
    }
}
