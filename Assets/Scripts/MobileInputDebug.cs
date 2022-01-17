using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MobileInputDebug : MonoBehaviour
{
    [SerializeField] private Text target;
#if YANDEX_SDK
    [Inject] private YandexSDK sdk;
#endif

    private bool isOnDesktop = false;

    private void Start()
    {
        try
        {
            isOnDesktop = sdk.GetIsOnDesktop();
        }
        catch (Exception e)
        {
        }
        if (isOnDesktop) target.gameObject.SetActive(false);
    }

    private void Update()
    {
#if YANDEX_SDK
        if (isOnDesktop)
            return;
        var text = "Input: ";
        foreach (var touch in Input.touches)
        {
            text += "t" + touch.fingerId + ": ";
            text += "pos:" + touch.position + ";";
            text += "phase:" + touch.phase + ";  |  ";
        }

        target.text = text;
#endif
    }
}