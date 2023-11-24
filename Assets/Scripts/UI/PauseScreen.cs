using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    [SerializeField] private string mainMenu = "MainMenu";
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameObject tile;
    public void PauseGame()
    {
        gameObject.SetActive(true);
        tile.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeButton()
    {
        gameObject.SetActive(false);
        tile.SetActive(false);
        ResetSelected();
        Time.timeScale = 1;
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(mainMenu);
    }

    private void ResetSelected()
    {
        eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
    }
}
