using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private Animator anim;

    [SerializeField] private LayerMask jumpAbleGround;

   private float dirX = 0;
   [SerializeField] private float moveSpeed ;

   [SerializeField] private float jumpForce ;
    bool m_isGround;    
   [SerializeField] private Joystick Joystick;
    // serializeField them o dieu chinh Inspector || thay the = public cung tuong tu
    
    private enum MovementState { idle, running , jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Joystick.Horizontal * moveSpeed;
       
       // dirX = Input.GetAxisRaw("Horizontal"); // GetAxis bi truot nhe, GetAxisRaw ko truot   
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
           if (Input.GetKeyDown("space") && m_isGround) // Getkey an giu se tip tuc, GetKeyDown 1 an 1 lan
        {
            jumpSoundEffect.Play();
             rb.velocity = new Vector2(rb.velocity.x, jumpForce);         
            m_isGround = false;
        }   
       
     
       

        UpdateAnimationState();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            m_isGround = true;
        }
    }

    public void CachDiChuyen()
    {
        dirX = Joystick.Horizontal * moveSpeed;

        // dirX = Input.GetAxisRaw("Horizontal"); // GetAxis bi truot nhe, GetAxisRaw ko truot   
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    public void Jump()
    {
         if (!m_isGround)
             return;       
             jumpSoundEffect.Play();     
         rb.velocity = new Vector2(rb.velocity.x, jumpForce);
          m_isGround = false;
     //   if (Input.GetKeyDown("space") && m_isGround) // Getkey an giu se tip tuc, GetKeyDown 1 an 1 lan
     //   {
     //       jumpSoundEffect.Play();
      //      rb.velocity = new Vector2(rb.velocity.x, jumpForce);
      //      m_isGround = false;
      //  }
    }


    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
          //  anim.SetBool("running", true);
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {

            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }


}
