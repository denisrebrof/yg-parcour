namespace SDK.presentation.Platform
{
    public class MobilePlatformProvider: IPlatformProvider
    {
        public Platform GetCurrentPlatform() => Platform.Mobile;
    }
}