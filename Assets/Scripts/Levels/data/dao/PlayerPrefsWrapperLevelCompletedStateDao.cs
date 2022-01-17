using System;
using FileIO;

namespace Levels.data.dao
{
    public class PlayerPrefsWrapperLevelCompletedStateDao : ILevelCompletedStateDao
    {
        private const string PrefsKeyPrefix = "LevelCompletedState";

        public bool IsCompleted(long levelId)
        {
            var prefKey = GetPrefKey(levelId);
            var defValue = (int)CompletedState.NotCompleted;
            var prefValue = PlayerPrefsWrapper.GetString(prefKey, defValue.ToString());
            var prefstate = (CompletedState) Convert.ToInt32(prefValue);
            return prefstate == CompletedState.Completed;
        }

        public void SetCompleted(long levelId)
        {
            var prefKey = GetPrefKey(levelId);
            var val = (int)CompletedState.Completed;
            PlayerPrefsWrapper.SetString(prefKey, val.ToString());
        }

        private static string GetPrefKey(long levelId) => $"{PrefsKeyPrefix}_{levelId}";

        private enum CompletedState
        {
            NotCompleted,
            Completed
        }
    }
}