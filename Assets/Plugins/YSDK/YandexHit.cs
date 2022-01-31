using UnityEngine;
using Zenject;

namespace Plugins.YSDK
{
    public class YandexHit : MonoBehaviour
    {
        [Inject] private YandexSDK instance;
        public void Hit(string eventName) => instance.AddHit(eventName);
    }
}
