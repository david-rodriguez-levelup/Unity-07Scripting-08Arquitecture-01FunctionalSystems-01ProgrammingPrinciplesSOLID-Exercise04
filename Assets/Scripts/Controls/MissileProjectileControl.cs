using UnityEngine;

[RequireComponent(typeof(RigidbodyMotionAction))]
[RequireComponent(typeof(LayerBasedNearestObjectSensor))]
public class MissileProjectileControl : MonoBehaviour
{

    [SerializeField] private float speed = 20;
    [SerializeField] private float turnSpeed = 10;

    private RigidbodyMotionAction motionAction;
    private LayerBasedNearestObjectSensor nearestEnemySensor;

    private Transform target;

    private void Awake()
    {
        motionAction = GetComponent<RigidbodyMotionAction>();
        nearestEnemySensor = GetComponent<LayerBasedNearestObjectSensor>();
    }

    private void FixedUpdate()
    {
        if (target != null) 
        {
            motionAction.MoveTowards(target, speed, turnSpeed);
        }
        else
        {
            GameObject go = nearestEnemySensor.Find();
            if (go != null)
            {
                target = go.transform;
            }
            else
            {
                //rigidbodyMotion.Rotate(Vector3.up); // - FALTA ESTO!
                motionAction.Move(Vector3.up, speed);
            }
        }
    }

}
