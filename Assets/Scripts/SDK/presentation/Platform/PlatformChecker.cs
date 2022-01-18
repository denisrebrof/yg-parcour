using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace SDK.presentation.Platform
{
    public class PlatformChecker: MonoBehaviour
    {
        [Inject] private IPlatformProvider platformProvider;
        [SerializeField] private Platform platform;
        [SerializeField] private UnityEvent onTypeMatches;
        [SerializeField] private UnityEvent onTypeNotMatches;

        void Awake()
        {
            var currentPlatform = platformProvider.GetCurrentPlatform();
            if (currentPlatform == platform)
                onTypeMatches.Invoke();
            else
                onTypeNotMatches.Invoke();
        }
    }
}