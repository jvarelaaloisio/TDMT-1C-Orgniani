using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc) --> DONE
    [SerializeField] private PauseScreen pauseScreen;
    [SerializeField] private GameOverScreen victoryScreen;
    [SerializeField] private string firstLevel = "FirstLevel";
    [SerializeField] private string mainMenu = "MainMenu";
    [SerializeField] private string currentScene = "BossLevel";

    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject continueButton;

    [SerializeField] private GameObject tile;

    public void Setup()
    {
        gameObject.SetActive(true);
        tile.SetActive(true);
        eventSystem.SetSelectedGameObject(restartButton);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(firstLevel);
    }

    public void RestartLevelButton()
    {
        SceneManager.LoadScene(currentScene);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(mainMenu);
    }

    public void PauseButton()
    {
        if(victoryScreen != null)
        {
            if (!gameObject.activeSelf && !victoryScreen.gameObject.activeSelf)
            {
                pauseScreen.PauseGame();
                eventSystem.SetSelectedGameObject(continueButton);
            }
        }

        else
        {
            if (!gameObject.activeSelf)
            {
                pauseScreen.PauseGame();
                eventSystem.SetSelectedGameObject(continueButton);
            }
        }
    }
}
