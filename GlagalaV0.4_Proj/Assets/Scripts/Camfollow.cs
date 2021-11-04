using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camfollow : MonoBehaviour
{
    public Transform Target;
    public float speed;
    public bool lockY;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }
    private void LateUpdate()
    {
        if (lockY == true)
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(Target.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }else
        {
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(Target.position.x, Target.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
}
