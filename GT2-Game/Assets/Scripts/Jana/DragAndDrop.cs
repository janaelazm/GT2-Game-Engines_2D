using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    // to move pot when dragged
    private RectTransform _rectTransform;
    
    //To block raycasting so that the system can recognize which stove eye is under the pot.
    private CanvasGroup _canvasGroup;
    public int potID;
    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        
        //So that the start position of the pot is bottom-right
        _rectTransform.anchoredPosition = new Vector2((float) 87 , (float)96);
        potID = 1;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Begin Drag");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("On Drag");
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Stop Drag");
        _canvasGroup.blocksRaycasts = true;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Click");
        
        //Change position of pot with mouse
        _rectTransform.anchoredPosition += eventData.delta;
    }
}
