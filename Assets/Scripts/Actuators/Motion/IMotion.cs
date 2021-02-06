using UnityEngine;

public interface IMotion
{

    void Move(Vector3 direction, float speed);

    void MoveTowards(Transform target, float speed, float turnSpeed);

    void Rotate(Vector3 eulerRotation);

    void Rotate(Quaternion rotation);

    void SlerpRotation(Quaternion quaternion, float speed);

}
