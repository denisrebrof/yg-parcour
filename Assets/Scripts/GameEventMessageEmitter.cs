using System.Collections;
using System.Collections.Generic;
using Doozy.Engine;
using UnityEngine;

public class GameEventMessageEmitter : MonoBehaviour
{
    [SerializeField] private string message;

    public void Emit()
    {
        if(string.IsNullOrEmpty(message))
            return;
        
        GameEventMessage.SendEvent(message);
    }
}
