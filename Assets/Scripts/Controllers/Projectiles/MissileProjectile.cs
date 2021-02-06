using UnityEngine;

[RequireComponent(typeof(RigidbodyMotion))]
[RequireComponent(typeof(LayerBasedNearestObjectFinder))]
public class MissileProjectile : MonoBehaviour
{

    [SerializeField] private float speed = 20;
    [SerializeField] private float turnSpeed = 10;

    private RigidbodyMotion rigidbodyMotion;
    private LayerBasedNearestObjectFinder nearestEnemyFinder;

    private Transform target;

    private void Awake()
    {
        rigidbodyMotion = GetComponent<RigidbodyMotion>();
        nearestEnemyFinder = GetComponent<LayerBasedNearestObjectFinder>();
    }

    private void FixedUpdate()
    {
        if (target != null) 
        {
            rigidbodyMotion.MoveTowards(target, speed, turnSpeed);
        }
        else
        {
            GameObject go = nearestEnemyFinder.Find();
            if (go != null)
            {
                target = go.transform;
            }
            else
            {
                //rigidbodyMotion.Rotate(Vector3.up); // - FALTA ESTO!
                rigidbodyMotion.Move(Vector3.up, speed);
            }
        }
    }

}
