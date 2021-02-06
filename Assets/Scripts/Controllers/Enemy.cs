using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(RigidbodyMotion))]
[RequireComponent(typeof(Engine))]
[RequireComponent(typeof(DefaultHealthState))]
[RequireComponent(typeof(DefaultSpawner))]
public class Enemy : MonoBehaviour
{

    [SerializeField] private float speed = 10f;

    private RigidbodyMotion rigidbodyMotion;
    private Engine engine;
    private DefaultHealthState healthBehaviour;
    private DefaultSpawner explosionSpawner;

    private void Awake()
    {
        rigidbodyMotion = GetComponent<RigidbodyMotion>();
        engine = GetComponentInChildren<Engine>();
        healthBehaviour = GetComponent<DefaultHealthState>();
        explosionSpawner = GetComponent<DefaultSpawner>();
    }

    private void OnEnable()
    {
        healthBehaviour.OnMinHealthAchieved += Explode;
    }

    private void OnDisable()
    {
        healthBehaviour.OnMinHealthAchieved -= Explode;
    }

    private void Start()
    {
        if (engine)
        {
            engine.Ignite();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidbodyMotion.Move(Vector3.down, speed);
    }

    private void Explode()
    {
        explosionSpawner.Spawn();
        Destroy(gameObject);
    }

}
