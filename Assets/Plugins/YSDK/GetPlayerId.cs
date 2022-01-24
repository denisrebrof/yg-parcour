using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace YandexSDK
{
    public class GetPlayerId : MonoBehaviour
    {
        [Inject] private Plugins.YSDK.YandexSDK sdk;

        [SerializeField] private UnityEvent<string> onPlayerIdReceived = new();

        void Start()
        {
            sdk.onPlayerIdReceived += (id) => onPlayerIdReceived.Invoke(id);
            sdk.RequestPlayerIndentifier();
        }
    }
}