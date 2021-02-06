using UnityEngine;

public interface ILauncher
{

    bool CanLaunch();

    void Launch(Rigidbody projectilePrefab);

}
