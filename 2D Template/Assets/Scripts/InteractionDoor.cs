using UnityEngine;
using UnityEngine.Events;

public class InteractionDoor : MonoBehaviour
{
    public UnityEvent onInteract;

    [SerializeField] private bool _active;
    public bool Active { get => _active; set => _active = value; }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_active)
            return;
        if (collision.gameObject.CompareTag("Player"))
        {
             
           onInteract.Invoke();
           gameObject.SetActive(false);
            
        }
    }
}
