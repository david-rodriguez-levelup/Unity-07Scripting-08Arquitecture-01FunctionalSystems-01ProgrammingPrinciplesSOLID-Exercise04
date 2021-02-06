using UnityEngine;

public class OnTimeoutSelfDestructor : MonoBehaviour
{

    [SerializeField] float timeout = 5f;

    private void Start()
    {
        Destroy(gameObject, timeout);
    }

}
