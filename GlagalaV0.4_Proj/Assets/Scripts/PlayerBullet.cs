using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(AudioSource))]
public class PlayerBullet : MonoBehaviour
{
    public string enemyTag;
    public float bulletSpeed;
    public float DMG;
    Rigidbody2D rb2d;
    AudioSource audiosrc;
    public AudioClip spawn;
    public GameObject impactOBJ;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = transform.right * bulletSpeed;
        audiosrc = GetComponent<AudioSource>();
        audiosrc.PlayOneShot(spawn);

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == enemyTag )
        {
            EnemyHealth eh = collision.GetComponent<EnemyHealth>();
            eh.Damage(DMG);
            BulletImpact bI = impactOBJ.GetComponent<BulletImpact>();
            bI.ImpactType = BulletImpact.impactType.Enemy;
            Instantiate(bI, transform.position, transform.rotation);
            Destroy(gameObject);

        }
        if (collision.tag != "Player")
        {
            BulletImpact bI = impactOBJ.GetComponent<BulletImpact>();
            bI.ImpactType = BulletImpact.impactType.Emvironement;
            Instantiate(bI, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
