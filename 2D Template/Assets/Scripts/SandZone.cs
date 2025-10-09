using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class SandZone : MonoBehaviour
{
    public PlayerController playerControllerScript;
    public delegate void SandZoneTrigger(Collider2D other);
    public event SandZoneTrigger OnSandZoneTrigger;
    private bool playerInside = false;
    private Collider2D playerCollider;

    void OnEnable()
    {
        SandStormEffect.OnSandStormEffectToggled += ToggleSandZone;
    }

    void OnDisable()
    {
        SandStormEffect.OnSandStormEffectToggled -= ToggleSandZone;
    }

    void FixedUpdate()
    {
        if (playerInside) OnSandZoneTrigger?.Invoke(playerCollider);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            playerCollider = other;
        }
    }

    public void ToggleSandZone(bool active)
    {
        GetComponent<Collider2D>().enabled = active;
    }
}
