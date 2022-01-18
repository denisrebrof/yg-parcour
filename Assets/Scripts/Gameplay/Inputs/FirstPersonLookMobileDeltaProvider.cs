using System.Linq;
using UnityEngine;
using static UnityEngine.Input;

namespace Gameplay.Inputs
{
    public class FirstPersonLookMobileDeltaProvider : FirstPersonLook.ILookDeltaProvider
    {
        private int minX = Screen.width / 2;

        public Vector2 GetDelta()
        {
            if (!touches.Any(TouchInLookControlArea))
                return Vector2.zero;
            return touches.First(TouchInLookControlArea).deltaPosition;
        }

        private bool TouchInLookControlArea(Touch touch) => touch.position.x > minX;
    }
}