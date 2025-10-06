using UnityEngine;
using UnityEngine.UI;

public class StatsHUD : MonoBehaviour
{
    public Stats stats;
    public Image healthbar;
    public Image manaBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        healthbar.fillAmount = stats.currentHealth / stats.maxHealth;
        manaBar.fillAmount = stats.maxHealth / stats.currentMana;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
