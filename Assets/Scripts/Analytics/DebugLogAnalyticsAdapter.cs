﻿using Analytics.ads;
using Analytics.levels;
using Analytics.screens;
using Analytics.session;
using Analytics.settings;
using UnityEngine;

namespace Analytics
{
    public class DebugLogAnalyticsAdapter : AnalyticsAdapter
    {
        private readonly bool loggingEnabled = false;

        public DebugLogAnalyticsAdapter(bool loggingEnabled)
        {
            this.loggingEnabled = loggingEnabled;
        }

        public override void SendAdEvent(AdAction action, AdType type, AdProvider provider, IAdPlacement placement)
        {
            Log(" SendAdEvent: " + action + ' ' + type);
        }

        public override void SendSettingsEvent(SettingType type, string val)
        {
            Log("SendSettingsEvent: " + type + ' ' + val);
        }

        public override void SendScreenEvent(string screenName, ScreenAction action)
        {
            Log("SendScreenEvent: " + screenName + ' ' + action);
        }

        public override void SendLevelEvent(LevelPointer levelPointer, LevelEvent levelEvent)
        {
            Log("SendLevelEvent: " + levelPointer.LevelId + ' ' + levelEvent);
        }

        public override void SendSessionEvent(SessionEvent sessionEvent, LevelPointer currentLevelPointer)
        {
            Log("SendSessionEvent: " + sessionEvent);
        }

        public override void SendErrorEvent(string error)
        {
            Log("SendErrorEvent: " + error);
        }

        private void Log(string text)
        {
            if (!loggingEnabled) return;
            Debug.Log("Debug Analytics Event: " + text);
        }
    }
}