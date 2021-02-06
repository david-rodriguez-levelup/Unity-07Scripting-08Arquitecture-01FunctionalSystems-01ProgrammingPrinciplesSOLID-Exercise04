using System;

public interface IHealthStateDecrementable
{

    event Action<float> OnHealthDecreased;
    event Action OnMinHealthAchieved;

    bool TryDecreaseHealth(float amount);

}
