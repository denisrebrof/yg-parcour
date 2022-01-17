using System.Linq;
using UnityEngine;

namespace Gameplay
{
    public class FirstPersonLookMobileDeltaProvider : FirstPersonLook.ILookDeltaProvider
    {
        private int minX = Screen.width / 2;

        public Vector2 GetDelta()
        {
            if (!Input.touches.Any(TouchInLookControlArea))
                return Vector2.zero;
            return Input.touches.First(TouchInLookControlArea).deltaPosition;
        }

        private bool TouchInLookControlArea(Touch touch) => touch.position.x > minX;
    }
}