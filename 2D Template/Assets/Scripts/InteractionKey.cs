using UnityEngine;
using UnityEngine.Events;

public class InteractionKey : MonoBehaviour
{
    public UnityEvent onInteract;

    [SerializeField] private bool _active;
    public bool Active { get => _active; set => _active = value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_active)
            return;

        if (collision.CompareTag("Player"))
        {
            onInteract.Invoke();
            gameObject.SetActive(false);
        }
    }
}
