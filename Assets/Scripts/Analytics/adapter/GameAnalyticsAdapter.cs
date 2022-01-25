#if GAME_ANALYTICS
using System;
using System.Collections.Generic;
using Analytics.ads;
using Analytics.levels;
using Analytics.screens;
using Analytics.session;
using Analytics.settings;
using GameAnalyticsSDK;

namespace Analytics
{
    public class GameAnalyticsAdapter: AnalyticsAdapter
    {
        private static string defaultPostfix = "Undefined";
        public override void SendAdEvent(AdAction action, AdType type, AdProvider provider, IAdPlacement placement)
        {
            var gAAction = action switch
            {
                AdAction.Request => GAAdAction.Request,
                AdAction.Show => GAAdAction.Show,
                AdAction.Failure => GAAdAction.FailedShow,
                _ => GAAdAction.Undefined
            };
            var gAType = type switch
            {
                AdType.Rewarded => GAAdType.RewardedVideo,
                AdType.Interstitial => GAAdType.Interstitial,
                _ => GAAdType.Undefined
            };
            GameAnalytics.NewAdEvent(gAAction, gAType, provider.ToString(), placement.GetName());
        }

        public override void SendSettingsEvent(SettingType type, string val)
        {
            var eventName = "Setting_" + type switch
            {
                SettingType.SoundToggle => "Sound",
                _ => defaultPostfix
            };
            var param = new Dictionary<string, object> { { "value", val } };
            GameAnalytics.NewDesignEvent(eventName, param);
        }

        public override void SendScreenEvent(string screenName, ScreenAction action)
        {
            var eventName = "Screen_" + action switch
            {
                ScreenAction.Open => "Open",
                ScreenAction.Close => "Close",
                _ => defaultPostfix
            };
            var param = new Dictionary<string, object> { { "screenName", screenName } };
            GameAnalytics.NewDesignEvent(eventName, param);
        }

        public override void SendLevelEvent(LevelPointer levelPointer, LevelEvent levelEvent)
        {
            if (levelEvent == LevelEvent.Load)
            {
                SendLoadLevelEvent(levelPointer);
                return;
            }
            
            var gAProgressionStatus = levelEvent switch
            {
                LevelEvent.Start => GAProgressionStatus.Start,
                LevelEvent.Fail => GAProgressionStatus.Fail,
                LevelEvent.Complete => GAProgressionStatus.Complete,
                _ => GAProgressionStatus.Undefined
            };;
            GameAnalytics.NewProgressionEvent(GAProgressionStatus.Complete, "Level_" + levelPointer.LevelId);
        }

        public override void SendSessionEvent(SessionEvent sessionEvent, LevelPointer currentLevelPointer)
        {
            var param = new Dictionary<string, object> {{"level", currentLevelPointer.LevelId}};
            var eventName = sessionEvent switch
            {
                SessionEvent.Start => "Game Session Started",
                SessionEvent.Quit => "Quit",
                _ => defaultPostfix
            };
            GameAnalytics.NewDesignEvent(eventName, param);
        }

        public override void SendErrorEvent(string error)
        {
            GameAnalytics.NewErrorEvent(GAErrorSeverity.Error, error);
        }

        private void SendLoadLevelEvent(LevelPointer levelPointer)
        {
            var param = new Dictionary<string, object> {{"levelId", levelPointer.LevelId}};
            GameAnalytics.NewDesignEvent("ManualLoadLevel", param);
        }

        public override void SetPlayerId(string id)
        {
            GameAnalytics.SetCustomId(id);
        }
    }
}
#endif