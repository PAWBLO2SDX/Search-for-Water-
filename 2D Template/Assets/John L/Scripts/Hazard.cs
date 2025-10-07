using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float damage = 2 ;

    
 private void OnCollisionEnter2D(Collision2D collision)
    {
        //Destroy(collision.gameObject);
       // Debug.Log(collision.gameObject.name);
       if(collision.gameObject.TryGetComponent(out Stats stats))
        {
            stats.currentHealth -= damage;
        }
    }
}
