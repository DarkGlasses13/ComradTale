using UnityEngine;

namespace Scripts.Items
{
    public class Firearm : Weapon
    {
        [SerializeField] private float _capacity;

        public float Capacity => _capacity;
    }
}
