using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class CloudZone : MonoBehaviour
{
    public PlayerController playerControllerScript;
    public delegate void CloudZoneTrigger(Collider2D other);
    public event CloudZoneTrigger OnCloudZoneTrigger;
    private bool playerInside = false;
    private Collider2D playerCollider;

    void OnEnable()
    {
        CloudEffect.OnCloudEffectToggled += ToggleCloudZone;
    }

    void OnDisable()
    {
        CloudEffect.OnCloudEffectToggled -= ToggleCloudZone;
    }

    void FixedUpdate()
    {
        if (playerInside) OnCloudZoneTrigger?.Invoke(playerCollider);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            playerCollider = other;
        }
    }

    public void ToggleCloudZone(bool active)
    {
        GetComponent<Collider2D>().enabled = active;
    }
}