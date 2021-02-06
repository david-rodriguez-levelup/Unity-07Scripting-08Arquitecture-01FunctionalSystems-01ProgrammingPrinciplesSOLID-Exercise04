using UnityEngine;

public class RelativeDamageHealthState : DefaultHealthState
{

    [SerializeField] private float relativeDamageRatio = 1f;

    protected override void InflictDamage(float amount)
    {
        /// Avoids expose private field "currentDamage" in the base class and
        /// will keep this method responsive to changes in the base method.
        base.InflictDamage(amount * relativeDamageRatio);
    }

}
