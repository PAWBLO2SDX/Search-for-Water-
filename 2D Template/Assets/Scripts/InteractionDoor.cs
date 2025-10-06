using UnityEngine;
using UnityEngine.Events;

public class InteractionDoor : MonoBehaviour
{
    public UnityEvent onInteract;

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // if (collision.CompareTag("Player") && (InteractionKey.keyNeeded = true ))
       // {
          //  onInteract.Invoke();
      //      gameObject.SetActive(false);
       // }
    }
}
