using UnityEngine;
using UnityEngine.SceneManagement;


public class WinLoseMenu : MonoBehaviour
{
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
