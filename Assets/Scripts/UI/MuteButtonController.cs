using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteButtonController : MonoBehaviour
{
    [SerializeField] GameObject crossMute;
    private bool isMute = false;

    private void Update()
    {
        CheckIfMute();
    }

    public void MuteButton()
    {
        if (!isMute)
        {
            AudioListener.volume = 0f;
            isMute = true;
        }

        else
        {
            AudioListener.volume = 1f;
            isMute = false;
        }
    }

    private void CheckIfMute()
    {
        if (AudioListener.volume == 0)
        {
            isMute = true;
            crossMute.SetActive(true);
        }

        else
        {
            isMute = false;
            crossMute.SetActive(false);
        }
    }
}
