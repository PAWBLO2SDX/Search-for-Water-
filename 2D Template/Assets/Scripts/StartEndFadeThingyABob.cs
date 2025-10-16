using UnityEngine;

public class StartEndFadeThingyABob : MonoBehaviour
{
    public GameObject Dialog;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Dialog.SetActive(true);
        }
    }
}
