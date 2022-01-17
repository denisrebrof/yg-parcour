using System;
using static FileIO.PlayerPrefsWrapper;

namespace Levels.data.dao
{
    public class PlayerPrefsWrapperCurrentLevelIdDao : CurrentLevelRepository.ICurrentLevelIdDao
    {
        private const string PrefsKeyPrefix = "CurrentLevelId";
        
        public bool HasCurrentLevelId() => HasKey(PrefsKeyPrefix);

        public long GetCurrentLevelId()
        {
            var storedLevelIdData = GetString(PrefsKeyPrefix);
            return Convert.ToInt64(storedLevelIdData);
        }

        public void SetCurrentLevelId(long id) => SetString(PrefsKeyPrefix, id.ToString());
    }
}