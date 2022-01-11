using System.Collections.Generic;
using GameAnalyticsSDK;
using Levels.presentation.ui;
using Zenject;

public class LevelItemControllerStatDecorator : LevelItem.ILevelItemController
{
    private LevelItem.ILevelItemController target;

    [Inject]
    public LevelItemControllerStatDecorator(LevelItem.ILevelItemController decorationTarget)
    {
        target = decorationTarget;
    }

    public void OnItemClick(long levelId)
    {
        var param = new Dictionary<string, object>();
        param.Add("levelId", levelId as object);
        GameAnalytics.NewDesignEvent("ManualLoadLevel", param);
        target.OnItemClick(levelId);
    }
}
