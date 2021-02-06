using System;

public interface IHealthStateIncrementable
{

    event Action<float> OnHealthIncreased;
    event Action OnMaxHealthAchieved;

    bool TryIncreaseHealth(float amount);

}
