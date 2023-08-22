using UnityEngine;

namespace VoxInvasion.Runtime.TankPhysics
{
    public class Tank : MonoBehaviour
    {
        [SerializeField] Rigidbody _rigidbody;
        public Rigidbody Rigidbody => _rigidbody;
    
        [SerializeField] Collider _collider;
        public Collider Collider => _collider;
    }
}
