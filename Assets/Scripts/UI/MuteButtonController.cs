using UnityEngine;
using UnityEngine.SceneManagement;

public class MuteButtonController : MonoBehaviour
{
    [SerializeField] private  GameObject crossMute;

    //TODO: TP2 - Optimization - Should be event based --> DONE
    private void OnEnable()
    {
        SceneManager.sceneLoaded += CheckIfMute;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= CheckIfMute;
    }

    public void MuteButton()
    {
        if (AudioListener.volume == 1f)
        {
            AudioListener.volume = 0f;
            crossMute.SetActive(true);
        }

        else
        {
            AudioListener.volume = 1f;
            crossMute.SetActive(false);
        }
    }

    public void CheckIfMute(Scene scene, LoadSceneMode mode)
    {
        if (AudioListener.volume == 0f)
        {
            crossMute.SetActive(true);
        }

        else
        {
            crossMute.SetActive(false);
        }
    }
}
