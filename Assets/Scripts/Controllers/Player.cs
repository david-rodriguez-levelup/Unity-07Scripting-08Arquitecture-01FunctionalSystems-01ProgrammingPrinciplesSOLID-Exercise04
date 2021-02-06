using UnityEngine;

[RequireComponent(typeof(RigidbodyMotion))]
public class Player : MonoBehaviour
{

    [SerializeField] private string axisName = "Horizontal";
    [SerializeField] private float speed = 10f;
    [SerializeField] private float angle = 10f;

    private RigidbodyMotion rigidbodyMotion;
    private DefaultHealthState healthState;
    private Engine engine;
    private ParticleSystem damageEffect;

    private float horizontalInput;

    private void Awake()
    {
        rigidbodyMotion = GetComponent<RigidbodyMotion>();
        healthState = GetComponent<DefaultHealthState>();
        engine = GetComponentInChildren<Engine>();
        damageEffect = transform.Find("[DamageEffect]").GetComponent<ParticleSystem>();
    }

    private void OnEnable()
    {
        healthState.OnDamageInflicted += PlayDamageEffect;
    }

    private void OnDisable()
    {
        healthState.OnDamageInflicted -= PlayDamageEffect;
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis(axisName);
    }

    private void FixedUpdate()
    {
        if (horizontalInput != 0)
        {
            Move();
            engine.Ignite();
        }
        else
        {
            engine.Rest();
        }
    }

    private void Move()
    {
        rigidbodyMotion.Move(Vector3.right * horizontalInput, speed);
        rigidbodyMotion.Rotate(new Vector3(0f, -horizontalInput * angle, 0f));
    }

    private void PlayDamageEffect(float damage, float currentHealth)
    {
        damageEffect.Play();
    }

}
