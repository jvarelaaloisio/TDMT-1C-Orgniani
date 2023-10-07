using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenLeavingScreen : MonoBehaviour
{
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
