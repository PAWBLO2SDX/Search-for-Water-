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
        float time;
        float read = 60;
        int minutes2;
        int seconds2;
        if (plrConScript.console == false || heatTime == 0)
        {
            heatSlider.minValue = heatTime;
            heatSlider.value = heatTime;
            time = heatTime + Time.time;
            minutes2 = Mathf.FloorToInt(time / read);
            seconds2 = Mathf.FloorToInt(time - minutes2 * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes2, seconds2);

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

        if (plrConScript.console == true || heatTime == 20)
        {
            read = 0;
            minutes2 = 0;
            seconds2 = 0;
            float time2 = heatTime - Time.time;
            heatSlider.maxValue = time2 - heatSlider.value;
            heatSlider.value--;
            int minutes = Mathf.FloorToInt(time2 / 60);
            int seconds = Mathf.FloorToInt(time2 - minutes * 60f);

            string textTime = string.Format("{0:0}:{1:00}", minutes, seconds);

            if (time2 >= 61)
            {
                stopTimer = true;
            }

            if (stopTimer == false)
            {
                heatNumberText.text = textTime;
                heatSlider.value = time2--;
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
