using System;
using UnityEngine;

public class HealingSourceSensor : MonoBehaviour
{

    [SerializeField] float healingRatio = 1f;

    public event Action<float> OnHealingDetected;

    private void OnCollisionEnter(Collision collision)
    {
        DetectHealing(collision.gameObject);
    }

    private void OnTriggerEnter(Collider collider)
    {
        DetectHealing(collider.gameObject);
    }

    private void DetectHealing(GameObject gameObject)
    {
        HealingSourceAction healingSourceAction = gameObject.GetComponent<HealingSourceAction>();
        if (healingSourceAction != null)
        {
            OnHealingDetected?.Invoke(healingSourceAction.Healing * healingRatio);
        }
    }

}
