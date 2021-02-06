using UnityEngine;

public class TransformMotionAction : MonoBehaviour, IMotionAction
{

    public void Move(Vector3 direction, float speed)
    {
        throw new System.NotImplementedException();
    }

    public void MoveTowards(Transform target, float speed, float turnSpeed)
    {
        throw new System.NotImplementedException();
    }

    public void Rotate(Vector3 eulerRotation)
    {
        throw new System.NotImplementedException();
    }

    public void Rotate(Quaternion rotation)
    {
        throw new System.NotImplementedException();
    }

    public void SlerpRotation(Quaternion quaternion, float speed)
    {
        throw new System.NotImplementedException();
    }

}
