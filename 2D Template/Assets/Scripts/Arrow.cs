using UnityEngine;

public class Arrow : MonoBehaviour
{
    // Assign the target GameObject in the Inspector
    public Transform target;
    public void setTarget(Transform newTarget) 
    { 
    target = newTarget;
    }

    void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("Target is not assigned!");
            return;
        }

        // Calculate the direction vector from this object to the target
        Vector3 direction = target.position - transform.position;

        // Calculate the angle in degrees using Mathf.Atan2 (for 2D rotation)
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation only on the Z axis (for 2D)
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}