﻿using SDK.presentation.Platform;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MobileInputDebug : MonoBehaviour
{
    [SerializeField] private Text target;
    [Inject] private IPlatformProvider platformProvider;

    private bool isOnDesktop = true;

    private void Start()
    {
        isOnDesktop = platformProvider.GetCurrentPlatform() == Platform.Desktop;
        if (isOnDesktop) target.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (isOnDesktop) return;
        var text = "Input: ";
        foreach (var touch in Input.touches)
        {
            text += "t" + touch.fingerId + ": ";
            text += "pos:" + touch.position + ";";
            text += "phase:" + touch.phase + ";  |  ";
        }
        target.text = text;
    }
}