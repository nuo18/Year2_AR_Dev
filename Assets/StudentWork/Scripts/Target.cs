using UnityEngine;

public class Target : MonoBehaviour
{
    // If projectile hits this object, it destroys itself
    private void OnCollisionEnter(Collision collision)
    {
        // If we hit a projectile, destroy this target
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Destroy(gameObject);
        }
    }
}
