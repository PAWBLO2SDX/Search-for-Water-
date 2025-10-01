using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuManager : MonoBehaviour
{
    public GameObject PauseMenu;

    public void OnClickResume()
    {
        PauseMenu.SetActive(false);
    }

    public void OnClickExit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
