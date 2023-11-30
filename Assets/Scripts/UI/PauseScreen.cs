using UnityEngine;
using UnityEngine.EventSystems;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private EventSystem eventSystem;

    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject tile;
    public void PauseGame()
    {
        gameObject.SetActive(true);
        tile.SetActive(true);
        pauseButton.SetActive(false);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        gameObject.SetActive(false);
        tile.SetActive(false);
        pauseButton.SetActive(true);
        ResetSelected();
        Time.timeScale = 1;
    }

    public void BackToMenuButton()
    {
        gameManager.BackToMenu();
    }

    private void ResetSelected()
    {
        eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
    }
}
