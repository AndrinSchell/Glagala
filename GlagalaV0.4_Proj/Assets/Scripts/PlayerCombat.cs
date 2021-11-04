using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCombat : MonoBehaviour
{
    /// <summary>
    /// Will be Played on Fire
    /// </summary>
    public Animator anim;
    /// <summary>
    /// Bullet Object
    /// </summary>
    public GameObject bullet;
    /// <summary>
    /// Bullet will be shot from here
    /// </summary>
    public Transform firepoint;
    /// <summary>
    /// Inits Bullet Object at firepoint and Plays animation
    /// </summary>
    /// <param name="context"></param>
    public void Fire(InputAction.CallbackContext context)
    { 
        if (context.performed)
        {
            anim.PlayInFixedTime("fire");
            Instantiate(bullet, firepoint.position, firepoint.rotation);
        }
    }
}
