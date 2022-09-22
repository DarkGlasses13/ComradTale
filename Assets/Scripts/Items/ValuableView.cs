using UnityEngine;

namespace Scripts.Items
{
    public class ValuableView : MonoBehaviour
    {
        private MeshFilter _meshFilter;
        private MeshCollider _collider;

        public Valuable Data { get; private set; }

        private void Awake()
        {
            _meshFilter = GetComponent<MeshFilter>();
            _collider = GetComponent<MeshCollider>();
        }

        public void ReceiveData(ItemData data)
        {
            _meshFilter.mesh = data.Mesh;
            _collider.sharedMesh = data.Mesh;
        }
    }
}
