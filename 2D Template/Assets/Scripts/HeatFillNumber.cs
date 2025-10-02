using UnityEngine;
using UnityEngine.UI;

public class HeatFillNumber : MonoBehaviour
{
    [SerializeField] public PlayerController plrConScript;
    public Slider heatSlider;
    public Text heatNumberText;
    public GameObject Warning;
    public GameObject Player;
    public float heatTime;

    public float realTime;

    private bool stopTimer;

    public GameObject Death;

    public bool toggle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        stopTimer = false;
    }

    // Update is called once per frame
    public void Update()
    {
       
       
        if (plrConScript.console == true)
        {
            float time = heatTime - Time.time;
            heatSlider.minValue = time - heatSlider.value;
            heatSlider.value--;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (time >= 61)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                heatNumberText.text = textTime;
                heatSlider.value = time --;
            }

            if (heatSlider.value >= 50f)
            {
                Warning.SetActive(true);
            }

            if (heatSlider.value >= 60f)
            {
                Destroy(Player);
            }
        } else
        {
            heatSlider.minValue = heatTime;
            heatSlider.value = heatTime;
            float time = heatTime + Time.time;
            int minutes = Mathf.FloorToInt(time / 60);
            int seconds = Mathf.FloorToInt(time - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (time >= 61)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                heatNumberText.text = textTime;
                heatSlider.value = time;
            }

            if (heatSlider.value >= 50f)
            {
                Warning.SetActive(true);
            }

            if (heatSlider.value >= 60f)
            {
                Destroy(Player);
            }

        }
 }
}
