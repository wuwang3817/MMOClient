
using System;
using UnityEngine;
using UnityEngine.EventSystems;
//UI事件监听
public class Listener :MonoBehaviour,IPointerClickHandler,IPointerDownHandler,IPointerUpHandler,IDragHandler 
{
    public Action<PointerEventData, object[]> onDrag;
    public Action<PointerEventData, object[]> onClick;
    public Action<PointerEventData, object[]> onClickUp;
    public Action<PointerEventData, object[]> onClickDown;
    
    public object[] args = null;

    public void OnPointerClick(PointerEventData eventData) 
    {
        onClick?.Invoke(eventData, args);
    }
    public void OnPointerDown(PointerEventData eventData) 
    {
        onClickDown?.Invoke(eventData, args);
    }
    public void OnPointerUp(PointerEventData eventData) 
    {
        onClickUp?.Invoke(eventData, args);
    }
    public void OnDrag(PointerEventData eventData) 
    {
        onDrag?.Invoke(eventData, args);
    }
}
