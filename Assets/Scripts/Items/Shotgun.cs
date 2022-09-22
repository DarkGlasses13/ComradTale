using UnityEngine;

namespace Scripts.Items
{
    [CreateAssetMenu(menuName = "Item/Weapon/Shotgun", fileName = "Shotgun")]
    public class Shotgun : Firearm
    {
        [SerializeField, Range(5, 180)] private int _scatter;
    }
}
