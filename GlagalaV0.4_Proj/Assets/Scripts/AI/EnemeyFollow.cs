using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemeyFollow : MonoBehaviour
{ 
    public Transform Player;
    public float distance;
    public float speed;
    RaycastHit2D hit;
    public bool destroyOnContact = false;
    GameObject tempPlayer;
    public bool gotoLastseen = true;
    GameObject lastseen;
    public Color inactive;
    public Color active;
    public Color inspecting;
    SpriteRenderer spriterenderer;
    public bool returnToStartPos = true;
    GameObject startPos;
    bool goback;
    bool reachedlastpos;

    // Start is called before the first frame update
    void Start()
    {
        if (Player == null)
        {
            tempPlayer = GameObject.FindGameObjectWithTag("Player");
            Player = tempPlayer.GetComponent<Transform>();
        }
        lastseen = new GameObject();
        lastseen.SetActive(true);
        spriterenderer = GetComponent<SpriteRenderer>();
        spriterenderer.color = inactive;
        startPos = new GameObject();
        startPos.transform.position = transform.position;
        lastseen.transform.position = Player.position;
        reachedlastpos = true;
    }
    private void FixedUpdate()
    {
        //Player in range
        if (Vector2.Distance(transform.position, Player.position) <= distance)
        {
            search();
        }
        //lastseen position is in range and player is not at lastseen
        if (lastseen.transform.position != Player.position && Vector2.Distance(transform.position, lastseen.transform.position) <= distance && !reachedlastpos)
        {
            if (gotoLastseen)
            {
                Move(lastseen.transform, inspecting);
            }
        }
        if (returnToStartPos)
        {
            //position and lastseen position are equal
            if (Vector2.Distance(transform.position, lastseen.transform.position) <= 0.1f)
            {
                reachedlastpos = true;
            }
            if (reachedlastpos)
            {
                Move(startPos.transform, inactive);
            }
        }
        if (Vector2.Distance(transform.position, startPos.transform.position) == 0.0f)
        {
            reachedlastpos = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && destroyOnContact)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        Destroy(lastseen);
        Destroy(startPos);
    }

    public void search()
    {
        hit = Physics2D.Raycast(transform.position, Player.position - transform.position, distance);

            if (hit.collider.tag == "Player")
            {
            reachedlastpos = false;
                lastseen.transform.position = Player.position;
                Debug.DrawLine(transform.position, hit.point, Color.green);
                Move(Player, active);
            }
            else
            {
                Debug.DrawLine(transform.position, hit.point, Color.yellow);
            }
    }
    public void Move(Transform target, Color color)
    {
        Debug.DrawLine(transform.position,target.position, color);
        spriterenderer.color = color;
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}



