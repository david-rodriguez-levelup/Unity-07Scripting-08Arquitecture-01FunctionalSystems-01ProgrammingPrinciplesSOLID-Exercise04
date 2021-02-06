using System;
using UnityEditor;
using UnityEngine;

public class DefaultHealthState : MonoBehaviour
{

    public event Action<float, float> OnDamageInflicted;
    public event Action OnMinHealthAchieved;
    public event Action<float, float> OnHealthRestored;
    public event Action OnMaxHealthAchieved;

    [SerializeField] float maxHealth;

    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // WARNING: It's not a good idea to create an interface with this method because
    // it will be very difficult to implement respecting the Liskov Substitution Principle.
    public bool TryInflictDamage(float amount)
    {
        if (amount <= 0f)
            return false;

        float previousHealth = currentHealth;

        InflictDamage(amount);

        if (currentHealth <= 0f)
        {
            currentHealth = 0f;
            OnMinHealthAchieved?.Invoke();
        }

        if (currentHealth != previousHealth)
        {
            OnDamageInflicted?.Invoke(amount, currentHealth);
            return true;
        }
        else
        {
            return false;
        }
    }

    // WARNING: It's not a good idea to create an interface with this method because
    // it will be very difficult to implement respecting the Liskov Substitution Principle.
    public bool TryRestoreHealth(float amount)
    {
        if (amount <= 0)
            return false;

        float previousHealth = currentHealth;

        RestoreHealth(amount);

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
            OnMaxHealthAchieved?.Invoke();
        }

        if (currentHealth != previousHealth)
        {
            OnHealthRestored?.Invoke(amount, currentHealth);
            return true;
        }
        else
        {
            return false;
        }
    }

    protected virtual void InflictDamage(float amount)
    {     
        currentHealth -= amount;
    }

    protected virtual void RestoreHealth(float amount)
    {
        currentHealth += amount;
    }

    #region Gizmos

    private void OnDrawGizmos()
    {      
        Handles.Label(transform.position, currentHealth.ToString());
    }

    #endregion

}
