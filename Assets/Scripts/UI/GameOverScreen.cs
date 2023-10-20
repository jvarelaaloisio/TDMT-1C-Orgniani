using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] PauseScreen pauseScreen;
    [SerializeField] GameObject crossSound;
    private bool isMute = false;

    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }

    public void PauseButton()
    {
        pauseScreen.PauseGame();
    }

    public void MuteButton()
    {
        if (!isMute)
        {
            AudioListener.volume = 0f;
            isMute = true;
            crossSound.SetActive(true);
        }

        else
        {
            AudioListener.volume = 1f;
            isMute = false;
            crossSound.SetActive(false);
        }
    }
}
