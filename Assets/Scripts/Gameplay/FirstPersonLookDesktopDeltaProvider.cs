using UnityEngine;

namespace Gameplay
{
    public class FirstPersonLookDesktopDeltaProvider: FirstPersonLook.ILookDeltaProvider
    {
        public Vector2 GetDelta() => new(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    }
}