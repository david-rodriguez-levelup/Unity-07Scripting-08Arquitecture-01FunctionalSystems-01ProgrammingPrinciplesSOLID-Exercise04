﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ScoreReceiverSensor))]
public class LevelUIScoreControl : MonoBehaviour
{

    [SerializeField] private Text scoreField;

    private ScoreReceiverSensor scoreReceiverSensor;

    private int score;

    private void Awake()
    {
        scoreReceiverSensor = GetComponent<ScoreReceiverSensor>();
    }

    private void OnEnable()
    {
        scoreReceiverSensor.OnScoreReceived += IncreaseScore;
    }

    private void OnDisable()
    {
        scoreReceiverSensor.OnScoreReceived -= IncreaseScore;
    }

    private void Start()
    {
        score = 0;
        Refresh();
    }

    private void IncreaseScore(int amount)
    {
        score += amount;
        Refresh();
    }

    private void Refresh()
    {
        scoreField.text = score.ToString();
    }

}