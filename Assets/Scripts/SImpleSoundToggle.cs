using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class SimpleSoundToggle : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Toggle>().onValueChanged.AddListener(UpdateAudio);
    }

    private void UpdateAudio(bool state)
    {
        Debug.Log("UpdateAudio: " + state.ToString());
        mixer.SetFloat("MasterVolume", state ? 0 : -80);
    }
}
