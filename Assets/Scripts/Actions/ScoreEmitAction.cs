using System;
using UnityEngine;

public class ScoreEmitAction : MonoBehaviour
{

    public event Action<int> OnScoreEmitted;
    
    [SerializeField] private int score;
    
    public void EmitScore()
    {
        OnScoreEmitted?.Invoke(score);
    }

}
