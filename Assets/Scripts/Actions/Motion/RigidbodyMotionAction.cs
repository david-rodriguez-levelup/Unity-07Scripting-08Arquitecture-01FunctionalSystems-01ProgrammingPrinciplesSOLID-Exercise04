using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(Rigidbody))]
public class RigidbodyMotionAction : MonoBehaviour, IMotionAction
{

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 direction, float speed)
    {
        Assert.IsTrue(Time.inFixedTimeStep);

        Vector3 deltaPosition = direction * speed * Time.fixedDeltaTime;

        _rigidbody.position += deltaPosition;
    }

    public void MoveTowards(Transform target, float speed, float turnSpeed)
    {
        Assert.IsTrue(Time.inFixedTimeStep);

        // TODO: Esto tiene cosas de 2D que hay que solucionar!!!

        Vector3 toTarget = target.position - _rigidbody.position;
        float angle = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg - 90f;
        Quaternion quaternion = Quaternion.AngleAxis(angle, Vector3.forward);
        _rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, quaternion, turnSpeed * Time.fixedDeltaTime);

        Vector3 deltaPosition = transform.up * speed * Time.fixedDeltaTime;
        _rigidbody.position += deltaPosition;

    }

    public void SlerpRotation(Quaternion quaternion, float speed)
    {
        Assert.IsTrue(Time.inFixedTimeStep);

        _rigidbody.rotation = Quaternion.Slerp(_rigidbody.rotation, quaternion, speed * Time.fixedDeltaTime);
    }

    public void Rotate(Vector3 eulerRotation)
    {
        Rotate(Quaternion.Euler(eulerRotation));
    }

    public void Rotate(Quaternion rotation)
    {
        Assert.IsTrue(Time.inFixedTimeStep);

        _rigidbody.rotation = rotation;
    }

}
