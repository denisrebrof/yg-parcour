using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Gameplay.Inputs
{
    public class InputButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        [Inject] private IMovementInputHandler handler;
        [SerializeField] private string axisName = "Horizontal";
        [SerializeField] private float posVal = 1f;
        [SerializeField] private float emptyVal = 0f;
        [SerializeField] private bool up = false;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            if(up)
                return;
            handler.SetInput(posVal, axisName);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if(up)
                return;
            handler.SetInput(emptyVal, axisName);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if(!up)
                return;
            handler.SetInput(posVal, axisName);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if(!up)
                return;
            handler.SetInput(emptyVal, axisName);
        }
    }
}