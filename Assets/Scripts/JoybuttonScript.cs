using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class JoybuttonScript : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector] public bool isPressing;

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressing = true;
     
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressing = false;
    }
}
