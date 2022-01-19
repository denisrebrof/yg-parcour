﻿using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Gameplay.Inputs
{
    public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        [Inject] private InputHandler handler;
        [SerializeField] private string axisName = "Horizontal";
        [SerializeField] private float posVal = 1f;
        [SerializeField] private float emptyVal = 0f;
        [SerializeField] private bool fireOnce = false;

        public void OnPointerDown(PointerEventData eventData)
        {
            if (fireOnce)
            {
                StartCoroutine(FireInput());
                return;
            }
            handler.SetInput(posVal, axisName);
        }

        private IEnumerator FireInput()
        {
            handler.SetInput(posVal, axisName);
            yield return new WaitForSeconds(0.2f);
            handler.SetInput(emptyVal, axisName);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            handler.SetInput(emptyVal, axisName);
        }
    }
}