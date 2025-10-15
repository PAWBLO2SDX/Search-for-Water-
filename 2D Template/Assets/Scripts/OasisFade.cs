using UnityEngine;

public class OasisFade : MonoBehaviour
{
    public Animator animator;
    public void Start()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
       if (collision.gameObject.tag == "Player")
        {
            animator.SetTrigger("Play");
        }
    }
}
