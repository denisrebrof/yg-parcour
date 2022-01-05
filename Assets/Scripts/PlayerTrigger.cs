using System;
using Doozy.Engine;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent triggerEvent;
    [SerializeField] private UnityEvent exitTriggerEvent;
    [SerializeField] private string gameEvent;
    [SerializeField] private string exitGameEvent;
    [SerializeField] private string triggerTag = "Player";

    private bool activeState;

    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag(triggerTag))
            return;
        
        if (triggerEvent != null) triggerEvent.Invoke();
        if(!String.IsNullOrEmpty(gameEvent)) GameEventMessage.SendEvent(gameEvent);
        activeState = true;
    }

    private void OnDestroy()
    {
        if(activeState)
            ExitTrigger();
    }

    private void OnTriggerExit(Collider other)
    {
        if(!other.CompareTag(triggerTag))
            return;

        ExitTrigger();
        activeState = false;
    }

    private void ExitTrigger()
    {
        if (exitTriggerEvent != null) exitTriggerEvent.Invoke();
        if (!String.IsNullOrEmpty(exitGameEvent)) GameEventMessage.SendEvent(exitGameEvent);
    }
}