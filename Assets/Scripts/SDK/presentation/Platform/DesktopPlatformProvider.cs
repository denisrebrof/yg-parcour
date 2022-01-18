namespace SDK.presentation.Platform
{
    public class DesktopPlatformProvider: IPlatformProvider
    {
        public Platform GetCurrentPlatform() => Platform.Desktop;
    }
}