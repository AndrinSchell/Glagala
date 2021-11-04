using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// RigidBody Required
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class AIPatrol : MonoBehaviour
{
    /// <summary>
    /// Rigidbody for Movement
    /// </summary>
    Rigidbody2D rb2d;
    /// <summary>
    /// Enable or diseable Patroulling
    /// </summary>
    public bool mustPatrol = true;
    /// <summary>
    /// Speed of the Object
    /// </summary>
    public float walkSpeed;
    /// <summary>
    /// on true: Script only checks for walls
    /// </summary>
    public bool diseableGroundcheck = false;
    /// <summary>
    /// Distance for Object to turn (to ground)
    /// </summary>
    public float checkDistanceGround = 0.3f;
    /// <summary>
    /// Distance until Object turns
    /// </summary>
    public float checkDistanceWall = 0.3f;
    /// <summary>
    /// If this tag is hit Object will not turn
    /// </summary>
    public string GroundTag = "env";
    /// <summary>
    /// Ground check Ray will start from here
    /// </summary>
    public Transform GroundCheckPos;
    /// <summary>
    /// Wall Check Ray will start from here
    /// </summary>
    public Transform WallCheckPos;
    /// <summary>
    /// Ray Object for Wallcheck
    /// </summary>
    RaycastHit2D wallcheck;

    /// <summary>
    /// Init Rigidbody
    /// </summary>
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();  
    }
    
    public void Update()
    {
        if (mustPatrol)
        {
            Patrol();
            checkforTurn();
        }
    }
    /// <summary>
    /// Looks for Object collission distance and tetermines if Object should turn
    /// </summary>
    public void checkforTurn()
    {
        if (!diseableGroundcheck)
        {
            RaycastHit2D groundcheck = Physics2D.Raycast(GroundCheckPos.position, Vector2.down, 100);

            Debug.DrawLine(GroundCheckPos.position, groundcheck.point, Color.red);


            if (Vector2.Distance(groundcheck.point, GroundCheckPos.position) >= checkDistanceGround && groundcheck.collider.tag != "Player" &&  groundcheck.collider.tag != "bullet")
            {
                    Flip();
            }

        }
            if (facingright)
            {
                RaycastHit2D wallcheck = Physics2D.Raycast(WallCheckPos.position, Vector2.right, 100);
                Debug.DrawLine(WallCheckPos.position, wallcheck.point, Color.red);

                if (Vector2.Distance(wallcheck.point, GroundCheckPos.position) <= checkDistanceWall && wallcheck.collider.tag != "Player" && wallcheck.collider.tag != "enemy" && wallcheck.collider.tag != "bullet")
                {
                    Flip();
                }
            }
            else
            {
                RaycastHit2D wallcheck = Physics2D.Raycast(WallCheckPos.position, Vector2.left, 100);
                Debug.DrawLine(WallCheckPos.position, wallcheck.point, Color.red);

                if (Vector2.Distance(wallcheck.point, GroundCheckPos.position) <= checkDistanceWall && wallcheck.collider.tag != "Player" && wallcheck.collider.tag != "enemy" && wallcheck.collider.tag != "bullet")
                {
                    Flip();
                }
            }
    }
    /// <summary>
    /// Is Object Facing right
    /// </summary>
    bool facingright = true;
    /// <summary>
    /// Flips the Object and its Velocity direction
    /// </summary>
    void Flip()
    {
        mustPatrol = false;
        facingright = !facingright;
        transform.Rotate(0f, 180f, 0f);
        walkSpeed *= -1;
        mustPatrol = true;
    }
    /// <summary>
    /// Moves The Object
    /// </summary>
    private void Patrol()
    {
        rb2d.velocity = new Vector2(walkSpeed * Time.fixedDeltaTime, rb2d.velocity.y);
    }
}
