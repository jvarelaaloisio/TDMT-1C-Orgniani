using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInputReader : MonoBehaviour
{
    [SerializeField] private GameObject creditsScreen;

    [SerializeField] private string tutorialLevel = "TutorialLevel";

    private void Start()
    {
        //TODO: TP2 - Fix - Careful with float equal comparisons, they can lead to decimal errors --> DONE
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void StartButton()
    {
        SceneManager.LoadScene(tutorialLevel);
    }

    public void CreditsButton()
    {
        creditsScreen.SetActive(true);
    }

    public void BackButton()
    {
        creditsScreen.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
