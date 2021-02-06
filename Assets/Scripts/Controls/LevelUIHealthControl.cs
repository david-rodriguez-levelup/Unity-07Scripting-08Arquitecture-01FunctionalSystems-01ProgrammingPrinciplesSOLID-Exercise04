using UnityEngine;
using UnityEngine.UI;

public class LevelUIHealthControl : MonoBehaviour
{
    [SerializeField] HealthState playerHealthState;
    [SerializeField] RectMask2D healthBar;

    private void OnEnable()
    {
        playerHealthState.OnHealthIncreased += IncreaseHealthBar;
        playerHealthState.OnHealthDecreased += DecreaseHealthBar;
    }

    private void OnDisable()
    {
        playerHealthState.OnHealthIncreased -= IncreaseHealthBar;
        playerHealthState.OnHealthDecreased -= DecreaseHealthBar;
    }

    private void IncreaseHealthBar(float amount)
    {
        UpdateHealthBar();
    }

    private void DecreaseHealthBar(float amount)
    {
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        float maxHealth = playerHealthState.MaxHealth;
        float currentHealth = playerHealthState.CurrentHealth;

        float normalizedValue = Mathf.InverseLerp(0, maxHealth, currentHealth);
        float result = Mathf.Lerp(500, 0, normalizedValue);

        healthBar.padding = new Vector4(0f, 0f, result, 0f);
    }

}
