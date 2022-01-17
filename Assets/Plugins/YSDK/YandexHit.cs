using UnityEngine;
using Zenject;

public class YandexHit : MonoBehaviour
{
    #if YANDEX_SDK
    [Inject] private YandexSDK instance;
    #endif
    
    public void Hit(string eventName)
    {
#if YANDEX_SDK
        if (instance is not null) instance.AddHit(eventName);
#endif
    }
}
