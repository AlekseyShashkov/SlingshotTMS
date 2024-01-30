using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Launcher : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Vector2 _startPoint = Vector2.zero;
    [SerializeField, Range(1f, 10f)] private float _maxLength = 2.0f;

    public event Action<Vector2> OnRelease;
    
    public void OnBeginDrag(PointerEventData eventData)
    {
       _startPoint = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Vector2.Distance(_startPoint, mousePosition) < _maxLength)
        {
            transform.position = mousePosition;
        }
        else
        {
            Vector2 direction = (mousePosition - _startPoint).normalized * _maxLength;
            transform.position = _startPoint + direction;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Vector2 releasePosition = transform.position;
        Vector2 delta = releasePosition - _startPoint;

        transform.position = _startPoint;

        Vector2 direction = delta.normalized * (delta.magnitude / _maxLength);
        OnRelease?.Invoke(direction);
    }
}