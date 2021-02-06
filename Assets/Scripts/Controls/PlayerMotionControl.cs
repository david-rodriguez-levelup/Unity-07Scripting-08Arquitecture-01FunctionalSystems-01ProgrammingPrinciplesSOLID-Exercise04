using UnityEngine;

[RequireComponent(typeof(RigidbodyMotionAction))]
public class PlayerMotionControl : MonoBehaviour
{

    [SerializeField] private string axisName = "Horizontal";
    [SerializeField] private float speed = 10f;
    [SerializeField] private float angle = 10f;

    private RigidbodyMotionAction motionAction;
    private EngineAction engineAction;

    private float horizontalInput;

    private void Awake()
    {
        motionAction = GetComponent<RigidbodyMotionAction>();
        engineAction = GetComponentInChildren<EngineAction>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis(axisName);
    }

    private void FixedUpdate()
    {
        if (horizontalInput != 0)
        {
            Move();
            engineAction.Ignite();
        }
        else
        {
            engineAction.Rest();
        }
    }

    private void Move()
    {
        motionAction.Move(Vector3.right * horizontalInput, speed);
        motionAction.Rotate(new Vector3(0f, -horizontalInput * angle, 0f));
    }

}
