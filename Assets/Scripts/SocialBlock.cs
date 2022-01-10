using UnityEngine;

public class SocialBlock : MonoBehaviour
{
    void Start()
    {
#if VK_SDK
        return;
#else
            gameObject.SetActive(false);
#endif
    }
}