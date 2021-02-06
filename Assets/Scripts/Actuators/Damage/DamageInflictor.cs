using UnityEngine;

// Se podría usar un "LayerBasedCollisionDetector" pero quedaba muy difícil 
// de entender en el Inspector.
//[RequireComponent(typeof(LayerBasedCollisionDetector))]
public class DamageInflictor : MonoBehaviour
{

    [SerializeField] private float damage;
    [SerializeField] private LayerMask layerMask;

    private void Start()
    {
        // Intentionally left blank to allow enable/disable option in Inspector.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (enabled && ContainsLayer(collision.gameObject.layer))
        {
            OnCollision(collision);
        }
    }

    private bool ContainsLayer(int layer)
    {
        return layerMask == (layerMask | (1 << layer));
    }

    private void OnCollision(Collision collision)
    {
        DefaultHealthState healthState = collision.gameObject.GetComponent<DefaultHealthState>();
        if (healthState != null)
        {
            //print($"{name} manda {damage} de daño a {collision.gameObject.name}");
            healthState.TryInflictDamage(damage);
        }       
    }

}
