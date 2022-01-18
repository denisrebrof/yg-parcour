using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Inputs
{
    public class MovementMobileInputProvider : FirstPersonMovement.IMovementInputProvider, IMovementInputHandler
    {
        private Dictionary<string, float> inputHandler = new();

        public Vector2 GetInput()
        {
            var x = inputHandler.ContainsKey("Horizontal") ? inputHandler["Horizontal"] : 0f;
            var y = inputHandler.ContainsKey("Vertical") ? inputHandler["Vertical"] : 0f;
            return new Vector2(x, y);
        }

        public void SetInput(float input, string axis)
        {
            inputHandler[axis] = input;
        }
    }
}