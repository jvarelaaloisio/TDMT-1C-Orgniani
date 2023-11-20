using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private string mainMenu = "MainMenu";
    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(mainMenu);
    }
}
