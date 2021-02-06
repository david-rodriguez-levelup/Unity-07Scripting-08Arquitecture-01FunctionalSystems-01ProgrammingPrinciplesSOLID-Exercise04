using UnityEngine;

[RequireComponent(typeof(IHealthStateDecrementable))]
[RequireComponent(typeof(DamageSourceSensor))]
[RequireComponent(typeof(ScoreEmitAction))]
[RequireComponent(typeof(DefaultSpawnAction))]
public class EnemyHealthControl : MonoBehaviour
{

    private IHealthStateDecrementable healthState;
    private DamageSourceSensor damageSourceSensor;
    private ScoreEmitAction scoreEmitAction;
    private DefaultSpawnAction explosionSpawnAction;

    private void Awake()
    {
        healthState = GetComponent<IHealthStateDecrementable>();
        damageSourceSensor = GetComponent<DamageSourceSensor>();
        scoreEmitAction = GetComponent<ScoreEmitAction>();
        explosionSpawnAction = GetComponent<DefaultSpawnAction>();
    }

    private void OnEnable()
    {
        healthState.OnMinHealthAchieved += Explode;
        damageSourceSensor.OnDamageDetected += OnDamageDetected;
    }

    private void OnDisable()
    {
        healthState.OnMinHealthAchieved += Explode;
        damageSourceSensor.OnDamageDetected += OnDamageDetected;
    }

    private void OnDamageDetected(float amount)
    {        
        healthState.TryDecreaseHealth(amount);
    }

    private void Explode()
    {
        explosionSpawnAction.Spawn();
        scoreEmitAction.EmitScore();
        Destroy(gameObject);
    }

}

