using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc) --> DONE
    [SerializeField] private PauseScreen pauseScreen;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private EventSystem eventSystem;

    [SerializeField] private GameObject restartButton;
    [SerializeField] private GameObject continueButton;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject tile;

    public void Setup()
    {
        gameObject.SetActive(true);
        tile.SetActive(true);
        pauseButton.SetActive(false);
        eventSystem.SetSelectedGameObject(restartButton);
    }

    public void RestartButton()
    {
        gameManager.RestartGame();
    }

    public void RestartLevelButton()
    {
        gameManager.RestartLevel();
    }

    public void BackToMenuButton()
    {
        gameManager.BackToMenu();
    }

    public void PauseButton()
    {
        pauseScreen.PauseGame();
        eventSystem.SetSelectedGameObject(continueButton);
    }
}
