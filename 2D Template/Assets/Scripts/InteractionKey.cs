using UnityEngine;
using UnityEngine.Events;

public class InteractionKey : MonoBehaviour
{
    public UnityEvent onInteract;
    public bool keyNeeded = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onInteract.Invoke();
            gameObject.SetActive(false);
        }
    }
}
