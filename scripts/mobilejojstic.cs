using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class mobilejojstic : MonoBehaviour,IPointerUpHandler,IDragHandler,IPointerDownHandler
{
    private RectTransform jojstic;
    [SerializeField] private  float  dragthreshold=0.6f;
    [SerializeField] private int dragMovementDistance =60;
    [SerializeField] private int dragOffsetDistance =200;
    [SerializeField] private movemnt movement;
  
    statc stat = new statc(10f,10f);
    public event Action<Vector2> OnMove;
    public Vector2 offset;

    public void OnDrag(PointerEventData eventData)
    {
      
        RectTransformUtility.ScreenPointToLocalPointInRectangle(jojstic, eventData.position, null, out offset);
        offset = Vector2.ClampMagnitude(offset, dragOffsetDistance) / dragOffsetDistance;
        //Debug.Log(offset);
        jojstic.anchoredPosition = offset * dragMovementDistance;
        Vector2 inputVector = CalculateMovementInput(offset);
        OnMove?.Invoke(inputVector);
       


    }
    private Vector2 CalculateMovementInput( Vector2 offset)
    {
        float x = Mathf.Abs(offset.x) > dragthreshold ? offset.x : 0;
        float y = Mathf.Abs(offset.y) > dragthreshold ? offset.y : 0;
        return new Vector2(x, y);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
       
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        jojstic.anchoredPosition = Vector2.zero;
        OnMove?.Invoke(Vector2.zero);
    }
    private void Awake()
    {
        jojstic = (RectTransform)transform;
       movement. rb = GetComponent<Rigidbody2D>();
    }
    public Vector2 GetOffset()
    {
        return offset;
    }
}
