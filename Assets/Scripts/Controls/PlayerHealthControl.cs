using UnityEngine;

[RequireComponent(typeof(HealthState))]
[RequireComponent(typeof(DamageSourceSensor))]
[RequireComponent(typeof(HealingSourceSensor))]
[RequireComponent(typeof(DefaultSpawnAction))]
public class PlayerHealthControl : MonoBehaviour
{

    [SerializeField] ParticleSystem damageEffect;
    [SerializeField] ParticleSystem healingEffect;

    private HealthState healthState;
    private DamageSourceSensor damageSourceSensor;
    private HealingSourceSensor healingSourceSensor;
    private DefaultSpawnAction explosionSpawnAction;

    private void Awake()
    {
        healthState = GetComponent<HealthState>();
        damageSourceSensor = GetComponent<DamageSourceSensor>();
        healingSourceSensor = GetComponent<HealingSourceSensor>();
        explosionSpawnAction = GetComponent<DefaultSpawnAction>();
    }

    private void OnEnable()
    {
        damageSourceSensor.OnDamageDetected += OnDamageDetected;
        healingSourceSensor.OnHealingDetected += OnHealingDetected;
        healthState.OnMinHealthAchieved += Explode;
    }

    private void OnDisable()
    {
        damageSourceSensor.OnDamageDetected -= OnDamageDetected;
        healingSourceSensor.OnHealingDetected -= OnHealingDetected;
        healthState.OnMinHealthAchieved -= Explode;
    }

    private void OnDamageDetected(float amount)
    {
        if (healthState.TryDecreaseHealth(amount)) // Otra opción sería subscribirse a healthState.OnHealthDecreased.
        {
            damageEffect.Play();
        }
    }

    private void OnHealingDetected(float amount)
    {
        if (healthState.TryIncreaseHealth(amount)) // Otra opción sería subscribirse a healthState.OnHealthIncreased.
        {
            healingEffect.Play();
        }
    }

    private void Explode()
    {
        explosionSpawnAction.Spawn();
        Destroy(gameObject);
    }

}
