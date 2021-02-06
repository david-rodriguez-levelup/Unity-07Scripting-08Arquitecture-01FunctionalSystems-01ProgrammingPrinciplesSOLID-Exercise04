using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyFixedMotionAction : MonoBehaviour
{
    [SerializeField] private Vector3 direction = Vector3.zero;
    [SerializeField] private float speed = 5f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        Vector3 deltaPosition = direction * speed * Time.fixedDeltaTime;
        _rigidbody.position += deltaPosition;
    }

}
