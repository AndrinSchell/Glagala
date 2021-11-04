using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Motion Input handler
    /// </summary>
    float axis;
    /// <summary>
    /// Speed Multiplier
    /// </summary>
    public float speed;
    /// <summary>
    /// Rigidbody (Physics Component)
    /// </summary>
    Rigidbody2D rb2d;
    /// <summary>
    /// is Player touching ground
    /// </summary>
    bool isgrounded;
    /// <summary>
    /// check player to ground connection here
    /// </summary>
    public Transform feetpos;
    /// <summary>
    /// groundcheck Radius
    /// </summary>
    public float checkradius;
    /// <summary>
    /// define wich Layer is ground
    /// </summary>
    public LayerMask whatisground;
    /// <summary>
    /// Jumpspeed multplier
    /// </summary>
    public float jumpForce;
    /// <summary>
    /// Animator Component
    /// </summary>
    Animator anim;
    /// <summary>
    /// Audiosource component >> Audio plays from here
    /// </summary>
    public AudioSource audiosrc;
    /// <summary>
    /// Audioclips
    /// </summary>
    public AudioClip jumpsound /*,walksound*/;
    /// <summary>
    /// Init components
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    /// <summary>
    /// update Animations
    /// </summary>
    void Update()
    {
        anim.SetBool("grounded", isgrounded);
        anim.SetFloat("speed", Mathf.Abs(axis));


        rb2d.velocity = new Vector2(axis * speed, rb2d.velocity.y);
        isgrounded = Physics2D.OverlapCircle(feetpos.position, checkradius, whatisground);
        if (facingright == false && axis > 0)
        {
            Flip();
        }
        else
        if (facingright == true && axis < 0)
        {
            Flip();
        }
        if (isgrounded)
        {
            candublejump = true;
        }

    }
    /// <summary>
    /// Movement and Groundcheck
    /// </summary>
    private void FixedUpdate()
    {

    }
    /// <summary>
    /// Player Run Method
    /// </summary>
    /// <param name="context">returns 1 for right and -1 for left</param>
    public void Run(InputAction.CallbackContext context)
    {
        axis = context.ReadValue<float>();
    }
    /// <summary>
    /// Did the player jump before
    /// </summary>
    bool candublejump;
    /// <summary>
    /// Gets called when Jump Action gets performed
    /// </summary>
    /// <param name="context">jump value</param>
    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed) // Prevents "Autodoublejump"
        {
            if (isgrounded && candublejump)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                audiosrc.PlayOneShot(jumpsound);
            }
            else if (candublejump)
            {
                rb2d.velocity = Vector2.up * jumpForce;
                audiosrc.PlayOneShot(jumpsound);
                candublejump = false;
            }
        }
    }
    /// <summary>
    /// is the player facing right
    /// </summary>
    bool facingright = true;
    /// <summary>
    /// Flips the Player
    /// </summary>
    void Flip()
    {
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
        //Vector3 Scaler = transform.localScale;
        //Scaler.x *= -1;
        //transform.localScale = Scaler;
    }
}
