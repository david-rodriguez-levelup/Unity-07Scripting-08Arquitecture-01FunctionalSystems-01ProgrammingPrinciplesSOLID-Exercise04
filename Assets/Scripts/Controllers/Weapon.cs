using UnityEngine;

[RequireComponent(typeof(ILauncher))]
public class Weapon : MonoBehaviour
{

    [SerializeField] private string fireButton = "Fire1";
    [SerializeField] protected Rigidbody projectilePrefab;
    [SerializeField] private ILauncher launch;

    private void Awake()
    {
        launch = GetComponent<ILauncher>();
    }

    private void Update()
    {
        if (Input.GetButtonDown(fireButton))
        {
            TryShoot();
        }
    }

    private void TryShoot()
    {
        if (launch.CanLaunch())
        {
            launch.Launch(projectilePrefab);
        } 
    }

    /*    
    private bool launchNextFixedStep;

    private void Update()
    {
        launchNextFixedStep = launch.CanLaunch() && Input.GetButtonDown(fireButton);
    }

    private void FixedUpdate()
    {
        if (launchNextFixedStep)
        {
            launch.Launch(projectilePrefab);
            launchNextFixedStep = false;
        }
    }
    */

}
