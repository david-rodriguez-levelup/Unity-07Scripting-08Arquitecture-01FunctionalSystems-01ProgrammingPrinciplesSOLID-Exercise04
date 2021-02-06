using UnityEngine;

public abstract class AbstractLauncher : MonoBehaviour, ILauncher
{
    [SerializeField]
    protected float launchForce = 10f;

    public virtual bool CanLaunch()
    {
        return true;
    }

    public abstract void Launch(Rigidbody projectilePrefab);

}
