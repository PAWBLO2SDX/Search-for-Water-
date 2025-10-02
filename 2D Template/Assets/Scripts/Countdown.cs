using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    public PlayerController plrScript;
    public GameObject player;
    public GameObject warning;
    public Text countdownText;
    [SerializeField] private float currentTime;
    [SerializeField] private float currentCounter;
    public bool isCountingDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 60;
        isCountingDown = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown == true || currentTime == 0)
        {
            currentTime -= Time.deltaTime;
        }
        if (isCountingDown == false)
        {
            currentTime += Time.deltaTime;
        }
        
        if (currentTime <= 0)
        {
            Destroy(player);
        }
        int minutes = Mathf.FloorToInt(isCountingDown ? currentTime / 60f : currentTime / 60f);
        int seconds = Mathf.FloorToInt(isCountingDown ? currentTime - minutes * 60 : currentTime - minutes * 60);
        countdownText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
    }
}
