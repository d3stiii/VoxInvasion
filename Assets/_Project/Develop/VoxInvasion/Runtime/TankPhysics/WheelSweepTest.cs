using UnityEngine;

namespace VoxInvasion.Runtime.TankPhysics
{
    public class WheelSweepTest : MonoBehaviour
    {
        [SerializeField] private Tank _tank;
        [SerializeField] private Collider _collider;
        [SerializeField] private Transform _wheelModel;
        [SerializeField] private Vector3 _gizmosPositionOffset;
        [SerializeField] private Vector3 _gizomsRotationOffset;
 
        [Space]
        [SerializeField] private float _wheelRadius;
        [SerializeField] private float _torqueSpeed;
        [SerializeField] private float _tireGrip;

        [Space]
        [SerializeField] private float _restLength;
        [SerializeField] private float _springStiffness;
        [SerializeField] private float _damperStiffness;
        [SerializeField] private float _minLength;
        [SerializeField] private float _maxLength;
    
        private float _lastLength;
        private float _springLength;
        private float _springVelocity;
        private float _springForce;
        private float _damperForce;
        private Mesh _wheelMesh;
        private Vector3 _wheelModelPosition;
        private Rigidbody _wheelRigidbody;

        private void OnValidate()
        {
            _wheelMesh = _wheelModel.GetComponent<MeshCollider>().sharedMesh;
            _wheelModelPosition = transform.position;
        }

        void Awake()
        {
            _wheelRigidbody = GetComponent<Rigidbody>();

            Physics.IgnoreCollision(_collider, _tank.Collider);
            Physics.IgnoreCollision(_collider, _wheelModel.GetComponent<MeshCollider>());
        }

        void FixedUpdate()
        {

            //Debug.Log($"angle {Vector3.Angle(transform.right, _tank.Rigidbody.velocity)}");
            /*if (_wheelRigidbody.SweepTest(-transform.right, out RaycastHit hit2, 0.07f))
        {
            if (_tank.Rigidbody.velocity.magnitude <= 0.00005f) return;
            Debug.Log($"{gameObject.name} {Vector3.Dot(transform.right, _tank.Rigidbody.velocity)}");
            
            force = Vector3.Dot(transform.right, _tank.Rigidbody.velocity) < -0.002f ?
                        -_tank.Rigidbody.velocity * _tank.Rigidbody.mass * Time.deltaTime * 1200 :
                        force;
        }*/

        
            Vector3 verticalAdditional = transform.forward * _maxLength;
            Debug.DrawLine(transform.position, transform.position + verticalAdditional, Color.green);
            _wheelModelPosition = transform.position + verticalAdditional;

            if (_wheelRigidbody.SweepTest(transform.forward, out RaycastHit hit, _maxLength + _wheelRadius))
            {
                _lastLength = _springLength;
                _springLength = hit.distance - _wheelRadius;
                _springLength = Mathf.Clamp(_springLength, _minLength, _maxLength);
                _springVelocity = (_lastLength - _springLength) / Time.fixedDeltaTime;
                _springForce = _springStiffness * (_restLength - _springLength);
                _damperForce = _damperStiffness * _springVelocity;

                _wheelModelPosition.y = hit.point.y + _wheelRadius;

                var verticalMovement = -transform.right * _torqueSpeed * Input.GetAxis("Vertical");
                var frictionForces = -transform.up * _tank.Rigidbody.GetPointVelocity(transform.TransformPoint(hit.point)).z 
                                                   * (_tireGrip / Time.fixedDeltaTime)/* +
                                 transform.right * _tank.Rigidbody.GetPointVelocity(transform.TransformPoint(hit.point)).x 
                                              * _tireGrip*/;
            
//                print(_tank.Rigidbody.GetPointVelocity(transform.TransformPoint(hit.point)));
            
                var movingForce = verticalMovement + frictionForces;
                _tank.Rigidbody.AddForceAtPosition(movingForce + (_springForce + _damperForce) * -transform.forward, hit.point);
            }

            _wheelModel.position = _wheelModelPosition;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.3f,0.25f,0.35f, 1);

            var positionMatrix = Matrix4x4.TRS(_wheelModelPosition + _gizmosPositionOffset,
                Quaternion.Euler(_gizomsRotationOffset),
                transform.lossyScale);
            Gizmos.matrix = positionMatrix;
            Gizmos.DrawWireMesh(_wheelMesh);
        }
    }
}
