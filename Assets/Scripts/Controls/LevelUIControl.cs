using UnityEngine;
using UnityEngine.UI;

public class LevelUIControl : MonoBehaviour
{
    [SerializeField] HealthState playerHealthState;

    [SerializeField] Text scoreText;
    [SerializeField] RectMask2D healthBar;

    private int score;

    private void Start()
    {
        score = 0;
        scoreText.text = score.ToString();
    }

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

    public void SubscribeToScoreEmitAction(ScoreEmitAction scoreEmitAction)
    {
        // DOUBT: Is desubscription needed if score emitter (enemy) will be destroyed for sure?
        scoreEmitAction.OnScoreEmitted += RefreshScore;
    }

    private void RefreshScore(int _score)
    {
        score += _score;
        scoreText.text = score.ToString();
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
