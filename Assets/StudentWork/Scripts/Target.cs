using UnityEngine;

public class Target : MonoBehaviour
{
    // Target Manager
    private TargetManager _manager;

    // Called right after Instantiate()
    public void Initialize(TargetManager manager)
    {
        _manager = manager;
    }


    // If projectile hits this object, it destroys itself
    private void OnCollisionEnter(Collision collision)
    {
        // If we hit a projectile, destroy this target
        if (collision.gameObject.CompareTag("Projectile"))
        {
            // Report back
            _manager?.NotifyTargetDestroyed();

            Destroy(gameObject);
        }
    }
}
