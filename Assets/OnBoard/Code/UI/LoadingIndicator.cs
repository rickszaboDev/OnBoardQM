using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OnBoard.Controller;

public class LoadingIndicator : MonoBehaviour
{
    public float progress = 0f;
    public Slider LoadingBar;

    // Update is called once per frame
    void Update()
    {
        LoadingBar.value = 0.5f + progress;
    }
}
