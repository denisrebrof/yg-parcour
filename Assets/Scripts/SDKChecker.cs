using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SDKChecker : MonoBehaviour
{
    [SerializeField] private SDKType type;
    [SerializeField] private UnityEvent onTypeMatches;
    [SerializeField] private UnityEvent onTypeNotMatches;
    void Awake()
    {
#if YANDEX_SDK
        if (type == SDKType.Yandex)
        {
            onTypeMatches.Invoke();
            return;
        }
#elif VK_SDK
        if(type==SDKType.Vk)
        {
            onTypeMatches.Invoke();
            return;
        }
#elif POKI_SDK
        if (type == SDKType.Poki)
        {
            onTypeMatches.Invoke();
            return;
        }
#else
        onTypeMatches.Invoke();
        return;
#endif
        onTypeNotMatches.Invoke();
    }

    public enum SDKType
    {
        None,
        Yandex,
        Vk,
        Poki
    }
}
