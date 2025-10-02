using UnityEngine;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    public UnityEvent onInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            onInteract.Invoke();
        }
    }
}
