using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class FireProjectile : MonoBehaviour
{
    // Fire Projectile
    [SerializeField] private GameObject m_projectile;
    private ARRaycastManager m_raycastManager;

    // Awake Function
    private void Awake()
    {
        m_raycastManager = GetComponent<ARRaycastManager>();
    }

    // OnEnable Function
    private void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.Touch.onFingerDown += FingerDown;
    }

    // OnEnable Function
    private void OnDisable()
    {
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.Touch.onFingerDown -= FingerDown;
    }

    // When finger is pressed down
    private void FingerDown(EnhancedTouch.Finger finger)
    {
        if (finger.index != 0) return;

        GameObject projectile = Instantiate(m_projectile);
        Rigidbody body = projectile.GetComponent<Rigidbody>();
        if (body != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(finger.currentTouch.screenPosition);
            body.AddForce(ray.direction * 10, ForceMode.Impulse);
        }
    }
}
