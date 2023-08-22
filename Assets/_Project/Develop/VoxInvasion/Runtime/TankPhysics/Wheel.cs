using UnityEngine;

namespace VoxInvasion.Runtime.TankPhysics
{
    public class Wheel : MonoBehaviour
    {
        /*[SerializeField] Rigidbody _tankRigidbody;
    [SerializeField] Transform _wheelModel;
    [SerializeField] Vector3 _gizmosPositionOffset;
    [SerializeField] Vector3 _gizomsRotationOffset;

    [Space]
    [SerializeField] float _suspensionLength;
    [SerializeField] float _wheelRadius;
    [SerializeField] float _wheelWidth;
    [SerializeField] float _torqueSpeed;
    Mesh _wheelMesh;
    Vector3 _wheelModelPosition;
    Rigidbody _wheelRigidbody;
    
    void OnValidate()
    {
        _wheelMesh = _wheelModel.GetComponent<MeshCollider>().sharedMesh;
        _wheelModelPosition = transform.position;
    }

    void FixedUpdate()
    {
        Vector3 verticalAdditional = transform.up * (_suspensionLength + _wheelRadius);
        _wheelModelPosition = transform.position + verticalAdditional + transform.up * _wheelRadius;
        Debug.DrawLine(transform.position, transform.position + verticalAdditional, Color.green);

        if (Physics.CapsuleCast())
        {
            
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
    }*/
    }
}
