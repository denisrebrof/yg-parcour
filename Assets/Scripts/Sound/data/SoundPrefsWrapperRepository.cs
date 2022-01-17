using FileIO;
using Sound.domain;

namespace Sound.data
{
    public class SoundPrefsWrapperRepository: ISoundPrefsRepository
    {
        private string prefsKey = "soundEnabledState";
        
        public void SetSoundEnabledState(bool enabled) => PlayerPrefsWrapper.SetString(prefsKey, enabled ? "1" : "0");

        public bool GetSoundEnabledState()
        {
            return PlayerPrefsWrapper.GetString(prefsKey, "1") == "1";
        }
    }
}