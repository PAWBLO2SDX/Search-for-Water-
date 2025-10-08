using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnHitbox : MonoBehaviour
{
    public float attackRadius = 1.5f;
    public LayerMask attackLayer;
    public float moveSpeed = 1;
    
    

    private PlayerController topDown;

    private void Awake()
    {
       topDown = GetComponent<PlayerController>();
    }

    private void Attack(InputAction.CallbackContext ctx)
    {
      RaycastHit2D hit = Physics2D.CircleCast(transform.position + (Vector3)topDown.movement, attackRadius, Vector2.zero, 0, attackLayer);

        //if (hit)
        {
           Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.TryGetComponent(out Stats targetstats) && TryGetComponent(out Stats playerStats))
            {
               

            }


        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
