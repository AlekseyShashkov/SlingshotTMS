using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Strip : MonoBehaviour
{
    private const int StartPoint = 0;
    private const int EndPoint = 1;
    private const int PointCount = 2;
  
    [SerializeField] private Transform _target = null;
    private LineRenderer _lineRenderer = null;

    void Awake()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = PointCount;
        _lineRenderer.SetPosition(StartPoint, transform.position);
    }

    void Update()
    {
        _lineRenderer.SetPosition(EndPoint, _target.position);
    }
}