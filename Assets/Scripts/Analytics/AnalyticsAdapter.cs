using Analytics.ads;
using Analytics.ads.placement;
using Analytics.levels;
using Analytics.screens;
using Analytics.session;
using Analytics.settings;

namespace Analytics
{
    public abstract class AnalyticsAdapter
    {
        public abstract void SendAdEvent(AdAction action, AdType type, AdProvider provider, IAdPlacement placement);
        public abstract void SendSettingsEvent(SettingType type, string val);
        public abstract void SendScreenEvent(string screenName, ScreenAction action);
        public abstract void SendLevelEvent(LevelPointer levelPointer, LevelEvent levelEvent);
        public abstract void SendSessionEvent(SessionEvent sessionEvent, LevelPointer currentLevelPointer);
        public abstract void SendErrorEvent(string error);
    }
}