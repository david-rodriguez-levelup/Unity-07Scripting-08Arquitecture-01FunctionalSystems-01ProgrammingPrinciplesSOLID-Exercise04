using UnityEngine;

public class ScoreEmitterAction : MonoBehaviour
{

    // DILEMA: Should actions send events?
    // -----------> public event Action<int> OnScoreEmitted;
    // NOTA: Al principio el LeveUIScore se subscribía a este evento, 
    // podría parecer más rebuscado hacerlo así, pero si en el futuro 
    // otro componente del level (ej. un componente que muestra un texto de combo)
    // ya no necesitamos modificar LevelSpawnControl, basta con que el nuevo
    // componente se subscriba al sensor.

    [SerializeField] private int score;

    private ScoreReceiverSensor receiver;
    
    public void SetReceiver(ScoreReceiverSensor _receiver)
    {
        receiver = _receiver;
    }

    public void Emit()
    {
        receiver.Receive(score);
    }

}
