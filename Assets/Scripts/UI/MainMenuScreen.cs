using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScreen : MonoBehaviour
{
    public void StartButton()
    {
        gameObject.SetActive(false);
    }

    public void CreditsButton()
    {

    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
