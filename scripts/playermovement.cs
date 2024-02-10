using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
public class playermovement : MonoBehaviour
{ 
   

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private InputActionReference iar;
    private Vector2 horizontal;

    statc Statc = new statc(8f, 16f);


    void Awake()
    {
       
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        /*
        Debug.Log("horizontal is " + horizontal);
        horizontal = iar.action.ReadValue<Vector2>();
          if (horizontal.x > 0)
             {
                 rb.velocity = new Vector3(Statc.speed ,rb.velocity.y,0);
             }
             else if (horizontal.x < 0)
             {
                 rb.velocity = new Vector3(-Statc.speed , rb.velocity.y,0);
             }*/
       

    }
    public void MoveLeft()
    {
        rb.velocity = new Vector2(-Statc.speed, rb.velocity.y);
    }
    public void MoveRight()
    {
        rb.velocity = new Vector2(Statc.speed, rb.velocity.y);
    }
    public void MoveLeft(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2(-Statc.speed, rb.velocity.y);
    }
    public void MoveRight(InputAction.CallbackContext context)
    {
        rb.velocity = new Vector2(Statc.speed, rb.velocity.y);
    }




}
