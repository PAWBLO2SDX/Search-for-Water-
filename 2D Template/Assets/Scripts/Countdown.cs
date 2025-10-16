using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public PlayerController plrScript;
    public GameObject player;
    public GameObject warning;
    public GameObject warningSfx;
    public Text countdownText;
    public Slider slider;
    [SerializeField] private float currentTime;
    [SerializeField] public float currentCounter;
    public bool isCountingDown;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentTime = 60;
        currentCounter = 0;
        isCountingDown = true;
        slider.value = 0;
        slider.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (isCountingDown == true)
        {
            currentTime -= Time.deltaTime;
            currentCounter += Time.deltaTime;
        }
        if (isCountingDown == false && currentTime <= 60)
        {
            currentTime += Time.deltaTime;
            currentCounter -= Time.deltaTime;
        }

        if (currentTime <= 0)
        {
            Destroy(player);
            SceneManager.LoadScene("MainMenu");
        }
        if (currentTime <= 10 && plrScript.console == false)
        {
            warning.SetActive(true);
            warningSfx.SetActive(true);
        }
        int minutes = Mathf.FloorToInt(isCountingDown ? currentTime / 60f : currentTime / 60f);
        int seconds = Mathf.FloorToInt(isCountingDown ? currentTime - minutes * 60 : currentTime - minutes * 60);
        countdownText.text = string.Format("{0:0}:{1:00}", minutes, seconds);
        slider.value = currentCounter;
    }

    public void NightCountdownBool()
    {
        isCountingDown = false;
    }

    public void DayCountdownBool()
    {
        isCountingDown = true;
    }
}
