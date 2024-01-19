using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pepe : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(Input.mousePosition) 
            - transform.position;
        
        transform.Translate(position);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Pepe ready to fly!");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Pepe fly!");
    }
}