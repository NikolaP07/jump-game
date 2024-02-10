using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class movemnt : MonoBehaviour
{

  
  private float horizontal;
    

    private bool isFacingRight = true;
    public float maxHeight = 0;
    public int points = 0;




    statc Statc = new statc(12f, 18f);




    private bool isWallSliding;
    private float wallSlidingSpeed = 2f;


    private bool isWallJumping;
    private float wallJumpingDirection;
    private float wallJumpingTime = 0.2f;
    private float wallJumpingCounter;
    private float wallJumpingDuration = 0.4f;
    private Vector2 wallJumpingPower = new Vector2(10f, 18f);
    public Vector2 CurentPosition;
    private Vector2 JojsticCurentPosition;


    [SerializeField] public  Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private AudioSource audiosourse;
   
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void Update()
    {

        //  Debug.Log(JojsticCurentPosition);
     

        
    
        CurentPosition = transform.position;

        if (maxHeight < CurentPosition.y)
        {
            maxHeight = CurentPosition.y;
            points++;
        }
     ///  horizontal = Input.GetAxisRaw("Horizontal");


     
        

        WallSlide();


        if (!isWallJumping)
        {
            Flip();
        }

    }

    private void FixedUpdate()
    {
      
            if (!isWallJumping)
        {
            rb.velocity = new Vector2(Statc.speed* horizontal, rb.velocity.y);
        }
       

    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private bool IsWalled()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 0.2f, wallLayer);
    }

    private void WallSlide()
    {
        if (IsWalled() && !IsGrounded() && horizontal != 0f)
        {
            isWallSliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else
        {
            isWallSliding = false;
        }
    }

    private void WallJump()
    {
        if (isWallSliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if (wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }else if (IsWalled() || wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x, wallJumpingPower.y);
            wallJumpingCounter = 0f;

            if (transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }

            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }
    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    void OnBecameInvisible()
    {
        //SceneManager.LoadScene(0);
    }
    public void BoostSpeed()
    {

        Statc.speed++;
        Debug.Log("bost speed by " + Statc.speed);
        functiontimer.Create(BoostSpeedUN, 5f);

    }
    void BoostSpeedUN()
    {

        Statc.speed--;

        Debug.Log("bost speed by " + Statc.speed);
    }
    public void BoostJump()
    {
        Statc.jumpingPower++;
        Debug.Log("bost jump by " + Statc.jumpingPower);
        functiontimer.Create(BoostJumpUN, 5f);
    }
    void BoostJumpUN()
    {
        
        Statc.jumpingPower--;
        Debug.Log("bost speed by " + Statc.jumpingPower);
    }

  
   
   public void Move(InputAction.CallbackContext context)
    {
        
        horizontal = context.ReadValue<Vector2>().x;
        Debug.Log("horizontal is|" +horizontal);
        if(horizontal==1)
        {

            Right();
        }
        if (horizontal==-1)
        {
            Left();
        }
     
  
        }
        public void Jump(InputAction.CallbackContext context)
    { 
        if (IsWalled())
        {
            audiosourse.Play();
            WallJump();
        }else 
        if (IsGrounded() ) {
            audiosourse.Play();
            rb.velocity = new Vector2(rb.velocity.x, Statc.jumpingPower);
        
        }
        else if (IsGrounded() || IsWalled()) { rb.velocity = new Vector2(rb.velocity.x, Statc.jumpingPower); }
    }
   public void Jump()
    {
        if (IsWalled())
        {
            audiosourse.Play();
            WallJump();
        }
        else
        if (IsGrounded()) { audiosourse.Play(); rb.velocity = new Vector2(rb.velocity.x, Statc.jumpingPower); }
        else if (IsGrounded() || IsWalled()) { audiosourse.Play();  rb.velocity = new Vector2(rb.velocity.x, Statc.jumpingPower); }
  }
    public void Right()
    {

        rb.velocity = new Vector2(Statc.speed, rb.velocity.y);
        Debug.Log(rb.velocity);

    }
    public void Left()
    {
     
        rb.velocity = new Vector2(-Statc.speed,rb.velocity.y);
        Debug.Log(rb.velocity);

    }






}
