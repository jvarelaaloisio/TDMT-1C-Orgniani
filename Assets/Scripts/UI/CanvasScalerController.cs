using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasScalerController : MonoBehaviour
{

    [SerializeField] private CanvasScaler canvasScaler;

    private void OnEnable()
    {
        float currentAspectRatio = (float)Screen.height / Screen.width;
        float canvasScalerAspectRatio = canvasScaler.referenceResolution.y / canvasScaler.referenceResolution.x;
        if (currentAspectRatio < canvasScalerAspectRatio)
            canvasScaler.matchWidthOrHeight = 1f;
        else
            canvasScaler.matchWidthOrHeight = 0f;
    }
}
