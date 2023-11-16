using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInputReader : MonoBehaviour
{
    [SerializeField] GameObject creditsScreen;
    [SerializeField] Button button;

    private void Start()
    {
        //TODO: TP2 - Fix - Careful with float equal comparisons, they can lead to decimal errors --> DONE
        if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void StartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void CreditsScreen()
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
