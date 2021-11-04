using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BulletImpact : MonoBehaviour
{
    public AudioClip impact;
    public AudioClip impactEnemy;
    AudioSource audiosrc;
    public impactType ImpactType;
    public float Timer = 0.6f;

    public enum impactType
    {
        Emvironement,
        Enemy
    }
    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        if (ImpactType == impactType.Emvironement)
        {
            audiosrc.PlayOneShot(impact);
        }
        else if (ImpactType == impactType.Enemy)
        {
            audiosrc.PlayOneShot(impactEnemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer < 0)
        {
            Destroy(gameObject);
        }
    }
}
