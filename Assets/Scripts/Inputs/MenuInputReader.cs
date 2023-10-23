using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuInputReader : MonoBehaviour
{
    [SerializeField] GameObject creditsScreen;
    [SerializeField] Button button;

    private void Start()
    {
        if (Time.timeScale == 0f)
            Time.timeScale = 1f;
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
