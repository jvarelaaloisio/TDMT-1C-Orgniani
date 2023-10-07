using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadingGameInputReade : MonoBehaviour
{
    [SerializeField] private float loadingTime = 1;
    [SerializeField] private Image loadingBar;

    private float _lastLoadingStartTime = 0;
    private float loadingDuration = 0;
    private bool _isLoading;

    private void Update()
    {
        float timeElapsed = Time.time - _lastLoadingStartTime;

        if(loadingBar)
        {
            if(_isLoading)
            {
                loadingBar.fillAmount = timeElapsed / loadingTime;
            }

            else
            {
                loadingBar.fillAmount = 0;
            }
        }
    }
}
