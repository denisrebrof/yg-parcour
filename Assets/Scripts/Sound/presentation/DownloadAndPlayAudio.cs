using System;
using System.Collections;
using UnityEngine;

namespace Sound.presentation
{
    [RequireComponent(typeof(AudioSource))]
    public class DownloadAndPlayAudio: MonoBehaviour
    {
        public string url;
        public AudioSource source;

        IEnumerator Start()
        {
            source = GetComponent<AudioSource>();
            using var www = new WWW(url);
            yield return www;
            try
            {
                source.clip = www.GetAudioClip();
                source.Play();
            }
            catch (Exception e)
            {
                Debug.LogError(e);
            }
            
        }
    }
}