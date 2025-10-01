using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject OptionsMenu;

    public GameObject PauseMenu;

    public void OnClickPlay()
    {
        SceneManager.LoadScene("MainLevel");
    }

    public void OnClickOptions()
    {
        OptionsMenu.SetActive(true);
    }

    public void OnClickQuit()
    {
        Application.Quit();
    }

    public void OnClickPause()
    {
        PauseMenu.SetActive(true);
    }
}
