using UnityEngine;

public class Door : MonoBehaviour
{
    public Key key;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (key.isActiveAndEnabled) //if the user dose't have the Key
        {

        }
        else // if the user dose have the Key 
        {
            gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position,key.transform.position);
    }
}
