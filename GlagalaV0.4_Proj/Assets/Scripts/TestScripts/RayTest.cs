using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayTest : MonoBehaviour
{
    public Transform castpoint;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 endpoint = castpoint.position + Vector3.right * distance;
        RaycastHit2D hit = Physics2D.Raycast(castpoint.position,endpoint,distance);
        if (hit)
        {
            
            Debug.Log("hit" + hit.collider.tag);
            Debug.DrawRay(castpoint.position,endpoint, Color.red);
        }
    }
}
