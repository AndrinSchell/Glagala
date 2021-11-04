using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform cam;
    public Transform p1;
    public Transform p2;

    BoxCollider2D coll;
    bool hasmoved;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Move();
        }
    }

    public void Move()
    {
        if (hasmoved)
        {
            MoveBack();
        }
        else
        {
            cam.position = p2.position;
            hasmoved = true;
        }

    }

    void MoveBack()
    {
        cam.position = p1.position;
        hasmoved = false;
    }

}
