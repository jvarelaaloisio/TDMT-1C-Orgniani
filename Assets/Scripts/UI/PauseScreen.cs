using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScreen : MonoBehaviour
{
    public void PauseGame()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ResumeButton()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
