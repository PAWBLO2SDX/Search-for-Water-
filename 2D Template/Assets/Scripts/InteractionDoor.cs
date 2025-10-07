using UnityEngine;
using UnityEngine.Events;

public class InteractionDoor : MonoBehaviour
{
    public UnityEvent onInteract;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
             
           onInteract.Invoke();
           gameObject.SetActive(false);
            
        }
    }
}
