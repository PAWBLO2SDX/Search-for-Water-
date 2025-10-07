using UnityEngine;
[RequireComponent(typeof(Collider2D))]
public class WindZone : MonoBehaviour
{
    public PlayerController playerControllerScript;
    public delegate void WindZoneTrigger(Collider2D other);
    public event WindZoneTrigger OnWindZoneTrigger;
    private bool playerInside = false;
    private Collider2D playerCollider;

    void OnEnable()
    {
        WindEffect.OnWindEffectToggled += ToggleWindZone;
<<<<<<< HEAD
        playerControllerScript.moveSpeed = 0;
=======
>>>>>>> 30a6c185f318a641274e7ff0711369c3d5554fb4
    }

    void OnDisable()
    {
        WindEffect.OnWindEffectToggled -= ToggleWindZone;
    }

    void FixedUpdate()
    {
        if (playerInside) OnWindZoneTrigger?.Invoke(playerCollider);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            playerCollider = other;
        }
    }

    public void ToggleWindZone(bool active)
    {
        GetComponent<Collider2D>().enabled = active;
    }
}