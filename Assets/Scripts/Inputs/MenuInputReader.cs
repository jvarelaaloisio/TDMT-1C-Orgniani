using UnityEngine;
using UnityEngine.EventSystems;

public class MenuInputReader : MonoBehaviour
{
    [SerializeField] private EventSystem eventSystem;
    [SerializeField] private GameManager gameManager;

    [SerializeField] private GameObject creditsScreen;
    [SerializeField] private GameObject backButton;

    private void Start()
    {
        //TODO: TP2 - Fix - Careful with float equal comparisons, they can lead to decimal errors --> DONE
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void StartButton()
    {
        gameManager.GoToNextLevel();
    }

    public void CreditsButton()
    {
        creditsScreen.SetActive(true);
        eventSystem.SetSelectedGameObject(backButton);
    }

    public void BackButton()
    {
        creditsScreen.SetActive(false);
        ResetSelected();
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    private void ResetSelected()
    {
        eventSystem.SetSelectedGameObject(eventSystem.firstSelectedGameObject);
    }
}
